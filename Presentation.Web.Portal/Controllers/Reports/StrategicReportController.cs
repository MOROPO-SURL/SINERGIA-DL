using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Models.View.Tree;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Controllers.Reports;

[Route("report/strategic")]
public class StrategicReportController : Controller
{
    private readonly IHtmlToPdfServicePort htmlToPdfService;
    private readonly IViewRenderServicePort viewRenderService;
    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicReportController(
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
                "~/Views/StrategicReport/Index.cshtml",
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

    private async Task<StrategicReportViewModel> BuildViewModelAsync()
    {
        StrategicAxeQueryApiClient axeQueryApiClient = new(httpClientProvider);
        StrategicLineQueryApiClient lineQueryApiClient = new(httpClientProvider);
        StrategicProgramQueryApiClient programQueryApiClient = new(httpClientProvider);
        StrategicProjectIdeaQueryApiClient strategicProjectIdeaApiClient = new(httpClientProvider);
        StrategicProjectQueryApiClient projectQueryApiClient = new(httpClientProvider);

        StrategicAxeDetailDtoModel[] axes = await axeQueryApiClient.GetAllAsync();
        StrategicLineDetailDtoModel[] lines = await lineQueryApiClient.GetAllAsync();
        StrategicProgramDetailDtoModel[] programs = await programQueryApiClient.GetAllAsync();
        StrategicProjectIdeaDetailDtoModel[] ideas = await strategicProjectIdeaApiClient.GetAllAsync();
        StrategicProjectDetailDtoModel[] projects = await projectQueryApiClient.GetAllAsync();

        StrategicLineDetailDtoModel[] axedlines = [.. lines.Where(item => item.Axe != null)];
        StrategicLineDetailDtoModel[] nonaxedlines = [.. lines.Where(item => item.Axe == null)];

        List<LineTreeViewModel> lineTrees = [];

        foreach (StrategicAxeDetailDtoModel axe in axes)
        {
            StrategicLineDetailDtoModel[] axeLines = [.. axedlines.Where(item => item.Axe!.Id == axe.Id)];            

            foreach (StrategicLineDetailDtoModel line in axeLines)
            {
                StrategicProgramDetailDtoModel[] linePrograms = [.. programs.Where(item => item.Line.Id == line.Id)];

                List<ProgramTreeViewModel> programTrees = [];

                foreach (StrategicProgramDetailDtoModel program in programs)
                {
                    programTrees.Add(new ProgramTreeViewModel(program, [.. ideas.Where(item => item.Program.Id == program.Id)], [.. projects.Where(item => item.Program.Id == program.Id)]));
                }

                lineTrees.Add(new LineTreeViewModel(line, [.. programTrees]));
            }

            foreach (StrategicLineDetailDtoModel line in nonaxedlines)
            {
                StrategicProgramDetailDtoModel[] linePrograms = [.. programs.Where(item => item.Line.Id == line.Id)];

                List<ProgramTreeViewModel> programTrees = [];

                foreach (StrategicProgramDetailDtoModel program in programs)
                {
                    programTrees.Add(new ProgramTreeViewModel(program, [.. ideas.Where(item => item.Program.Id == program.Id)], [.. projects.Where(item => item.Program.Id == program.Id)]));
                }

                lineTrees.Add(new LineTreeViewModel(line, [.. programTrees]));
            }
        }

        return new StrategicReportViewModel([.. lineTrees]);
    }
}
