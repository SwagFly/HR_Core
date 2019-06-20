using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IDao
{
    public interface UsersAndRoleIDao
    {
        //分页查询
        List<vw_usersAndRole> PageData<K>(Expression<Func<vw_usersAndRole, K>> order, Expression<Func<vw_usersAndRole, bool>> where, PageModel page);
    }
}
