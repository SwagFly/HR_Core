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
    /// 考试答题详细信息
    /// </summary>
    public class engage_answer_detailsBLL: engage_answer_detailsIBLL
    {
        private static engage_answer_detailsIDao dao = IocType.GetIocType<engage_answer_detailsDao>("engage_answer_detailsDao", "engage_answer_detailsDao");
    }
}
