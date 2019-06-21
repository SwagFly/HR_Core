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
        //删除用户
        int Deletes(users us);
        //根据条件查询
        List<users> SelectWhere(Expression<Func<users, bool>> where);
        //修改用户
        int Updates(users us);
    }
}
