using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemeOne.Entities;
using ThemeOne.Infrastructure;
using SqlSugar;
using SyntacticSugar;
using JQWidgetsSugar;
using ThemeOne.Controllers.UserApp.Domain;
namespace ThemeOne.Controllers
{
    public class UserController : Controller
    {
        UserDomain ud;
        public UserController(UserDomain ud)
        {
            this.ud = ud;
        }

        [HttpGet]
        public ActionResult Login(string return_url)
        {
            ViewBag.ReturnUrl = (return_url == null).IIF("/", Server.UrlDecode(return_url));
            return View();
        }
        [HttpPost]
        public JsonResult LoginSubmit(user_info user)
        {
            var model = new JQWidgetsSugar.ActionResultModel<string>()
            {
                isSuccess = this.ud.LoginSubmit(user),
            };
            model.respnseInfo = model.isSuccess.IIF("操作成功！","用户名密码错误！");
            return Json(model);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("login");
        }
    }
}
