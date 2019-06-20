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
    /// 实体题库登记
    /// </summary>
    public class engage_subjectsBLL: engage_subjectsIBLL
    {
        private static engage_subjectsIDao dao = IocType.GetIocType<engage_subjectsDao>("engage_subjectsDao", "engage_subjectsDao");
    }
}
