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
    /// 薪酬基本信息
    /// </summary>
    public class salary_standardBLL: salary_standardIBLL
    {
        private static salary_standardIDao dao = IocType.GetIocType<salary_standardDao>("salary_standardDao", "salary_standardDao");
    }
}
