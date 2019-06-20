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
    /// 薪酬报销分类
    /// </summary>
    public class salary_projectBLL: salary_projectIBLL
    {
        private static salary_projectIDao dao = IocType.GetIocType<salary_projectDao>("salary_projectDao", "salary_projectDao");
    }
}
