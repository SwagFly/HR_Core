using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace IDao
{
    /// <summary>
    /// 权限信息IDao
    /// </summary>
    public interface RoleIDao
    {
        //查询全部管理员
        List<Role> SelectAll();
        //DataTable SelectRoleAll();
    }
}
