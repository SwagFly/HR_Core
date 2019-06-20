using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

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
    }
}
