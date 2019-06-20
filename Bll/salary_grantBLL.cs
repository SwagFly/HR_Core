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
    /// 薪酬发放登记表
    /// </summary>
    public class salary_grantBLL: salary_grantIBLL
    {
        private static salary_grantIDao dao = IocType.GetIocType<salary_grantDao>("salary_grantDao", "salary_grantDao");
    }
}
