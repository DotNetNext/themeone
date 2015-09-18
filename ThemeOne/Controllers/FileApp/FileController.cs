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
        public string UploadImg()
        {
            UploadImage ui = new UploadImage();
            string url = "/views/_upload/temp/{0}.jpg".ToFormat(Guid.NewGuid());
            string savePath = Server.MapPath(url);
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];
            var reponseMessage = ui.FileSaveAs(file, savePath);
            return reponseMessage.WebPath;
        }

    }
}
