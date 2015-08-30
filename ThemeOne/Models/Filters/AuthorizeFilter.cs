using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemeOne.Models.Filters
{
    //受权过滤器
    public class AuthorizeFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext) { 
        
        }
    }
}