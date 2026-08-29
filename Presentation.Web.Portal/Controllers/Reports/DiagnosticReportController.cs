using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritoryPotential.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Controllers.Reports;

[Route("report/diagnostic")]
public class DiagnosticReportController : Controller
{
    private readonly IHtmlToPdfServicePort htmlToPdfService;
    private readonly IViewRenderServicePort viewRenderService;
    private readonly IHttpClientProviderPort httpClientProvider;

    public DiagnosticReportController(
        IViewRenderServicePort viewRenderService,
        IHtmlToPdfServicePort htmlToPdfService,
        IHttpClientProviderPort httpClientProvider)
    {
        this.htmlToPdfService = htmlToPdfService;
        this.viewRenderService = viewRenderService;
        this.httpClientProvider = httpClientProvider;
    }

    [Route("web")]
    public async Task<IActionResult> IndexAsync()
    {
        return View(await BuildViewModelAsync());
    }

    [Route("print")]
    public async Task<IActionResult> IndexAsync(long referenceTicks)
    {
        var htmlContent = await viewRenderService.RenderViewToStringAsync(
                "~/Views/DiagnosticReport/Index.cshtml",
                await BuildViewModelAsync()
            );

        // Opciones para el PDF
        var pdfOptions = new Models.Options.PdfOptionsModel
        {
            PageSize = "Letter",
            Orientation = Orientation.Portrait,
            Margins = new Models.MarginsModel { Top = 10, Right = 10, Bottom = 10, Left = 10 },
            EnableJavaScript = false,
            PrintBackground = false
        };

        // Generar PDF
        var pdfBytes = await htmlToPdfService.GeneratePdfFromHtmlAsync(htmlContent, pdfOptions);

        return File(pdfBytes, "application/pdf", $"Diagnóstico - {DateTime.Now.Ticks}.pdf");
    }

    private async Task<DiagnosticReportViewModel> BuildViewModelAsync()
    {
        FeatureQueryApiClient featureQueryApiClient = new(httpClientProvider);
        ObjectiveQueryApiClient objectiveApiClient = new(httpClientProvider);
        TerritorialBarrierQueryApiClient territorialBarrierApiClient = new(httpClientProvider);
        TerritoryPotentialQueryApiClient territoryPotentialApiClient = new(httpClientProvider);
        PublicPolicyQueryApiClient publicPolicyApiClient = new(httpClientProvider);

        FeatureDetailDtoModel[] features = await featureQueryApiClient.GetAllAsync();
        ObjectiveDetailDtoModel[] objectives = [.. (await objectiveApiClient.GetAllAsync()).OrderBy(item => item.Index)];
        TerritorialBarrierDetailDtoModel[] territorialBarriers = await territorialBarrierApiClient.GetAllAsync();
        TerritoryPotentialDetailDtoModel[] territoryPotentials = await territoryPotentialApiClient.GetAllAsync();
        PublicPolicyDetailDtoModel[] publicPolicies = await publicPolicyApiClient.GetAllAsync();

        List<PublicPolicyGroupViewModel> publicPolicyGroups =
        [
            new PublicPolicyGroupViewModel(PublicPolicyKind.National, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.National)]),
            new PublicPolicyGroupViewModel(PublicPolicyKind.Territorial, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.Territorial)]),
            new PublicPolicyGroupViewModel(PublicPolicyKind.Provincial, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.Provincial)]),
            new PublicPolicyGroupViewModel(PublicPolicyKind.Municipal, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.Municipal)])
        ];

        return new DiagnosticReportViewModel()
        {
            Features = features,
            Objectives = objectives,
            TerritorialBarriers = territorialBarriers,
            TerritoryPotentials = territoryPotentials,
            PublicPolicyGroups = [.. publicPolicyGroups]
        };
    }
}