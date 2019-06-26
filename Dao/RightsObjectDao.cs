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

        public List<RightsObject> SelectNotZeroAndClosed()
        {
            string sql = string.Format(@"select * from [dbo].[RightsObject] where [fid]!=0 and [state]='open'");
            return SelectSQL(sql);
        }

        public List<RightsObject> SelectNotZeroAndOpen()
        {
            string sql = string.Format(@"select * from [dbo].[RightsObject] where [fid]!=0 and [state]='closed'");
            return SelectSQL(sql);
        }
        public List<RightsObject> SelectRolesByrid(int rid,int fid)
        {
            string sql = string.Format(@"select id,[text],[state],case
	            when p.roid is null then 0
	            else 1
	            end as checked
            from dbo.RightsObject ro
            left join(select roid from dbo.Permission where rid={0}) p on p.roid=ro.id where fid={1}", rid, fid);
            return SelectSQL(sql);
        }

        public List<RightsObject> SelectZeroAndClosed()
        {
            string sql = string.Format(@"select * from [dbo].[RightsObject] where [fid]=0 and [state]='closed'");
            return SelectSQL(sql);
        }
    }
}
