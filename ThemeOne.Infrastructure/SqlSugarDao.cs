using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ThemeOne.Infrastructure
{
    public class SugarDao
    {
          //禁止实例化
      private SugarDao() {
 
      }
      public static SqlSugarClient GetInstance()
      {
          string connection = @"Server=DESKTOP-RHDNF4S\SKX;uid=sa;pwd=sasa;database=ThemeOne"; //这里可以动态根据cookies或session实现多库切换
          return new SqlSugarClient(connection);
      }
    }
}
