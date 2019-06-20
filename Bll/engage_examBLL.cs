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
    /// 试卷登记
    /// </summary>
    public class engage_examBLL: engage_examIBLL
    {
        private static engage_examIDao dao = IocType.GetIocType<engage_examDao>("engage_examDao", "engage_examDao");
    }
}
