using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 简历管理
    /// </summary>
    public interface engage_resumeIBLL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        int InsertResume(engage_resume resume);
        /// <summary>
        /// 查询没有复核的简历
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<engage_resume> GetResume<K>(Expression<Func<engage_resume, K>> order, Expression<Func<engage_resume, bool>> where, PageModel page);
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        engage_resume GetWhereResume(engage_resume resume);
        /// <summary>
        /// 修改符合状态
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        int UpdateState(engage_resume resume);
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="page"></param>
        /// <returns></returns>
        List<engage_resume> ResumeData<K>(PageModel page);
        /// <summary>
        /// 修改复核信息
        /// </summary>
        /// <returns></returns>
        int UpdateResumeState(engage_resume resume);
        /// <summary>
        /// 查询待录用的信息
        /// </summary>
        /// <returns></returns>
        List<engage_resume> GetLuYong(PageModel page);
    }
}
