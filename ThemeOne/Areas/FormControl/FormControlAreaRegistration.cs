using System.Web.Mvc;

namespace ThemeOne.Areas.FormControl
{
    public class FormControlAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FormControl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FormControl_default",
                "FormControl/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
