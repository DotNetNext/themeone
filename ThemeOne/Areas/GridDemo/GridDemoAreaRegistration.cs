using System.Web.Mvc;

namespace ThemeOne.Areas.GridDemo
{
    public class GridDemoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridDemo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridDemo_default",
                "GridDemo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
