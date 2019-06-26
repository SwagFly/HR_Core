using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
