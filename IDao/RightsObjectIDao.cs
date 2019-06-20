using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 页面IDao
    /// </summary>
    public interface RightsObjectIDao
    {
        /// <summary>
        /// 查询权限下的所有网页
        /// </summary>
        /// <param name="adminRoleId"></param>
        /// <param name="fatherId"></param>
        /// <returns></returns>
        List<RightsObject> GetRoleResult(int adminRoleId, int fatherId);
    }
}
