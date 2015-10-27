using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThemeOne.Infrastructure;
using SqlSugar;
using SyntacticSugar;
namespace Demo
{
    /// <summary>
    /// 用于创建实体的DEMO,可以自已实现
    /// </summary>
    public partial class BuilderClass : System.Web.UI.Page
    {

        public BuilderClass()
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string connection = ConfigSugar.GetConfigString("connstring"); //这里可以动态根据cookies或session实现多库切换
            var db = new SqlSugarClient(connection); ;
            db.ClassGenerating.CreateClassFiles(db, txtPath.Text, txtNS.Text);
            db.Dispose();
            //还有其它方法我这边只是最简单的
            //db.ClassGenerating.CreateClassFilesByTableNames  
            //db.ClassGenerating....
        }

        protected void btnCreateClassCode_Click(object sender, EventArgs e)
        {
            string connection = ConfigSugar.GetConfigString("connstring"); //这里可以动态根据cookies或session实现多库切换
            var db = new SqlSugarClient(connection); 
            txtResult.Value = db.ClassGenerating.SqlToClass(db, txtSql.Text, txtClassName.Text);
            db.Dispose();
        }




    }
}