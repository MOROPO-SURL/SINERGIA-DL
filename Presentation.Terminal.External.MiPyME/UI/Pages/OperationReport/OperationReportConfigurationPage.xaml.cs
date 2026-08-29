using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.OperationReport;
using System.Xml.Linq;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages.OperationReport;

public partial class OperationReportConfigurationPage : BaseConfigurationEntityPage<SRLOperationReportDetailDtoModel, SRLOperationReportDetailDtoModel, OperationReportConfigurationPageModel>
{
    public OperationReportConfigurationPage(OperationReportConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Informe al CAM";

    private void ImportButton_Clicked(object sender, EventArgs args)
    {
        FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, [ "application/xml" ] }, // MIME type
                    { DevicePlatform.WinUI, [ ".xml" ] }, // file extension
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            try
            {
                XDocument document = XDocument.Load(await task.Result.OpenReadAsync());

                if (document.Root!.Element("encabezado")!.Element("idnummodelo")!.Value != "0003") throw new InvalidOperationException();

                ConcreteBindingContext.Period = DateTime.Parse(document.Root!.Element("encabezado")!.Element("idfechadelinformeacumulado")!.Value);

                IEnumerable<XElement> pageElements = document.Root.Element("paginas")!.Elements("pagina");

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IncomeBankDeposit = 0;
                    ConcreteBindingContext.IncomeEcommerce = 0;

                    foreach (XElement pageElement in pageElements)
                    {
                        IEnumerable<XElement> indicatorElements = pageElement.Elements("indicador");

                        foreach (XElement indicatorElement in indicatorElements)
                        {
                            int code = int.Parse(indicatorElement.Attribute("codigofila")!.Value);

                            switch (code)
                            {
                                case 1100:
                                    ConcreteBindingContext.EmployeeCount = (int)float.Parse(indicatorElement.Elements("aspecto").ElementAt(0).Value);

                                    continue;

                                case 1110:
                                    ConcreteBindingContext.FemaleEmployeeCount = (int)float.Parse(indicatorElement.Elements("aspecto").ElementAt(0).Value);

                                    break;
                                case 100:
                                    ConcreteBindingContext.IncomeSummary = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 120:
                                    ConcreteBindingContext.IncomeEcommerce = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 200:
                                    ConcreteBindingContext.SpendSummary = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 510:
                                    ConcreteBindingContext.SpendPrivateSector = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 520:
                                    ConcreteBindingContext.SpendPublicSector = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 525:
                                    ConcreteBindingContext.PeriodResult = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 600:
                                    ConcreteBindingContext.OperativeTax = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 700:
                                    ConcreteBindingContext.SellTax = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;

                                case 1200:
                                    ConcreteBindingContext.HumanResourcePayload = float.Parse(indicatorElement.Elements("aspecto").ElementAt(1).Value);

                                    continue;
                            }
                        }
                    }

                    Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Importación de datos completada con éxito.");
                });
            }
            catch (Exception)
            {
                await DisplayAlert("Aviso", "No fue posible importar del documento facilitado. Formato no compatible.", "Aceptar");
            }
        });
    }

    private void AddDocumentButton_Clicked(object sender, EventArgs eventArgs)
    {
        DocumentPickPresenter.Instance.BeginDocumentPickAsync(this, ConcreteBindingContext.DocumentPickSuccess_Callback);
    }
}