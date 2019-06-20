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
    /// 试卷详细信息
    /// </summary>
    public class engage_exam_detailsBLL: engage_exam_detailsIBLL
    {
        private static engage_exam_detailsIDao dao = IocType.GetIocType<engage_exam_detailsDao>("engage_exam_detailsDao", "engage_exam_detailsDao");
    }
}
