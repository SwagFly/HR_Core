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
    /// 面试
    /// </summary>
    public class engage_interviewBLL: engage_interviewIBLL
    {
        private static engage_interviewIDao dao = IocType.GetIocType<engage_interviewDao>("engage_interviewDao", "engage_interviewDao");
    }
}
