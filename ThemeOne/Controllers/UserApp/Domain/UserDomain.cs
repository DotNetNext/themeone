using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThemeOne.Infrastructure;
using ThemeOne.Entities;
using SqlSugar;
using SyntacticSugar;
namespace ThemeOne.Controllers.UserApp.Domain
{
    public class UserDomain
    {
        public static bool LoginSubmit(user_info user)
        {
            using (UserInfoService us = new UserInfoService())
            {
                user.password = EncryptSugar.GetInstance().MD5(user.password);
                var isLogin= us.Login(user.user_name, user.password);
                return isLogin;
            }
        }
    }
}