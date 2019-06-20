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
    /// 薪酬标准单详细信息表
    /// </summary>
    public class salary_standard_detailsBLL: salary_standard_detailsIBLL
    {
        private static salary_standard_detailsIDao dao = IocType.GetIocType<salary_standard_detailsDao>("salary_standard_detailsDao", "salary_standard_detailsDao");
    }
}
