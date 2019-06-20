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
    /// 考试答题登记表
    /// </summary>
    public class engage_answerBLL: engage_answerIBLL
    {
        private static engage_answerIDao dao = IocType.GetIocType<engage_answerDao>("engage_answerDao", "engage_answerDao");
    }
}
