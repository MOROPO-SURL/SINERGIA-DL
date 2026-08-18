using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.UI.Maui;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Views;

public partial class DevelopmentEcosystemMapWrapperView : ContentView
{
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

        mapView.Map.HomeIsCalledOnce = true;

        mapView.Map.Navigator.CenterOnAndZoomTo(SphericalMercator.FromLonLat(-77.917516107770112, 21.382514975314585).ToMPoint(), 20);

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

        MapContentView.Content = mapView;

        ReloadDataLayers();
    }

    private void Map_Info(object? s, MapInfoEventArgs args)
    {
        if (args.MapInfo?.Feature == null) return;

        if (args.MapInfo!.Style is Mapsui.Styles.CalloutStyle)
        {
            if (args.MapInfo.Feature[nameof(SRLDevelopmentActorProfileDetailDtoModel)] is SRLDevelopmentActorProfileDetailDtoModel srlProfile)
            {
                Application.Current!.MainPage!.NavigationPushModalPageAsync(new Pages.DevelopmentActorProfile.SRLDevelopmentActorProfileOverviewPage(new Models.Page.DevelopmentActorProfile.SRLDevelopmentActorProfileOverviewDetailPageModel(srlProfile)));

                return;
            }
            
            if (args.MapInfo.Feature[nameof(LegalOwnedPDLDevelopmentActorProfileDetailDtoModel)] is LegalOwnedPDLDevelopmentActorProfileDetailDtoModel legalPdlProfile)
            {
                Application.Current!.MainPage!.NavigationPushModalPageAsync(new Pages.DevelopmentActorProfile.LegalOwnedPDLDevelopmentActorProfileOverviewPage(new Models.Page.DevelopmentActorProfile.LegalOwnedPDLDevelopmentActorProfileOverviewDetailPageModel(legalPdlProfile)));

                return;
            }

            if (args.MapInfo.Feature[nameof(NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel)] is NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel naturalPdlProfile)
            {
                Application.Current!.MainPage!.NavigationPushModalPageAsync(new Pages.DevelopmentActorProfile.NaturalOwnedPDLDevelopmentActorProfileOverviewPage(new Models.Page.DevelopmentActorProfile.NaturalOwnedPDLDevelopmentActorProfileOverviewDetailPageModel(naturalPdlProfile)));

                return;
            }
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
        IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        SRLDevelopmentActorProfilesQueryApiClient srlDevelopmentActorProfileApiClient = new(httpClientProvider);
        NaturalOwnedPDLDevelopmentActorProfilesQueryApiClient naturalOwnedPDLDevelopmentActorProfileApiClient = new(httpClientProvider);
        LegalOwnedPDLDevelopmentActorProfilesQueryApiClient legalOwnedPDLDevelopmentActorProfileApiClient = new(httpClientProvider);

        Task<SRLDevelopmentActorProfileDetailDtoModel[]> listSrlTask = srlDevelopmentActorProfileApiClient.GetAllAsync();
        Task<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel[]> listNaturalPDLTask = naturalOwnedPDLDevelopmentActorProfileApiClient.GetAllAsync();
        Task<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel[]> listLegalPDLTask = legalOwnedPDLDevelopmentActorProfileApiClient.GetAllAsync();

        Task.WhenAll(listSrlTask, listNaturalPDLTask, listLegalPDLTask).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() => MapFallbackOverviewGrid.IsVisible = !task.IsCompletedSuccessfully);

            MapView mapView = (MapView)MapContentView.Content;

            mapView.Map.Layers.Add(BuildSRLsLayer(listSrlTask.Result));
            mapView.Map.Layers.Add(BuildPDLsLayer(listNaturalPDLTask.Result, listLegalPDLTask.Result));
        });
    }

    private MemoryLayer BuildSRLsLayer(SRLDevelopmentActorProfileDetailDtoModel[] srls)
    {
        List<IFeature> features = [];

        Mapsui.Styles.Color pinColor = Mapsui.Styles.Color.Blue;

        foreach (SRLDevelopmentActorProfileDetailDtoModel srl in srls)
        {
            PointFeature mainLocationPointFeature = new(SphericalMercator.FromLonLat(srl.MainLocation.Coordinate.Longitude, srl.MainLocation.Coordinate.Latitude).ToMPoint());

            mainLocationPointFeature[nameof(SRLDevelopmentActorProfileDetailDtoModel)] = srl;

            mainLocationPointFeature.Styles.Add(Mapsui.Styles.SymbolStyles.CreatePinStyle(pinColor, 0.6));
            mainLocationPointFeature.Styles.Add(new Mapsui.Styles.CalloutStyle
            {
                Title = srl.Owner.Name,
                TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                TitleFontColor = Mapsui.Styles.Color.Black,
                TitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                Subtitle = srl.MainLocation.Name,
                SubtitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                SubtitleFontColor = Mapsui.Styles.Color.Gray,
                SubtitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                MaxWidth = 180,
                Type = Mapsui.Styles.CalloutType.Detail,
                RectRadius = 8,
                ShadowWidth = 4,
                Enabled = false,
                SymbolOffset = new Mapsui.Styles.Offset(0, Mapsui.Styles.SymbolStyle.DefaultHeight * 1f)
            });

            features.Add(mainLocationPointFeature);

            foreach (LocationDetailDtoModel item in srl.CommercialLocations)
            {
                PointFeature commercialLocationPointFeature = new(SphericalMercator.FromLonLat(item.Coordinate.Longitude, item.Coordinate.Latitude).ToMPoint());

                commercialLocationPointFeature[nameof(SRLDevelopmentActorProfileDetailDtoModel)] = srl;

                commercialLocationPointFeature.Styles.Add(Mapsui.Styles.SymbolStyles.CreatePinStyle(pinColor, 0.6));
                commercialLocationPointFeature.Styles.Add(new Mapsui.Styles.CalloutStyle
                {
                    Title = srl.Owner.Name,
                    TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                    TitleFontColor = Mapsui.Styles.Color.Black,
                    TitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                    Subtitle = item.Name,
                    SubtitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                    SubtitleFontColor = Mapsui.Styles.Color.Gray,
                    SubtitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                    MaxWidth = 180,
                    Type = Mapsui.Styles.CalloutType.Detail,
                    RectRadius = 8,
                    ShadowWidth = 4,
                    Enabled = false,
                    SymbolOffset = new Mapsui.Styles.Offset(0, Mapsui.Styles.SymbolStyle.DefaultHeight * 1f)
                });

                features.Add(commercialLocationPointFeature);
            }
        }

        return new()
        {
            Name = "SRLs",
            IsMapInfoLayer = true,
            Style = null,
            Features = features
        };
    }

    private MemoryLayer BuildPDLsLayer(NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel[] naturalPDLs, LegalOwnedPDLDevelopmentActorProfileDetailDtoModel[] legalPDLs)
    {
        List<IFeature> features = [];

        Mapsui.Styles.Color pinColor = Mapsui.Styles.Color.Green;

        foreach (NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel pdl in naturalPDLs)
        {
            PointFeature mainLocationPointFeature = new(SphericalMercator.FromLonLat(pdl.MainLocation.Coordinate.Longitude, pdl.MainLocation.Coordinate.Latitude).ToMPoint());

            mainLocationPointFeature[nameof(NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel)] = pdl;

            mainLocationPointFeature.Styles.Add(Mapsui.Styles.SymbolStyles.CreatePinStyle(pinColor, 0.6));
            mainLocationPointFeature.Styles.Add(new Mapsui.Styles.CalloutStyle
            {
                Title = pdl.Owner.Name,
                TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                TitleFontColor = Mapsui.Styles.Color.Black,
                TitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                Subtitle = pdl.MainLocation.Name,
                SubtitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                SubtitleFontColor = Mapsui.Styles.Color.Gray,
                SubtitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                MaxWidth = 180,
                Type = Mapsui.Styles.CalloutType.Detail,
                RectRadius = 8,
                ShadowWidth = 4,
                Enabled = false,
                SymbolOffset = new Mapsui.Styles.Offset(0, Mapsui.Styles.SymbolStyle.DefaultHeight * 1f)
            });

            features.Add(mainLocationPointFeature);

            foreach (LocationDetailDtoModel item in pdl.CommercialLocations)
            {
                PointFeature commercialLocationPointFeature = new(SphericalMercator.FromLonLat(item.Coordinate.Longitude, item.Coordinate.Latitude).ToMPoint());

                commercialLocationPointFeature[nameof(NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel)] = pdl;

                commercialLocationPointFeature.Styles.Add(Mapsui.Styles.SymbolStyles.CreatePinStyle(pinColor, 0.6));
                commercialLocationPointFeature.Styles.Add(new Mapsui.Styles.CalloutStyle
                {
                    Title = pdl.Owner.Name,
                    TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                    TitleFontColor = Mapsui.Styles.Color.Black,
                    TitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                    Subtitle = item.Name,
                    SubtitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                    SubtitleFontColor = Mapsui.Styles.Color.Gray,
                    SubtitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                    MaxWidth = 180,
                    Type = Mapsui.Styles.CalloutType.Detail,
                    RectRadius = 8,
                    ShadowWidth = 4,
                    Enabled = false,
                    SymbolOffset = new Mapsui.Styles.Offset(0, Mapsui.Styles.SymbolStyle.DefaultHeight * 1f)
                });

                features.Add(commercialLocationPointFeature);
            }
        }

        foreach (LegalOwnedPDLDevelopmentActorProfileDetailDtoModel pdl in legalPDLs)
        {
            PointFeature mainLocationPointFeature = new(SphericalMercator.FromLonLat(pdl.MainLocation.Coordinate.Longitude, pdl.MainLocation.Coordinate.Latitude).ToMPoint());

            mainLocationPointFeature[nameof(LegalOwnedPDLDevelopmentActorProfileDetailDtoModel)] = pdl;

            mainLocationPointFeature.Styles.Add(Mapsui.Styles.SymbolStyles.CreatePinStyle(pinColor, 0.6));
            mainLocationPointFeature.Styles.Add(new Mapsui.Styles.CalloutStyle
            {
                Title = pdl.Owner.Name,
                TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                TitleFontColor = Mapsui.Styles.Color.Black,
                TitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                Subtitle = pdl.MainLocation.Name,
                SubtitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                SubtitleFontColor = Mapsui.Styles.Color.Gray,
                SubtitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                MaxWidth = 180,
                Type = Mapsui.Styles.CalloutType.Detail,
                RectRadius = 8,
                ShadowWidth = 4,
                Enabled = false,
                SymbolOffset = new Mapsui.Styles.Offset(0, Mapsui.Styles.SymbolStyle.DefaultHeight * 1f)
            });

            features.Add(mainLocationPointFeature);

            foreach (LocationDetailDtoModel item in pdl.CommercialLocations)
            {
                PointFeature commercialLocationPointFeature = new(SphericalMercator.FromLonLat(item.Coordinate.Longitude, item.Coordinate.Latitude).ToMPoint());

                commercialLocationPointFeature[nameof(LegalOwnedPDLDevelopmentActorProfileDetailDtoModel)] = pdl;

                commercialLocationPointFeature.Styles.Add(Mapsui.Styles.SymbolStyles.CreatePinStyle(pinColor, 0.6));
                commercialLocationPointFeature.Styles.Add(new Mapsui.Styles.CalloutStyle
                {
                    Title = pdl.Owner.Name,
                    TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                    TitleFontColor = Mapsui.Styles.Color.Black,
                    TitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                    Subtitle = item.Name,
                    SubtitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                    SubtitleFontColor = Mapsui.Styles.Color.Gray,
                    SubtitleTextAlignment = Mapsui.Widgets.Alignment.Center,
                    MaxWidth = 180,
                    Type = Mapsui.Styles.CalloutType.Detail,
                    RectRadius = 8,
                    ShadowWidth = 4,
                    Enabled = false,
                    SymbolOffset = new Mapsui.Styles.Offset(0, Mapsui.Styles.SymbolStyle.DefaultHeight * 1f)
                });

                features.Add(commercialLocationPointFeature);
            }
        }

        return new()
        {
            Name = "PDLs",
            IsMapInfoLayer = true,
            Style = null,
            Features = features
        };
    }
}