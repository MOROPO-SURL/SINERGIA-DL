using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Filters.Action.Attributes;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("[area]/[controller]")]
[Area("management")]
public class DashboardController : Controller
{
    [ChangePasswordRequiredActionFilter]
    public IActionResult Index()
    {
        return View();
    }
}
