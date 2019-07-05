using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;

namespace Dao
{
    /// <summary>
    /// 面试IDao
    /// </summary>
    public class engage_interviewDao : DaoBase<engage_interview>, engage_interviewIDao
    {
        /// <summary>
        /// 按名字查询表中某一个人的数据集
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public List<engage_interview> GetInterview(engage_resume resume) {
            return SelectWhere(e => e.human_name == resume.human_name);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        public int InsertInter(engage_interview inter) {
            return Insert(inter);
        }
        /// <summary>
        /// 重复操作就是修改
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        public int UpdateInter(engage_interview inter) {
            return Update(inter, inter.ein_id);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<engage_interview> GetPage(PageModel page) {
            return PageData<Int16>(e => e.ein_id, e => e.ein_id > 0, page);
        }
        /// <summary>
        /// 根据ID查询单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public engage_interview GetInterId(int id) {
            return SelectWhere(e => e.ein_id == id).FirstOrDefault();
        }
        /// <summary>
        /// 查询所有可以进行录用申请的人
        /// </summary>
        /// <returns></returns>
        public List<engage_interview> GetLuYong() {
            return SelectWhere(e => e.result == "建议录用");
        }
        /// <summary>
        /// 根据档案编号查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public engage_interview GetResumeIdClass(int id) {
            return SelectWhere(e => e.resume_id == id).FirstOrDefault();
        }
        /// <summary>
        /// 查询所有可以进行录用审批的人
        /// </summary>
        /// <returns></returns>
        public List<engage_interview> GetShenpi()
        {
            return SelectWhere(e => e.result == "申请录用");
        }
    }
}
