using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Configuration;

public sealed class SocialSupportDemandConfigurationPageModel : AbstractConfigurationPageModel<SocialSupportDemandDetailDtoModel, SocialSupportDemandDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string EndAtValidableProperty => nameof(EndAt);
    public static string LocationsValidableProperty => nameof(Locations);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title;
    private int priority;
    bool hasStartAt;
    DateTime startAt;
    bool hasEndAt;
    DateTime endAt;
    private string? description;

    private readonly List<LocationCreateRequestModel> inLocations = [];
    private readonly List<Guid> linkLocationIds = [];
    private readonly List<Guid> unlinkLocationIds = [];

    private readonly List<ImageCreateRequestModel> inImages = [];
    private readonly List<Guid> outImageIds = [];

    public SocialSupportDemandConfigurationPageModel(SocialSupportDemandDetailDtoModel? model, Action<SocialSupportDemandDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        #region Commands

        #region Locations

        AddLocationCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new LocationPickPage(LocationPicked_Callback, LocationCreateSuccess_Callback)));
        });

        //UpdateLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        //{
        //    LocationUpdateRequestModel? updateModel = null;

        //    bool handled = false;

        //    foreach (var item in inLocations)
        //    {
        //        if (item.Id != model.Id) continue;

        //        LocationCreateRequestModel createModel = inLocations.First(item => item.Id == model.Id);

        //        updateModel = new LocationUpdateRequestModel(createModel.Id, createModel.Name, createModel.Coordinate, createModel.PostalAddress, createModel.FeatureImageCreateRequest, createModel.Description);

        //        handled = true;

        //        break;
        //    }

        //    if (!handled)
        //    {
        //        foreach (var item in patchLocations)
        //        {
        //            if (item.Id != model.Id) continue;

        //            updateModel = patchLocations.First(item => item.Id == model.Id);

        //            handled = true;

        //            break;
        //        }
        //    }

        //    if (!handled)
        //    {
        //        updateModel = new(model.Id, model.Name, model.Coordinate, model.PostalAddress, null, model.Description);
        //    }

        //    await Application.Current!.MainPage!.NavigationPushPageAsync(new LocationConfigurationPage(new LocationConfigurationPageModel(updateModel, LocationUpdateSuccess_Callback, new SocialSupportDemandLocationConfigurationValidator())));
        //});

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

        Id = model?.Id;

        title = model?.Title ?? null!;
        priority = model?.Priority ?? 1;
        hasStartAt = model?.StartAt != null;
        startAt = model?.StartAt ?? DateTime.Today;
        hasEndAt = model?.EndAt != null;
        endAt = model?.EndAt ?? DateTime.Today.AddMonths(1);
        description = model?.Description;

        Locations = [.. model?.Locations ?? []];
        Images = [.. model?.Images.Select(item => new ImageListItemViewModel(item.Id, item.ToImageSource())) ?? []];
    }

    public Guid? Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public bool HasStartAt { get => hasStartAt; set => SetProperty(ref hasStartAt, value); }

    public DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

    public bool HasEndAt { get => hasEndAt; set => SetProperty(ref hasEndAt, value); }

    public DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<LocationDetailDtoModel> Locations { get; init; }

    public ICommand AddLocationCommand { get; init; }

    //public ICommand UpdateLocationCommand { get; init; }

    public ICommand DeleteLocationCommand { get; init; }

    public ICommand DetailLocationCommand { get; init; }

    public ObservableCollection<ImageListItemViewModel> Images { get; init; }

    public ICommand DeleteImageCommand { get; init; }

    public override IValidationContext? ValidationContext => new ValidationContext<SocialSupportDemandConfigurationPageModel>(this);

    protected override Task<SocialSupportDemandDetailDtoModel> PerformCreationAsync()
    {
        SocialSupportDemandCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new SocialSupportDemandCreateRequestModel
            (
                Guid.NewGuid(),
                title,
                priority,
                true,
                [.. inLocations],
                [.. linkLocationIds],
                [.. inImages],
                hasStartAt ? startAt : null,
                hasEndAt ? endAt : null,
                description
            ));
    }

    protected override Task<SocialSupportDemandDetailDtoModel> PerformEditionAsync()
    {
        SocialSupportDemandCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new SocialSupportDemandUpdateRequestModel
            (
                Id!.Value,
                title,
                priority,
                true,
                [.. inLocations],
                [.. linkLocationIds],
                [.. unlinkLocationIds],
                [.. inImages],
                [.. outImageIds],
                hasStartAt ? startAt : null,
                hasEndAt ? endAt : null,
                description
            ));
    }

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

    //private void LocationUpdateSuccess_Callback(LocationUpdateRequestModel model)
    //{
    //    bool handled = false;

    //    foreach (var item in inLocations)
    //    {
    //        if (item.Id != model.Id) continue;

    //        inLocations.Remove(item);

    //        inLocations.Add(new LocationCreateRequestModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, model.FeatureImageCreateRequest, model.Description));

    //        handled = true;

    //        break;
    //    }

    //    if (!handled)
    //    {
    //        foreach (var item in patchLocations)
    //        {
    //            if (item.Id != model.Id) continue;

    //            patchLocations.Remove(item);

    //            patchLocations.Add(new LocationUpdateRequestModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, model.FeatureImageCreateRequest, model.Description));

    //            handled = true;

    //            break;
    //        }
    //    }

    //    if (!handled)
    //    {
    //        patchLocations.Add(new LocationUpdateRequestModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, model.FeatureImageCreateRequest, model.Description));
    //    }

    //    var index = -1;

    //    // TODO Order list !!!
    //    foreach (var item in Locations)
    //    {
    //        index++;

    //        if (item.Id != model.Id) continue;

    //        Locations[index] = new LocationDetailDtoModel(model.Id, model.Name, model.Coordinate, model.PostalAddress, null, model.Description);

    //        break;
    //    }

    //    hasChangesFlag = true;
    //}

    public void ImagePickSuccess_Callback(ImageCreateRequestModel model)
    {
        inImages.Add(model);

        Images.Add(new ImageListItemViewModel(model.Id, model.ToImageSource()));

        hasChangesFlag = true;
    }
}
