using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Linq.Expressions;

namespace Dao
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class PermissionDao:DaoBase<Permission>,PermissionIDao
    {
    }
}
