using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
namespace Dao
{
    public class checkedsDao : DaoBase<vw_checked>,checkedsIDao
    {
        public List<vw_checked> SelectRolesByrid(int rid, int fid)
        {
            string sql = string.Format(@"select id,[text],[state],case
	            when p.roid is null then 0
	            else 1
	            end as checked
            from dbo.RightsObject ro
            left join(select roid from dbo.Permission where rid={0}) p on p.roid=ro.id where fid={1}", rid, fid);
            return SelectSQL(sql);
        }
    }
}
