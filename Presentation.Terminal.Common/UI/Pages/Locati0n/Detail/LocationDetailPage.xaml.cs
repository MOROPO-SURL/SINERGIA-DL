using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Location.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;

public partial class LocationDetailPage : BaseDetailEntityPage<LocationDetailDtoModel, LocationDetailPageModel>
{
    public LocationDetailPage(LocationDetailDtoModel model, ImageCreateRequestModel? featureImageCreateRequest = null) : base(new LocationDetailPageModel(model, featureImageCreateRequest))
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        DismissControl_Invoked(this, EventArgs.Empty);

        return true;
    }

    protected void DismissControl_Invoked(object sender, EventArgs eventArgs)
    {
        this.NavigationPopModalPageAsync();
    }

    private void GeolocalizeButton_Clicked(object sender, EventArgs eventArgs)
    {
        Location location = new(ConcreteBindingContext.Model.Coordinate.Latitude, ConcreteBindingContext.Model.Coordinate.Longitude);

        Map.Default.TryOpenAsync(location).ContinueWith(task =>
        {
            if (task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                Launcher.TryOpenAsync($"gro:{ConcreteBindingContext.Model.Coordinate.Latitude},{ConcreteBindingContext.Model.Coordinate.Longitude}").ContinueWith(_task =>
                {
                    if (_task.Result) return;

                    Dispatcher.Dispatch(() => Launcher.OpenAsync($"https://maps.google.com/maps?q=loc:{ConcreteBindingContext.Model.Coordinate.Latitude},{ConcreteBindingContext.Model.Coordinate.Longitude}"));
                });
            });
        });
    }
}