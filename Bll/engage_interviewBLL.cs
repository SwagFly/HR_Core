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
        /// <summary>
        /// 按名字查询表中某一个人的数据集
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public List<engage_interview> GetInterview(engage_resume resume)
        {
            return dao.GetInterview(resume);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        public int InsertInter(engage_interview inter)
        {
            return dao.InsertInter(inter);
        }
        /// <summary>
        /// 重复操作就是修改
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        public int UpdateInter(engage_interview inter)
        {
            return dao.UpdateInter(inter);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<engage_interview> GetPage(PageModel page)
        {
            return dao.GetPage( page);
        }
        /// <summary>
        /// 根据ID查询单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public engage_interview GetInterId(int id)
        {
            return dao.GetInterId(id);
        }
        /// <summary>
        /// 查询所有可以进行录用申请的人
        /// </summary>
        /// <returns></returns>
        public List<engage_interview> GetLuYong()
        {
            return dao.GetLuYong();
        }
        /// <summary>
        /// 根据档案编号查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public engage_interview GetResumeIdClass(int id)
        {
            return dao.GetResumeIdClass(id);
        }
        /// <summary>
        /// 查询所有可以进行录用审批的人
        /// </summary>
        /// <returns></returns>
        public List<engage_interview> GetShenpi()
        {
            return dao.GetShenpi();
        }
    }
}
