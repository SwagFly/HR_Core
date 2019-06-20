using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;

namespace Dao
{
    /// <summary>
    /// 页面
    /// </summary>
    public class RightsObjectDao:DaoBase<RightsObject>,RightsObjectIDao
    {
        /// <summary>
        /// 查询权限下的所有网页
        /// </summary>
        /// <param name="adminRoleId"></param>
        /// <param name="fatherId"></param>
        /// <returns></returns>
        public List<RightsObject> GetRoleResult(int adminRoleId,int fatherId) {
            string sql = string.Format(@"select * from [dbo].[RightsObject] as treeObj
                        inner join (select [roid] from [dbo].[Permission] where rid='{0}') as treeAnd
                        on treeObj.id=treeAnd.roid
                        where treeObj.fid='{1}'",adminRoleId,fatherId);
            return SelectSQL(sql);
        }


    }
}
