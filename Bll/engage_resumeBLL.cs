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
using System.Linq.Expressions;

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
        /// <summary>
        /// 查询没有复核的简历
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<engage_resume> GetResume<K>(Expression<Func<engage_resume, K>> order, Expression<Func<engage_resume, bool>> where, PageModel page)
        {
            return dao.GetResume<K>(order, where, page);
        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public engage_resume GetWhereResume(engage_resume resume)
        {
            return dao.GetWhereResume(resume);
        }
        /// <summary>
        /// 修改复核状态
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public int UpdateState(engage_resume resume)
        {
            return dao.UpdateState(resume);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<engage_resume> ResumeData<K>(PageModel page)
        {
            return dao.ResumeData<K>(page);
        }
        /// <summary>
        /// 修改复核信息
        /// </summary>
        /// <returns></returns>
        public int UpdateResumeState(engage_resume resume)
        {
            return dao.UpdateState(resume);
        }
        /// <summary>
        /// 查询待录用的信息
        /// </summary>
        /// <returns></returns>
        public List<engage_resume> GetLuYong(PageModel page)
        {
            return dao.GetLuYong(page);
        }
    }
}
