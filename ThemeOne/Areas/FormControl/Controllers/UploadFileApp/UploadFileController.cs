using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;

namespace ThemeOne.Areas.FormControl.Controllers
{
    public class UploadFileController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string UploadImg()
        {
            UploadImage ui = new UploadImage();
            ui.SetAllowSize = 1;
            ui.SetAllowFormat = ".jpeg,.jpg,.bmp,.gif,.png";//配在webConfig中
            string url = "/areas/formcontrol/views/_upload/temp/img/";
            string saveFolder = Server.MapPath(url);
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];
            var reponseMessage = ui.FileSaveAs(file, saveFolder);
            return reponseMessage.ModelToJson();
        }
        [HttpPost]
        public string UploadFile()
        {
            UploadFile ui = new UploadFile();
            ui.SetMaxSizeM(5);
            ui.SetFileType(".docx,.txt,.doc,.jpg,.gif,.xls,.xlsx");//配在webConfig中
            string saveFolder = "/areas/formcontrol/views/_upload/temp/file/";
            ui.SetFileDirectory(saveFolder);
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];
            var reponseMessage = ui.Save(file);
            return (reponseMessage).ModelToJson();
        }
    }
}
