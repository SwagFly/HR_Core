using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC;
using Models;
using Dao;
using IDao;
using IBll;
using System.Linq.Expressions;

namespace Bll
{
    public class UsersAndRoleBll : UsersAndRoleIBll
    {
        UsersAndRoleIDao ur = IocType.GetIocType<UsersAndRoleDao>("UsersAndRoleDao", "UsersAndRoleDao");
        public List<vw_usersAndRole> PageData<K>(Expression<Func<vw_usersAndRole, K>> order, Expression<Func<vw_usersAndRole, bool>> where, PageModel page)
        {
            return ur.PageData(order, where, page);
        }
    }
}
