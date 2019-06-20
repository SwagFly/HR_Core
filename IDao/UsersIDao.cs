using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IDao
{
    /// <summary>
    /// 用户表
    /// </summary>
    public interface UsersIDao
    {
        /// <summary>
        /// 查询登录信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        users Login(Expression<Func<users, bool>> where);
        /*
        用户表添加
         */
        int Insert(users us);
    }
}
