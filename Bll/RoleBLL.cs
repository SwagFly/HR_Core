using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Models;
using Dao;
using IDao;
using IOC;
using System.Linq.Expressions;

namespace Bll
{
    /// <summary>
    /// 权限详细表
    /// </summary>
    public class RoleBLL : RoleIBLL
    {
        RoleIDao role = IocType.GetIocType<RoleDao>("RoleDao", "RoleDao");

        public int Deletes(Role ro)
        {
            return role.Deletes(ro);
        }

        public int Insert(Role ro)
        {
            return role.Insert(ro);
        }

        public List<Role> PageData<K>(Expression<Func<Role, K>> order, Expression<Func<Role, bool>> where, PageModel page)
        {
            return role.PageData(order, where, page);
        }

        public List<Role> SelectAll()
        {
            return role.SelectAll();
        }

        public List<Role> SelectWhere(Expression<Func<Role, bool>> where)
        {
            return role.SelectWhere(where);
        }

        public int Updates(Role ro)
        {
            return role.Updates(ro);
        }
    }
}
