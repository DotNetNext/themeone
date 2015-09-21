using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using SyntacticSugar;
using System.IO;
namespace ThemeOne.Models.Filters
{
    public class Global_Application_BeginRequest
    {
        public static void Filter(HttpContext context)
        {
            var localPath = context.Request.Url.LocalPath.ToLower();
            var isViewsStaticFile = Regex.IsMatch(localPath, @"^/views/.*\.(js|css|jpg|png|gif|doc|docx|xls|xlsx|pdf|txt)$");
            var isAreaViewsStaticFile = Regex.IsMatch(localPath, @"^/areas/\w+/views/.*\.(js|css|jpg|png|gif|doc|docx|xls|xlsx|pdf|txt)$");
            if (isViewsStaticFile || isAreaViewsStaticFile)
            {
                string filePath = FileSugar.GetMapPath(localPath);
                var isExistFile = FileSugar.IsExistFile(filePath);
                if (isExistFile)
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open,FileAccess.Read))
                    {
                        long fileSize = fileStream.Length;
                        byte[] fileBuffer = new byte[fileSize];
                        fileStream.Read(fileBuffer, 0, (int)fileSize);
                        //如果不写fileStream.Close()语句，用户在下载过程中选择取消，将不能再次下载
                        fileStream.Close();
                        var fileExtension=FileSugar.GetExtension(filePath);
                        context.Response.ContentType = fileExtension.Switch().Case(".css","text/css").Case(".js","text/js").Default("application/octet-stream").Break();
                        context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileSugar.GetFileName(filePath));
                        context.Response.AddHeader("Content-Length", fileSize.ToString());
                        context.Response.BinaryWrite(fileBuffer);
                        context.Response.Flush();
                        context.Response.Close();
                        context.Response.End();
                    }
                }
            }
        }
    }
}