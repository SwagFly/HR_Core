using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Linq.Expressions;

namespace IBll
{
    /// <summary>
    /// 权限详细表
    /// </summary>
    public interface RoleIBLL
    {
        //查询全部管理员
        List<Role> SelectAll();
        //DataTable SelectRoleAll();
        List<Role> PageData<K>(Expression<Func<Role, K>> order, Expression<Func<Role, bool>> where, PageModel page);
        //删除角色
        int Deletes(Role role);
        /*
        用户表添加
         */
        int Insert(Role ro);
        //根据条件查询
        List<Role> SelectWhere(Expression<Func<Role, bool>> where);
        //修改用户
        int Updates(Role ro);
    }
}
