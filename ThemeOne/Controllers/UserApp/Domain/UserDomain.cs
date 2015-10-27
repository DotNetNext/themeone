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
        UserInfoService us;
        public UserDomain(UserInfoService us)
        {
            this.us = us;
        }

        public bool LoginSubmit(user_info user)
        {
            user.password = EncryptSugar.GetInstance().MD5(user.password);
            var isLogin = us.Login(user.user_name, user.password);
            return isLogin;
        }
    }
}