using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 面试IDao
    /// </summary>
    public interface engage_interviewIDao
    {
        /// <summary>
        /// 按名字查询表中某一个人的数据集
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        List<engage_interview> GetInterview(engage_resume resume);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        int InsertInter(engage_interview inter);
        /// <summary>
        /// 重复操作就是修改
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        int UpdateInter(engage_interview inter);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        List<engage_interview> GetPage(PageModel page);
        /// <summary>
        /// 根据ID查询单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        engage_interview GetInterId(int id);
        /// <summary>
        /// 查询所有可以进行录用申请的人
        /// </summary>
        /// <returns></returns>
        List<engage_interview> GetLuYong();
        /// <summary>
        /// 根据档案编号查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        engage_interview GetResumeIdClass(int id);
        /// <summary>
        /// 查询所有可以进行录用审批的人
        /// </summary>
        /// <returns></returns>
        List<engage_interview> GetShenpi();
    }
}
