using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Linq.Expressions;

namespace Dao
{
    /// <summary>
    /// 简历管理IDao
    /// </summary>
    public class engage_resumeDao : DaoBase<engage_resume>, engage_resumeIDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public int InsertResume(engage_resume resume) {
            return Insert(resume);
        }
        /// <summary>
        /// 查询没有复核的简历
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<engage_resume> GetResume<K>(Expression<Func<engage_resume, K>> order, Expression<Func<engage_resume, bool>> where, PageModel page) {
            return PageData<K>(order, where, page);
        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public engage_resume GetWhereResume(engage_resume resume) {
            return SelectWhere(e => e.res_id == resume.res_id).FirstOrDefault();
        }
        /// <summary>
        /// 修改符合状态
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public int UpdateState(engage_resume resume) {
            return Update(resume, resume.res_id);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<engage_resume> ResumeData<K>(PageModel page) {
            return PageData(e => e.res_id, e => e.check_status == 1, page);
        }
        /// <summary>
        /// 修改复核信息
        /// </summary>
        /// <returns></returns>
        public int UpdateResumeState(engage_resume resume) {
            string sql = null;
            if (resume.pass_check_status < 3)
            {
                sql = string.Format(@"update [dbo].[engage_resume] set pass_checkComment='{0}',pass_check_status='{1}'
                                    where res_id='{2}'",resume.pass_checkComment,resume.pass_check_status,resume.res_id);
            }
            else {
                sql = string.Format(@"update [dbo].[engage_resume] set pass_checkComment='{0}',pass_check_status='{1}',pass_passComment='{2}',pass_check_time='{3}',pass_checker='{4}'
                                    where res_id='{5}'",resume.pass_checkComment,resume.pass_check_status,resume.pass_passComment,resume.pass_check_time,resume.pass_checker,resume.res_id);
            }
            return AUD(sql);
        }
        /// <summary>
        /// 查询待录用的信息
        /// </summary>
        /// <returns></returns>
        public List<engage_resume> GetLuYong(PageModel page)
        {
            return PageData<Int16>(e => e.res_id, e => e.pass_passComment == "通过", page);
        }
    }
}
