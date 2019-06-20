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
namespace Bll
{
    /// <summary>
    /// 权限详细表
    /// </summary>
    public class RoleBLL : RoleIBLL
    {
        RoleIDao role = IocType.GetIocType<RoleDao>("RoleDao", "RoleDao");
        public List<Role> SelectAll()
        {
            return role.SelectAll();
        }
    }
}
