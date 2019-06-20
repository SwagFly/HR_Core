using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC;
using Dao;
using IDao;
using IBll;
using Models;
using System.Linq.Expressions;

namespace Bll
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UsersBLL:UsersIBll
    {
        private static UsersIDao dao = IocType.GetIocType<UserDao>("UserDao", "UserDao");

        public int Insert(users us)
        {
            return dao.Insert(us);
        }

        /// <summary>
        /// 查询登录信息
        /// </summary>
        /// <param name="user">登录者的账户密码</param>
        /// <returns>单个登录者信息</returns>
        public users Login(users user)
        {
            Expression<Func<users, bool>> where = (e => e.u_name.Equals(user.u_name)&&e.u_password.Equals(user.u_password));
            return dao.Login(where);
        }
    }
}
