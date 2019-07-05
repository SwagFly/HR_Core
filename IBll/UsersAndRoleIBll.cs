using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IBll
{
    public interface UsersAndRoleIBll
    {
        //分页查询
        List<vw_usersAndRole> PageData<K>(Expression<Func<vw_usersAndRole, K>> order, Expression<Func<vw_usersAndRole, bool>> where, PageModel page);
        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<vw_usersAndRole> SelectWhere(Expression<Func<vw_usersAndRole, bool>> where);
    }
}
