using Microsoft.AspNetCore.Mvc;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Components;

public class DashboardSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
