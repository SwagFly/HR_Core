using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IOC;
using IBll;
using Dao;
using IDao;
namespace Bll
{
    public class checkedsBll : checkedsIBll
    {
        checkedsIDao che = IocType.GetIocType<checkedsDao>("checkedsDao", "checkedsDao");
        public List<vw_checked> SelectRolesByrid(int rid, int fid)
        {
            return che.SelectRolesByrid(rid, fid);
        }
    }
}
