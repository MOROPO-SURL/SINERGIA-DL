using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Configuration;

public sealed class LocationConfigurationPageModel : AbstractConfigurationPageModel<LocationUpdateClippedRequestModel, LocationUpdateClippedRequestModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string PostalAddressStreetValidableProperty => nameof(PostalAddressStreet);
    public static string LatitudeCoordinateValidableProperty => nameof(LatitudeCoordinate);
    public static string LongitudeCoordinateValidableProperty => nameof(LongitudeCoordinate);
    public static string DescriptionValidableProperty => nameof(Description);

    private string name = null!;
    private float longitudeCoordinate;
    private float latitudeCoordinate;
    private string postalAddressStreet = null!;
    private string? postalAddressNumber;
    private string? postalAddressContext;
    private int? postalAddressZipCode;
    private string? description;
    private ImageSource? featureImageSource;

    private ImageCreateRequestModel? featureImagePicked;

    public LocationConfigurationPageModel(LocationUpdateClippedRequestModel? model, Action<LocationUpdateClippedRequestModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        Id = model?.Id;
        name = model?.Name ?? null!;
        longitudeCoordinate = model?.Coordinate.Longitude ?? default;
        latitudeCoordinate = model?.Coordinate.Latitude ?? default;
        postalAddressStreet = model?.PostalAddress.Street ?? null!;
        postalAddressNumber = model?.PostalAddress.Number;
        postalAddressContext = model?.PostalAddress.Context;
        postalAddressZipCode = model?.PostalAddress.ZipCode;
        description = model?.Description;
        featureImagePicked = model?.FeatureImageCreateRequest;
        featureImageSource = model?.FeatureImageCreateRequest?.ToImageSource();

        if (featureImageSource == null) return;

        featureImageSource = featureImagePicked?.ToImageSource();
    }

    public Guid? Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public float LongitudeCoordinate { get => longitudeCoordinate; set => SetProperty(ref longitudeCoordinate, value); }

    public float LatitudeCoordinate { get => latitudeCoordinate; set => SetProperty(ref latitudeCoordinate, value); }

    public string PostalAddressStreet { get => postalAddressStreet; set => SetProperty(ref postalAddressStreet, value); }

    public string? PostalAddressNumber { get => postalAddressNumber; set => SetProperty(ref postalAddressNumber, value); }

    public string? PostalAddressContext { get => postalAddressContext; set => SetProperty(ref postalAddressContext, value); }

    public int? PostalAddressZipCode { get => postalAddressZipCode; set => SetProperty(ref postalAddressZipCode, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ImageSource? FeatureImageSource { get => featureImageSource; set => SetProperty(ref featureImageSource, value); }

    protected override void DisposeUnmanagedResources()
    {
        base.DisposeUnmanagedResources();

        featureImagePicked = null;
    }

    protected override bool PresentChangeNotification => false;

    public override IValidationContext? ValidationContext => new ValidationContext<LocationConfigurationPageModel>(this);

    protected override Task<LocationUpdateClippedRequestModel> PerformCreationAsync()
    {
        return Task.FromResult(new LocationUpdateClippedRequestModel(
            Guid.NewGuid(),
            name,
            new GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs.CoordinateValueDtoModel(latitudeCoordinate, longitudeCoordinate),
            new GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs.PostalAddressDetailDtoModel(postalAddressStreet, postalAddressNumber, postalAddressContext, postalAddressZipCode),
            featureImagePicked,
            description));
    }

    protected override Task<LocationUpdateClippedRequestModel> PerformEditionAsync()
    {
        return Task.FromResult(new LocationUpdateClippedRequestModel(
            Id!.Value,
            name,
            new GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs.CoordinateValueDtoModel(latitudeCoordinate, longitudeCoordinate),
            new GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs.PostalAddressDetailDtoModel(postalAddressStreet, postalAddressNumber, postalAddressContext, postalAddressZipCode),
            featureImagePicked,
            description));
    }

    public void FeatureImagePickSuccess_Callback(ImageCreateRequestModel model)
    {
        featureImagePicked = model;

        FeatureImageSource = model.ToImageSource();

        hasChangesFlag = true;
    }
}
