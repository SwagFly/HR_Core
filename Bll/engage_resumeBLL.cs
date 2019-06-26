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
    /// 简历管理
    /// </summary>
    public class engage_resumeBLL: engage_resumeIBLL
    {
        private static engage_resumeIDao dao = IocType.GetIocType<engage_resumeDao>("engage_resumeDao", "engage_resumeDao");
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public int InsertResume(engage_resume resume)
        {
            return dao.InsertResume(resume);
        }
    }
}
