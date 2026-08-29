using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Document.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Document.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Interop.Connect.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.OperationReport;

public sealed class OperationReportConfigurationPageModel : AbstractConfigurationPageModel<SRLOperationReportDetailDtoModel, SRLOperationReportDetailDtoModel>
{
    public static string DescriptionValidableProperty => nameof(Description);
    public static string IncomeSummaryValidableProperty => nameof(IncomeSummary);
    public static string SpendSummaryValidableProperty => nameof(SpendSummary);
    public static string FemaleEmployeeCountValidableProperty => nameof(FemaleEmployeeCount);
    public static string DiscapacityEmployeeCountValidableProperty => nameof(DiscapacityEmployeeCount);

    private DateTime period;
    private int employeeCount;
    private int femaleEmployeeCount;
    private int discapacityEmployeeCount;
    private float gridEnergySpend;
    private float renerenewableEnergyGeneration;
    private float renerenewableEnergyExportation;
    private float incomeSummary;
    private float incomeEcommerce;
    private float incomeBankDeposit;
    private float spendSummary;
    private float spendPrivateSector;
    private float spendPublicSector;
    private float periodResult;
    private float operativeTax;
    private float sellTax;
    private float humanResourcePayload;
    private string? description;

    private readonly List<DocumentCreateRequestModel> inDocuments = [];
    private readonly List<Guid> outDocumentIds = [];

    public OperationReportConfigurationPageModel(Guid ownerId, SRLOperationReportDetailDtoModel? model, Action<SRLOperationReportDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        #region Commands

        #region Documents

        DeleteDocumentCommand = new Command<DocumentBasicDtoModel>(item =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var model in inDocuments)
                {
                    if (model.Id != item.Id) continue;

                    inDocuments.Remove(inDocuments.First(_item => _item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outDocumentIds.Add(item.Id);
                }

                Dispatcher.Dispatch(() => Documents!.Remove(item));

                hasChangesFlag = true;
            });
        });

        #endregion

        #endregion

        OwnerId = ownerId;

        DateTime now = DateTime.Now;

        Id = model?.Id;
        period = new DateTime(model?.Period ?? new DateOnly(now.Year, now.Month, 28), default);
        employeeCount = model?.EmployeeCount ?? 0;
        femaleEmployeeCount = model?.FemaleEmployeeCount ?? 0;
        discapacityEmployeeCount = model?.DiscapacityEmployeeCount ?? 0;
        gridEnergySpend = model?.GridEnergySpend ?? 0;
        renerenewableEnergyGeneration = model?.RenerenewableEnergyGeneration ?? 0;
        renerenewableEnergyExportation = model?.RenerenewableEnergyExportation ?? 0;
        incomeSummary = model?.IncomeEcommerceEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        incomeEcommerce = model?.IncomeEcommerceEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        incomeBankDeposit = model?.IncomeBankDepositEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        spendSummary = model?.SpendSummaryEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        spendPrivateSector = model?.SpendPrivateSectorEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        spendPublicSector = model?.SpendPublicSectorEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        periodResult = model?.SpendPrivateSectorEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        operativeTax = model?.OperativeTaxEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        sellTax = model?.SellTaxEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        humanResourcePayload = model?.HumanResourcePayloadEntries.Single(item => item.Key == OperationReportAccountingEntryCurrency.Default).Value ?? 0;
        description = model?.Description;

        Documents = [.. model?.Documents ?? []];
    }

    public override IValidationContext? ValidationContext => new ValidationContext<OperationReportConfigurationPageModel>(this);

    protected override Task<SRLOperationReportDetailDtoModel> PerformCreationAsync()
    {
        SRLOperationReportCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new SRLOperationReportCreateRequestModel
            (
                OwnerId,
                DateOnly.FromDateTime(period),
                employeeCount,
                femaleEmployeeCount,
                discapacityEmployeeCount,
                gridEnergySpend,
                renerenewableEnergyGeneration,
                RenerenewableEnergyExportation,
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, incomeSummary)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, incomeEcommerce)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, incomeBankDeposit)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, spendSummary)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, spendPrivateSector)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, spendPublicSector)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, periodResult)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, operativeTax)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, sellTax)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, humanResourcePayload)],
                [.. inDocuments],
                Description
            ));
    }

    protected override Task<SRLOperationReportDetailDtoModel> PerformEditionAsync()
    {
        SRLOperationReportCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new SRLOperationReportUpdateRequestModel
            (
                Id!.Value,
                DateOnly.FromDateTime(period),
                employeeCount,
                femaleEmployeeCount,
                discapacityEmployeeCount,
                gridEnergySpend,
                renerenewableEnergyGeneration,
                RenerenewableEnergyExportation,
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, incomeSummary)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, incomeEcommerce)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, incomeBankDeposit)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, spendSummary)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, spendPrivateSector)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, spendPublicSector)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, periodResult)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, operativeTax)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, sellTax)],
                [new KeyValuePair<OperationReportAccountingEntryCurrency, float>(OperationReportAccountingEntryCurrency.Default, humanResourcePayload)],
                [.. inDocuments],
                [.. outDocumentIds],
                Description
            ));
    }

    public long? Id { get; init; }

    public Guid OwnerId { get; init; }

    public DateTime Period { get => period; set => SetProperty(ref period, new DateTime(value.Year, value.Month, 28), ReviewPeriod); }

    public int EmployeeCount { get => employeeCount; set => SetProperty(ref employeeCount, value); }

    public int FemaleEmployeeCount { get => femaleEmployeeCount; set => SetProperty(ref femaleEmployeeCount, value); }
    
    public int DiscapacityEmployeeCount { get => discapacityEmployeeCount; set => SetProperty(ref discapacityEmployeeCount, value); }
    public float GridEnergySpend { get => gridEnergySpend; set => SetProperty(ref gridEnergySpend, value); }

    public float RenerenewableEnergyGeneration { get => renerenewableEnergyGeneration; set => SetProperty(ref renerenewableEnergyGeneration, value); }

    public float RenerenewableEnergyExportation { get => renerenewableEnergyExportation; set => SetProperty(ref renerenewableEnergyExportation, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public float IncomeSummary { get => incomeSummary; set => SetProperty(ref incomeSummary, value); }

    public float IncomeEcommerce { get => incomeEcommerce; set => SetProperty(ref incomeEcommerce, value); }

    public float IncomeBankDeposit { get => incomeBankDeposit; set => SetProperty(ref incomeBankDeposit, value); }

    public float SpendSummary { get => spendSummary; set => SetProperty(ref spendSummary, value); }

    public float SpendPrivateSector { get => spendPrivateSector; set => SetProperty(ref spendPrivateSector, value); }

    public float SpendPublicSector { get => spendPublicSector; set => SetProperty(ref spendPublicSector, value); }

    public float PeriodResult { get => periodResult; set => SetProperty(ref periodResult, value); }

    public float OperativeTax { get => operativeTax; set => SetProperty(ref operativeTax, value); }

    public float SellTax { get => sellTax; set => SetProperty(ref sellTax, value); }

    public float HumanResourcePayload { get => humanResourcePayload; set => SetProperty(ref humanResourcePayload, value); }

    public ObservableCollection<DocumentBasicDtoModel> Documents { get; init; }

    public ICommand DeleteDocumentCommand { get; init; }

    private void ReviewPeriod()
    {
        if (period.Day == 28) return;

        Period = new DateTime(period.Year, period.Month, 28);
    }

    public void DocumentPickSuccess_Callback(DocumentCreateRequestModel model)
    {
        inDocuments.Add(model);

        Documents.Add(new DocumentBasicDtoModel(model.Id, model.Name, MimeTypes.MimeTypeMap.GetExtension(model.ContentType), model.ContentData.Length));

        hasChangesFlag = true;
    }
}
