using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
namespace ThemeOne.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UploadImg()
        {
            UploadImage ui = new UploadImage();
            ui.SetAllowSize = 1;
            ui.SetAllowFormat = ".jpeg|.jpg|.bmp|.gif|.png";
            string url = "/views/_upload/temp/img/".ToFormat(Guid.NewGuid().ToString().Replace("-",""));
            string saveFolder = Server.MapPath(url);
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];
            var reponseMessage = ui.FileSaveAs(file, saveFolder);
            return Json(reponseMessage);
        }

    }
}
