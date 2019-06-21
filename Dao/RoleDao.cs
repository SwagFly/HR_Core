using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Data;

namespace Dao
{
    /// <summary>
    /// 权限信息IDao
    /// </summary>
    public class RoleDao : DaoBase<Role>, RoleIDao
    {
        public int Deletes(Role role)
        {
            return Delete(role, role.rid);
        }

        public int Updates(Role ro)
        {
            return Update(ro, ro.rid);
        }
    }
}
