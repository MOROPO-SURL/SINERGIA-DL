using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Person;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.UI.Pages.EconomicActivity;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Interop.Connect.Client;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Organization;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.DevelopmentActorProfile;

public sealed class DevelopmentActorProfileConfigurationPageModel : AbstractConfigurationPageModel<SRLDevelopmentActorProfileDetailDtoModel, SRLDevelopmentActorProfileDetailDtoModel>
{
    public static string BornAtValidableProperty => nameof(BornAt);
    public static string FiscalIdentificationCodeValidableProperty => nameof(FiscalIdentificationCode);
    public static string MainEconomicActivityValidableProperty => nameof(MainEconomicActivity);
    public static string MainLocationValidableProperty => nameof(MainLocation);
    public static string OrganizationPartnersValidableProperty => nameof(OrganizationPartners);
    public static string PersonPartnersValidableProperty => nameof(PersonPartners);
    public static string AboutValidableProperty => nameof(About);

    private readonly List<OrganizationBasicDtoModel> inOrganizationPartners = [];
    private readonly List<OrganizationBasicDtoModel> outOrganizationPartners = [];

    private readonly List<PersonBasicDtoModel> inPersonPartners = [];
    private readonly List<PersonBasicDtoModel> outPersonPartners = [];

    private readonly List<EconomicActivityBasicDtoModel> inSecoundaryEconomicActivities = [];
    private readonly List<EconomicActivityBasicDtoModel> outSecoundaryEconomicActivities = [];

    private readonly List<LocationCreateRequestModel> inLocations = [];
    private readonly List<Guid> linkLocationIds = [];
    private readonly List<Guid> unlinkLocationIds = [];

    private string fiscalIdentificationCode;
    private DateTime bornAt;
    private string? about;
    private EconomicActivityBasicDtoModel mainEconomicActivity;
    private LocationDetailDtoModel mainLocation;

    public DevelopmentActorProfileConfigurationPageModel(SRLDevelopmentActorProfileDetailDtoModel? model, Action<SRLDevelopmentActorProfileDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        #region Commands

        PickMainEconomicActivityCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new EconomicActivityPickPage(MainEconomicActivityPicked_Callback)));
        });

        #region SecoundaryEconomicActivity

        AddSecoundaryEconomicActivityCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new EconomicActivityPickPage(SecoundaryEconomicActivityPicked_Callback)));
        });

        RemoveSecoundaryEconomicActivityCommand = new Command<EconomicActivityBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inSecoundaryEconomicActivities)
                {
                    if (item.Id != model.Id) continue;

                    inSecoundaryEconomicActivities.Remove(inSecoundaryEconomicActivities.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outSecoundaryEconomicActivities.Add(model);
                }

                Dispatcher.Dispatch(() => SecoundaryEconomicActivities.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region Organizations

        AddOrganizationPartnerCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new OrganizationPickPage(OrganizationPicked_Callback)));
        });

        RemoveOrganizationPartnerCommand = new Command<OrganizationBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inOrganizationPartners)
                {
                    if (item.Id != model.Id) continue;

                    inOrganizationPartners.Remove(inOrganizationPartners.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outOrganizationPartners.Add(model);
                }

                Dispatcher.Dispatch(() => OrganizationPartners.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region Persons

        AddPersonPartnerCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new PersonPickPage(PersonPicked_Callback)));
        });

        RemovePersonPartnerCommand = new Command<PersonBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inPersonPartners)
                {
                    if (item.Id != model.Id) continue;

                    inPersonPartners.Remove(inPersonPartners.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outPersonPartners.Add(model);
                }

                Dispatcher.Dispatch(() => PersonPartners.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region Locations

        MainLocationPickCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new LocationPickPage(MainLocationPicked_Callback, MainLocationCreateSuccess_Callback)));
        });

        AddCommercialLocationCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new LocationPickPage(CommercialLocationPicked_Callback, CommercialLocationCreateSuccess_Callback)));
        });

        RemoveCommercialLocationCommand = new Command<LocationDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inLocations)
                {
                    if (item.Id != model.Id) continue;

                    inLocations.Remove(inLocations.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in linkLocationIds)
                    {
                        if (item != model.Id) continue;

                        linkLocationIds.Remove(item);

                        break;
                    }
                }

                if (!handled)
                {
                    unlinkLocationIds.Add(model.Id);
                }

                Dispatcher.Dispatch(() => CommercialLocations!.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new LocationDetailPage(model, inLocations.FirstOrDefault(item => item.Id == model.Id)?.FeatureImageCreateRequest ?? null));
        });

        #endregion

        #endregion

        Id = model?.Id;
        fiscalIdentificationCode = model?.FiscalIdentificationCode ?? null!;
        bornAt = model?.BornAt.ToDateTime(default) ?? DateTime.Now;
        about = model?.About;
        mainEconomicActivity = model?.MainEconomicActivity ?? null!;
        mainLocation = model?.MainLocation ?? null!;
        SecoundaryEconomicActivities = [.. model?.SecoundaryEconomicActivities ?? []];
        CommercialLocations = [.. model?.CommercialLocations ?? []];
        OrganizationPartners = [.. model?.OrganizationPartners ?? []];
        PersonPartners = [.. model?.PersonPartners ?? []];
    }

    public override IValidationContext? ValidationContext => new ValidationContext<DevelopmentActorProfileConfigurationPageModel>(this);

    protected override Task<SRLDevelopmentActorProfileDetailDtoModel> PerformCreationAsync()
    {
        SRLDevelopmentActorProfilesCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command.SRLDevelopmentActorProfileCreateRequestModel(
            Guid.NewGuid(),
            ((Common.Models.Page.AppShellPageModel)Shell.Current!.BindingContext).Organization.Id,
            fiscalIdentificationCode,
            DateOnly.FromDateTime(bornAt),
            mainEconomicActivity.Id,
            inSecoundaryEconomicActivities.Select(item => item.Id),
            mainLocation.Id,
            [.. inLocations],
            [.. linkLocationIds],
            inOrganizationPartners.Select(item => item.Id),
            inPersonPartners.Select(item => item.Id),
            about));
    }

    protected override Task<SRLDevelopmentActorProfileDetailDtoModel> PerformEditionAsync()
    {
        SRLDevelopmentActorProfilesCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command.SRLDevelopmentActorProfileUpdateRequestModel(
            Id!.Value,
            fiscalIdentificationCode,
            DateOnly.FromDateTime(bornAt),
            mainEconomicActivity.Id,
            inSecoundaryEconomicActivities.Select(item => item.Id),
            outSecoundaryEconomicActivities.Select(item => item.Id),
            mainLocation.Id,
            [.. inLocations],
            [.. linkLocationIds],
            [.. unlinkLocationIds],
            inOrganizationPartners.Select(item => item.Id),
            outOrganizationPartners.Select(item => item.Id),
            inPersonPartners.Select(item => item.Id),
            outPersonPartners.Select(item => item.Id),
            about));
    }

    public Guid? Id { get; init; }

    public string FiscalIdentificationCode { get => fiscalIdentificationCode; set => SetProperty(ref fiscalIdentificationCode, value); }

    public DateTime BornAt { get => bornAt; set => SetProperty(ref bornAt, value); }

    public EconomicActivityBasicDtoModel MainEconomicActivity { get => mainEconomicActivity; set => SetProperty(ref mainEconomicActivity, value); }

    public ICommand PickMainEconomicActivityCommand { get; init; }

    public ObservableCollection<EconomicActivityBasicDtoModel> SecoundaryEconomicActivities { get; init; } = [];

    public ICommand AddSecoundaryEconomicActivityCommand { get; init; }

    public ICommand RemoveSecoundaryEconomicActivityCommand { get; init; }

    public LocationDetailDtoModel MainLocation { get => mainLocation; set => SetProperty(ref mainLocation, value); }

    public ICommand MainLocationPickCommand { get; init; }

    public ObservableCollection<LocationDetailDtoModel> CommercialLocations { get; init; }

    public ICommand AddCommercialLocationCommand { get; init; }

    public ICommand RemoveCommercialLocationCommand { get; init; }

    public ICommand DetailLocationCommand { get; init; }

    public ObservableCollection<PersonBasicDtoModel> PersonPartners { get; init; } = [];

    public ICommand AddPersonPartnerCommand { get; init; }

    public ICommand RemovePersonPartnerCommand { get; init; }

    public ObservableCollection<OrganizationBasicDtoModel> OrganizationPartners { get; init; } = [];

    public ICommand AddOrganizationPartnerCommand { get; init; }

    public ICommand RemoveOrganizationPartnerCommand { get; init; }

    public string? About { get => about; set => SetProperty(ref about, value); }

    private void OrganizationPicked_Callback(OrganizationBasicDtoModel model)
    {
        inOrganizationPartners.Add(model);

        OrganizationPartners.Add(model);

        hasChangesFlag = true;
    }

    private void PersonPicked_Callback(PersonBasicDtoModel model)
    {
        inPersonPartners.Add(model);

        PersonPartners.Add(model);

        hasChangesFlag = true;
    }

    private void MainEconomicActivityPicked_Callback(EconomicActivityBasicDtoModel model)
    {
        MainEconomicActivity = model;

        hasChangesFlag = true;
    }

    private void SecoundaryEconomicActivityPicked_Callback(EconomicActivityBasicDtoModel model)
    {
        inSecoundaryEconomicActivities.Add(model);

        SecoundaryEconomicActivities.Add(model);

        hasChangesFlag = true;
    }

    private void MainLocationCreateSuccess_Callback(LocationUpdateRequestModel model)
    {
        if (mainLocation != null)
        {
            LocationCreateRequestModel? currentMainLocation = inLocations.FirstOrDefault(item => item.Id == mainLocation.Id);

            if (currentMainLocation != null) inLocations.Remove(currentMainLocation);
        }

        inLocations.Add(new LocationCreateRequestModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, model.FeatureImageCreateRequest, model.Description));

        MainLocation = new LocationDetailDtoModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, null, model.Description);

        hasChangesFlag = true;
    }

    private void CommercialLocationCreateSuccess_Callback(LocationUpdateRequestModel model)
    {
        inLocations.Add(new LocationCreateRequestModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, model.FeatureImageCreateRequest, model.Description));

        // TODO Order list !!!
        CommercialLocations.Add(new LocationDetailDtoModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, null, model.Description));

        hasChangesFlag = true;
    }

    private void MainLocationPicked_Callback(LocationDetailDtoModel model)
    {
        if (mainLocation != null)
        {
            LocationCreateRequestModel? currentMainLocation = inLocations.FirstOrDefault(item => item.Id == mainLocation.Id);

            if (currentMainLocation != null) inLocations.Remove(currentMainLocation);
        }

        MainLocation = model;

        hasChangesFlag = true;
    }

    private void CommercialLocationPicked_Callback(LocationDetailDtoModel model)
    {
        linkLocationIds.Add(model.Id);

        // TODO Order list !!!
        CommercialLocations.Add(model);

        hasChangesFlag = true;
    }
}
