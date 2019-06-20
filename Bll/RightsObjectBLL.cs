using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IOC;
using Dao;
using IDao;
using IBll;

namespace Bll
{
    /// <summary>
    /// 页面表
    /// </summary>
    public class RightsObjectBLL: RightsObjectIBLL
    {
        private static RightsObjectIDao dao = IocType.GetIocType<RightsObjectDao>("RightsObjectDao", "RightsObjectDao");
        /// <summary>
        /// 查询权限下的所有网页
        /// </summary>
        /// <param name="adminRoleId"></param>
        /// <param name="fatherId"></param>
        /// <returns></returns>
        public List<RightsObject> GetRoleResult(int adminRoleId, int fatherId) {
            return dao.GetRoleResult(adminRoleId,fatherId);
        }
    }
}
