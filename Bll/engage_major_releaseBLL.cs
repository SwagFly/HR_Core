using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Models;
using Dao;
using IDao;
using IOC;
namespace Bll
{
    /// <summary>
    /// 职位发表登记
    /// </summary>
    public class engage_major_releaseBLL: engage_major_releaseIBLL
    {
        private static engage_major_releaseIDao dao = IocType.GetIocType<engage_major_releaseDao>("engage_major_releaseDao", "engage_major_releaseDao");
    }
}
