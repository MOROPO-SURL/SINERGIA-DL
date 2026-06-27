using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Organization;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.PublicPolicy;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicLine.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicLine.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;

public sealed class StrategicLineConfigurationPageModel : AbstractConfigurationPageModel<StrategicLineDetailDtoModel, StrategicLineDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string CoordinatorValidableProperty => nameof(Coordinator);
    public static string ObjectiveValidableProperty => nameof(Objective);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private StrategicAxeBasicDtoModel? axe;
    private string name = null!;
    private string objective = null!;
    private PersonBasicDtoModel coordinator = null!;
    private string? description;

    private readonly List<StrategicLineSpecificObjectiveCreateRequestModel> inSpecificObjectives = [];
    private readonly List<StrategicLineSpecificObjectiveUpdateRequestModel> patchSpecificObjectives = [];
    private readonly List<StrategicLineSpecificObjectiveDetailDtoModel> outSpecificObjectives = [];

    private readonly List<PublicPolicyBasicDtoModel> inPublicPolicies = [];
    private readonly List<PublicPolicyBasicDtoModel> outPublicPolicies = [];

    private readonly List<OrganizationBasicDtoModel> inOrganizations = [];
    private readonly List<OrganizationBasicDtoModel> outOrganizations = [];

    private readonly List<MacroprogramBasicDtoModel> inMacroprograms = [];
    private readonly List<MacroprogramBasicDtoModel> outMacroprograms = [];

    public StrategicLineConfigurationPageModel(StrategicLineDetailDtoModel? model, StrategicAxeBasicDtoModel[] availableAxes, Action<StrategicLineDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicLineConfigurationValidator())
    {
        AvailableAxes = availableAxes;

        #region Commands

        #region SpecificObjectives

        CreateSpecificObjectiveCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new StrategicLineSpecificObjectiveConfigurationPage(new StrategicLineSpecificObjectiveConfigurationPageModel(null, SpecificObjectiveCreateSuccess_Callback, new StrategicLineSpecificObjectiveConfigurationValidator(this))));
        });

        UpdateSpecificObjectiveCommand = new Command<StrategicLineSpecificObjectiveDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new StrategicLineSpecificObjectiveConfigurationPage(new StrategicLineSpecificObjectiveConfigurationPageModel(model, SpecificObjectiveModifySuccess_Callback, new StrategicLineSpecificObjectiveConfigurationValidator(this))));
        });

        RemoveSpecificObjectiveCommand = new Command<StrategicLineSpecificObjectiveDetailDtoModel>(model => 
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inSpecificObjectives)
                {
                    if (item.Index != model.Index) continue;

                    inSpecificObjectives.Remove(inSpecificObjectives.First(item => item.Index == model.Index));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in patchSpecificObjectives)
                    {
                        if (item.Index != model.Index) continue;

                        patchSpecificObjectives.Remove(patchSpecificObjectives.First(item => item.Index == model.Index));

                        break;
                    }
                }

                if (!handled)
                {
                    outSpecificObjectives.Add(model);
                }

                Dispatcher.Dispatch(() => SpecificObjectives.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailSpecificObjectiveCommand = new Command<StrategicLineSpecificObjectiveDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new StrategicLineSpecificObjectiveDetailPage(model));
        });

        #endregion

        #region PublicPolicies

        AddPublicPolicyCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new PublicPolicyPickPage(PublicPolicyPicked_Callback)));
        });

        RemovePublicPolicyCommand = new Command<PublicPolicyBasicDtoModel>(model => 
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inPublicPolicies)
                {
                    if (item.Id != model.Id) continue;

                    inPublicPolicies.Remove(inPublicPolicies.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outPublicPolicies.Add(model);
                }

                Dispatcher.Dispatch(() => PublicPolicies.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

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
        Index = model.Index;
        axe = availableAxes.FirstOrDefault(item => item == model.Axe);
        name = model.Name;
        objective = model.Objective;
        coordinator = model.Coordinator;
        description = model.Description;

        SpecificObjectives = [.. model.SpecificObjectives];
        PublicPolicies = [.. model.PublicPolicies];
        Organizations = [.. model.Organizations];
        Macroprograms = [.. model.Macroprograms];
    }

    public Guid? Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public StrategicAxeBasicDtoModel? Axe { get => axe; set => SetProperty(ref axe, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string Objective { get => objective; set => SetProperty(ref objective, value); }

    public PersonBasicDtoModel Coordinator { get => coordinator; set => SetProperty(ref coordinator, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<StrategicLineSpecificObjectiveDetailDtoModel> SpecificObjectives { get; private set; } = [];

    public ICommand CreateSpecificObjectiveCommand { get; private set; }

    public ICommand UpdateSpecificObjectiveCommand { get; private set; }

    public ICommand RemoveSpecificObjectiveCommand { get; private set; }

    public ICommand DetailSpecificObjectiveCommand { get; private set; }

    public ObservableCollection<PublicPolicyBasicDtoModel> PublicPolicies { get; private set; } = [];

    public ICommand AddPublicPolicyCommand { get; private set; }

    public ICommand RemovePublicPolicyCommand { get; private set; }

    public ObservableCollection<OrganizationBasicDtoModel> Organizations { get; private set; } = [];

    public ICommand AddOrganizationCommand { get; private set; }

    public ICommand RemoveOrganizationCommand { get; private set; }

    public ObservableCollection<MacroprogramBasicDtoModel> Macroprograms { get; private set; } = [];

    public ICommand AddMacroprogramCommand { get; private set; }

    public ICommand RemoveMacroprogramCommand { get; private set; }

    public StrategicAxeBasicDtoModel[] AvailableAxes { get; private set; }

    protected override Task<StrategicLineDetailDtoModel> PerformCreationAsync()
    {
        StrategicLineCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicLineCreateRequestModel
            (
                Index,
                true,
                Name,
                Coordinator.Id,
                Objective,
                [.. inSpecificObjectives],
                [.. inPublicPolicies],
                [.. inOrganizations],
                [.. inMacroprograms],
                axe?.Id,
                Description
            ));
    }

    protected override Task<StrategicLineDetailDtoModel> PerformEditionAsync()
    {
        StrategicLineCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicLineUpdateRequestModel
            (
                Id!.Value,
                Index,
                true,
                Name,
                Coordinator.Id,
                Objective,
                [.. inSpecificObjectives],
                [.. patchSpecificObjectives],
                [.. outSpecificObjectives],
                [.. inPublicPolicies],
                [.. outPublicPolicies],
                [.. inOrganizations],
                [.. outOrganizations],
                [.. inMacroprograms],
                [.. outMacroprograms],
                axe?.Id,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicLineConfigurationPageModel>(this);

    private void PublicPolicyPicked_Callback(PublicPolicyBasicDtoModel model)
    {
        inPublicPolicies.Add(model);

        PublicPolicies.Add(model);

        hasChangesFlag = true;
    }

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
    
    private void SpecificObjectiveCreateSuccess_Callback(StrategicLineSpecificObjectiveDetailDtoModel model)
    {
        inSpecificObjectives.Add(new StrategicLineSpecificObjectiveCreateRequestModel(model.Index, model.Content));

        // TODO Order list !!!
        SpecificObjectives.Add(model);

        hasChangesFlag = true;
    }

    private void SpecificObjectiveModifySuccess_Callback(StrategicLineSpecificObjectiveDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inSpecificObjectives)
        {
            if (item.Index != model.Index) continue;

            inSpecificObjectives.Remove(item);

            inSpecificObjectives.Add(new StrategicLineSpecificObjectiveCreateRequestModel(model.Index, model.Content));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchSpecificObjectives)
            {
                if (item.Id != model.Id) continue;

                patchSpecificObjectives.Remove(item);

                patchSpecificObjectives.Add(new StrategicLineSpecificObjectiveUpdateRequestModel(model.Id, model.Index, model.Content));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchSpecificObjectives.Add(new StrategicLineSpecificObjectiveUpdateRequestModel(model.Id, model.Index, model.Content));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in SpecificObjectives)
        {
            index++;

            if (item.Id != model.Id) continue;

            SpecificObjectives[index] = new StrategicLineSpecificObjectiveDetailDtoModel(model.Id, model.Index, model.Content);

            break;
        }

        hasChangesFlag = true;
    }
}