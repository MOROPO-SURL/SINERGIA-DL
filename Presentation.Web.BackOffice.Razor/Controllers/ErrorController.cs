using Microsoft.AspNetCore.Mvc;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers;

[Route("[controller]")]
public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        this.logger = logger;
    }

    public IActionResult Exception()
    {
        var feature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

        if (feature != null)
        {
            logger.LogError(feature.Error, "Unexpected error handled!");
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [Route("403")]
    public IActionResult Forbidden()
    {
        Response.Clear();

        Response.StatusCode = StatusCodes.Status403Forbidden;

        return View();
    }

    [Route("404")]
    public IActionResult NotPageFound()
    {
        Response.Clear();

        Response.StatusCode = StatusCodes.Status404NotFound;

        return View();
    }

    [Route("500")]
    public IActionResult InternalFailure()
    {
        Response.Clear();

        Response.StatusCode = StatusCodes.Status500InternalServerError;

        return View();
    }

    [Route("{code}")]
    public IActionResult Index(int code)
    {
        Response.Clear();
        Response.StatusCode = code;

        return View();
    }
}
