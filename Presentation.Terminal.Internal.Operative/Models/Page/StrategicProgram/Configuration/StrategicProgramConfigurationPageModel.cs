using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Organization;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;

public sealed class StrategicProgramConfigurationPageModel : AbstractConfigurationPageModel<StrategicProgramDetailDtoModel, StrategicProgramDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string LineValidableProperty => nameof(Line);
    public static string CoordinatorValidableProperty => nameof(Coordinator);
    public static string ObjectiveValidableProperty => nameof(Objective);
    public static string DescriptionValidableProperty => nameof(Description);

    private StrategicLineBasicDtoModel line = null!;
    private string name = null!;
    private PersonBasicDtoModel coordinator = null!;
    private string objective = null!;
    private string? description;
    private int priority = 1;

    private readonly List<OrganizationBasicDtoModel> inOrganizations = [];
    private readonly List<OrganizationBasicDtoModel> outOrganizations = [];

    private readonly List<MacroprogramBasicDtoModel> inMacroprograms = [];
    private readonly List<MacroprogramBasicDtoModel> outMacroprograms = [];

    public StrategicProgramConfigurationPageModel(StrategicProgramDetailDtoModel? model, StrategicLineBasicDtoModel[] availableLines, Action<StrategicProgramDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicProgramConfigurationValidator())
    {
        AvailableLines = availableLines;

        #region Commands

        #region Organizations

        AddOrganizationCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new OrganizationPickPage(OrganizationPicked_Callback)));
        });

        RemoveOrganizationCommand = new Command<OrganizationBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inOrganizations)
                {
                    if (item.Id != model.Id) continue;

                    inOrganizations.Remove(inOrganizations.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outOrganizations.Add(model);
                }

                Dispatcher.Dispatch(() => Organizations.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region Macroprograms

        AddMacroprogramCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new MacroprogramPickPage(MacroprogramPicked_Callback)));
        });

        RemoveMacroprogramCommand = new Command<MacroprogramBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inMacroprograms)
                {
                    if (item.Id != model.Id) continue;

                    inMacroprograms.Remove(inMacroprograms.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outMacroprograms.Add(model);
                }

                Dispatcher.Dispatch(() => Macroprograms.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #endregion

        if (model is null) return;

        Id = model.Id;
        line = availableLines.First(item => item == model.Line);
        name = model.Name;
        objective = model.Objective;
        coordinator = model.Coordinator;
        description = model.Description;
        priority = model.Priority;
    }

    public Guid Id { get; set; }

    public StrategicLineBasicDtoModel Line { get => line; set => SetProperty(ref line, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public PersonBasicDtoModel Coordinator { get => coordinator; set => SetProperty(ref coordinator, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string Objective { get => objective; set => SetProperty(ref objective, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<OrganizationBasicDtoModel> Organizations { get; private set; } = [];

    public ICommand AddOrganizationCommand { get; private set; }

    public ICommand RemoveOrganizationCommand { get; private set; }

    public ObservableCollection<MacroprogramBasicDtoModel> Macroprograms { get; private set; } = [];

    public ICommand AddMacroprogramCommand { get; private set; }

    public ICommand RemoveMacroprogramCommand { get; private set; }

    public StrategicLineBasicDtoModel[] AvailableLines { get; private set; }

    protected override Task<StrategicProgramDetailDtoModel> PerformCreationAsync()
    {
        StrategicProgramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicProgramCreateRequestModel
            (
                name,
                true,
                line.Id,
                coordinator.Id,
                objective,
                priority,
                [.. inOrganizations],
                [.. inMacroprograms],
                description
            ));
    }

    protected override Task<StrategicProgramDetailDtoModel> PerformEditionAsync()
    {
        StrategicProgramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicProgramUpdateRequestModel
            (
                Id,
                name,
                line.Id,
                coordinator.Id,
                objective,
                priority,
                true,
                [.. inOrganizations],
                [.. outOrganizations],
                [.. inMacroprograms],
                [.. outMacroprograms],
                description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicProgramConfigurationPageModel>(this);

    private void OrganizationPicked_Callback(OrganizationBasicDtoModel model)
    {
        inOrganizations.Add(model);

        Organizations.Add(model);

        hasChangesFlag = true;
    }

    private void MacroprogramPicked_Callback(MacroprogramBasicDtoModel model)
    {
        inMacroprograms.Add(model);

        Macroprograms.Add(model);

        hasChangesFlag = true;
    }
}