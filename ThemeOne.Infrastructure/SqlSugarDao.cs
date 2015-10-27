using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using SyntacticSugar;
namespace ThemeOne.Infrastructure
{
    public class SugarDao : IDisposable
    {

        public SqlSugarClient db;

        //禁止实例化
        public SugarDao()
        {
            string connection = ConfigSugar.GetConfigString("connstring"); //这里可以动态根据cookies或session实现多库切换
            this.db = new SqlSugarClient(connection);
        }


        void IDisposable.Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}
