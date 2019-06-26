using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IOC;
using IBll;
using IDao;
using Dao;
namespace Bll
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class PermissionBLL : PermissionIBLL
    {
        PermissionIDao dao = IocType.GetIocType<PermissionDao>("PermissionDao", "PermissionDao");
        public int Deletes(int rid)
        {
            return dao.Deletes(rid);
        }

        public int Insert(Permission per)
        {
            return dao.Insert(per);
        }
    }
}
