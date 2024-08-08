using Microsoft.AspNetCore.Mvc;

namespace _2024_25_Süper_Lig_Kit.WebUI.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
