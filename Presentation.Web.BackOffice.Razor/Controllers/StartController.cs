namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers
{
    public class StartController : Microsoft.AspNetCore.Mvc.Controller
    {
        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            return RedirectToAction("index", "dashboard", new { Area = "management" });
        }
    }
}
