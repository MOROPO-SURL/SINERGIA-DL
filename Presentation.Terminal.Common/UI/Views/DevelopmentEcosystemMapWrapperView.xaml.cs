using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.UI.Maui;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Views;

public partial class DevelopmentEcosystemMapWrapperView : ContentView
{
    private MemoryLayer srlLayer;

	public DevelopmentEcosystemMapWrapperView()
	{
		InitializeComponent();
	}

    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (MapContentView.Content != null) return;

        MapView mapView = new()
        {
            IsMyLocationButtonVisible = false
        };

        mapView.Info += Map_Info;

        mapView.Map.Widgets.Enqueue(new Mapsui.Widgets.ScaleBar.ScaleBarWidget(mapView.Map)
        {
            TextAlignment = Mapsui.Widgets.Alignment.Center,
            HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left,
            VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom
        });

        mapView.Map.Layers.Add(new Mapsui.Tiling.Layers.TileLayer(BruTile.Predefined.KnownTileSources.Create(BruTile.Predefined.KnownTileSource.OpenStreetMap))
        {
            Name = "Base"
        });

        mapView.Map.Home = map => map.CenterOnAndZoomTo(SphericalMercator.FromLonLat(-77.917516107770112, 21.382514975314585).ToMPoint(), map.Resolutions[12]);

        MapContentView.Content = mapView;

        ReloadDataLayers();
    }

    private void Map_Info(object? s, MapInfoEventArgs args)
    {
        if (args.MapInfo?.Feature == null) return;

        if (args.MapInfo!.Style is Mapsui.Styles.CalloutStyle)
        {
            Application.Current!.MainPage!.NavigationPushModalPageAsync(new Pages.DevelopmentActorProfile.SRLDevelopmentActorProfileOverviewPage(new Models.Page.DevelopmentActorProfile.SRLDevelopmentActorProfileOverviewDetailPageModel((SRLDevelopmentActorProfileDetailDtoModel)args.MapInfo!.Feature[nameof(SRLDevelopmentActorProfileDetailDtoModel)]!)));
        }
        else
        {
            Mapsui.Styles.IStyle calloutStyle = args.MapInfo!.Feature?.Styles.ElementAtOrDefault(1)!;

            calloutStyle!.Enabled = !calloutStyle.Enabled;

            args.MapInfo.Layer?.DataHasChanged();

            args.Handled = true;
        }
    }

    public void ReloadDataLayers()
    {
        SRLDevelopmentActorProfilesQueryApiClient srlDevelopmentActorProfileApiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        var listSrlTask = srlDevelopmentActorProfileApiClient.GetAllAsync();

        srlDevelopmentActorProfileApiClient.GetAllAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() => MapFallbackOverviewGrid.IsVisible = !task.IsCompletedSuccessfully);

            if (srlLayer == null)
            {
                srlLayer = BuildSRLsLayer(task.Result);

                ((MapView)MapContentView.Content).Map.Layers.Add(srlLayer);
            }
        });
    }

    private MemoryLayer BuildSRLsLayer(SRLDevelopmentActorProfileDetailDtoModel[] srls)
    {
        List<IFeature> features = [];

        foreach (SRLDevelopmentActorProfileDetailDtoModel srl in srls)
        {
            PointFeature mainLocationPointFeature = new(SphericalMercator.FromLonLat(srl.MainLocation.Coordinate.Longitude, srl.MainLocation.Coordinate.Latitude).ToMPoint());

            mainLocationPointFeature[nameof(SRLDevelopmentActorProfileDetailDtoModel)] = srl;

            mainLocationPointFeature.Styles.Add(Mapsui.Styles.SymbolStyles.CreatePinStyle(Mapsui.Styles.Color.Blue, 0.6));
            mainLocationPointFeature.Styles.Add(new Mapsui.Styles.CalloutStyle
            {
                Title = srl.Owner.Name,
                TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                TitleFontColor = Mapsui.Styles.Color.Black,
                TitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                Subtitle = srl.MainLocation.Name,
                SubtitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                SubtitleFontColor = Mapsui.Styles.Color.Gray,
                MaxWidth = 180,
                Type = Mapsui.Styles.CalloutType.Detail,
                RectRadius = 8,
                ShadowWidth = 4,
                Enabled = false,
                SymbolOffset = new Mapsui.Styles.Offset(0, Mapsui.Styles.SymbolStyle.DefaultHeight * 1f)
            });

            features.Add(mainLocationPointFeature);

            //foreach (LocationDetailDtoModel item in srl.CommercialLocations)
            //{
            //    PointFeature commercialLocationPointFeature = new(SphericalMercator.FromLonLat(srl.MainLocation.Coordinate.Longitude, srl.MainLocation.Coordinate.Latitude).ToMPoint());

            //    commercialLocationPointFeature[nameof(SRLDevelopmentActorProfileDetailDtoModel)] = srl;

            //    commercialLocationPointFeature.Styles.Add(new Mapsui.Styles.SymbolStyle { BitmapId = GetType().LoadSvgId("Resources.Images.actor-srl.svg"), SymbolScale = 0.36 });

            //    features.Add(commercialLocationPointFeature);
            //}
        }

        return new()
        {
            Name = "SRLs",
            IsMapInfoLayer = true,
            Style = null,
            Features = features
        };
    }
}