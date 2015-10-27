using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeOne.Entities;
using ThemeOne;
using SqlSugar;
using SyntacticSugar;
namespace ThemeOne.Infrastructure
{
    public class UserInfoService 
    {
        public const string COOKIES_KEY_LOGIN = "COOKIES_KEY_LOGIN";
        public SqlSugar.SqlSugarClient db;
        public UserInfoService(SugarDao sd)
        {
            this.db = sd.db;
        }

        public bool IsLogin()
        {
            var cm = CookiesManager<user_info>.GetInstance();
            return (cm.ContainsKey(COOKIES_KEY_LOGIN));
        }

        public bool Login(string userName, string password)
        {
            var isAny = this.db.Queryable<user_info>().Any(it => it.user_name == userName && it.password == password);
            if (isAny)
            {
                var cm = CookiesManager<user_info>.GetInstance();
                var user = this.db.Queryable<user_info>().Single(it => it.user_name == userName && it.password == password);
                cm.Add(COOKIES_KEY_LOGIN, user, cm.Day * 30);//保存30天
            }
            return isAny;
        }

        public user_info GetCurrentUser()
        {
            var cm = CookiesManager<user_info>.GetInstance();
            if (cm.ContainsKey(COOKIES_KEY_LOGIN))
            {
                return cm[COOKIES_KEY_LOGIN];
            }
            else
            {
                //抛出空引用 
                Check.ArgumentNullException(null, "UserInfoService.GetCurrentUser！");
                return null;
            }
        }
 
    }
}
