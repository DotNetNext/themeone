using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using SyntacticSugar;
namespace ThemeOne.Infrastructure
{
    public class SugarDao
    {
          //禁止实例化
      private SugarDao() {
 
      }
      public static SqlSugarClient GetInstance()
      {
          string connection = ConfigSugar.GetConfigString("connstring"); //这里可以动态根据cookies或session实现多库切换
          return new SqlSugarClient(connection);
      }
    }
}
