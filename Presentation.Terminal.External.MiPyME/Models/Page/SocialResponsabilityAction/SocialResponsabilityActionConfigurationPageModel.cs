using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.SocialResponsabilityAction;

public sealed class SocialResponsabilityActionConfigurationPageModel : AbstractConfigurationPageModel<SRLSocialResponsabilityActionDetailDtoModel, SRLSocialResponsabilityActionDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string AtValidableProperty => nameof(At);
    public static string LocationsValidableProperty => nameof(Locations);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title;
    DateTime at;
    private SocialSupportDemandBasicDtoModel? demand;
    private string? description;

    private readonly List<LocationCreateRequestModel> inLocations = [];
    private readonly List<Guid> linkLocationIds = [];
    private readonly List<Guid> unlinkLocationIds = [];

    private readonly List<ImageCreateRequestModel> inImages = [];
    private readonly List<Guid> outImageIds = [];

    public SocialResponsabilityActionConfigurationPageModel(Guid ownerId, SRLSocialResponsabilityActionDetailDtoModel? model, Action<SRLSocialResponsabilityActionDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        #region Commands

        #region Locations

        AddLocationCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new LocationPickPage(LocationPicked_Callback, LocationCreateSuccess_Callback)));
        });

        DeleteLocationCommand = new Command<LocationDetailDtoModel>(model =>
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

                Dispatcher.Dispatch(() => Locations!.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new LocationDetailPage(model, inLocations.FirstOrDefault(item => item.Id == model.Id)?.FeatureImageCreateRequest ?? null));
        });

        #endregion

        #region Images

        DeleteImageCommand = new Command<ImageListItemViewModel>(item =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var model in inImages)
                {
                    if (model.Id != item.Id) continue;

                    inImages.Remove(inImages.First(_item => _item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outImageIds.Add(item.Id);
                }

                Dispatcher.Dispatch(() => Images!.Remove(item));

                hasChangesFlag = true;
            });
        });

        #endregion

        #endregion

        OwnerId = ownerId;

        Id = model?.Id;

        title = model?.Title ?? null!;
        at = model?.At ?? DateTime.Now;
        description = model?.Description;

        Locations = [.. model?.Locations ?? []];
        Images = [.. model?.Images.Select(item => new ImageListItemViewModel(item.Id, item.ToImageSource())) ?? []];
    }

    public override IValidationContext? ValidationContext => new ValidationContext<SocialResponsabilityActionConfigurationPageModel>(this);

    protected override Task<SRLSocialResponsabilityActionDetailDtoModel> PerformCreationAsync()
    {
        SRLSocialResponsabilityActionCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new SRLSocialResponsabilityActionCreateRequestModel
            (
                OwnerId,
                title,
                at,
                [.. inLocations],
                [.. linkLocationIds],
                [.. inImages],
                demand?.Id,
                Description
            ));
    }

    protected override Task<SRLSocialResponsabilityActionDetailDtoModel> PerformEditionAsync()
    {
        SRLSocialResponsabilityActionCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new SRLSocialResponsabilityActionUpdateRequestModel
            (
                Id!.Value,
                title,
                at,
                [.. inLocations],
                [.. linkLocationIds],
                [.. unlinkLocationIds],
                [.. inImages],
                [.. outImageIds],
                demand?.Id,
                Description
            ));
    }

    public Guid? Id { get; set; }

    public Guid OwnerId { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public DateTime At { get => at; set => SetProperty(ref at, value); }

    public SocialSupportDemandBasicDtoModel? Demand { get => demand; set => SetProperty(ref demand, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<LocationDetailDtoModel> Locations { get; init; }

    public ICommand AddLocationCommand { get; init; }

    public ICommand DeleteLocationCommand { get; init; }

    public ICommand DetailLocationCommand { get; init; }

    public ObservableCollection<ImageListItemViewModel> Images { get; init; }

    public ICommand DeleteImageCommand { get; init; }

    private void LocationCreateSuccess_Callback(LocationUpdateRequestModel model)
    {
        inLocations.Add(new LocationCreateRequestModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, model.FeatureImageCreateRequest, model.Description));

        // TODO Order list !!!
        Locations.Add(new LocationDetailDtoModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, null, model.Description));

        hasChangesFlag = true;
    }

    private void LocationPicked_Callback(LocationDetailDtoModel model)
    {
        linkLocationIds.Add(model.Id);

        // TODO Order list !!!
        Locations.Add(model);

        hasChangesFlag = true;
    }

    public void ImagePickSuccess_Callback(ImageCreateRequestModel model)
    {
        inImages.Add(model);

        Images.Add(new ImageListItemViewModel(model.Id, model.ToImageSource()));

        hasChangesFlag = true;
    }
}
