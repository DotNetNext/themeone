using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemeOne.Models.Filters
{
    //action过滤器
    public class ActionFilter : ActionFilterAttribute
    {
        //action执行前过滤器
        public override void  OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}