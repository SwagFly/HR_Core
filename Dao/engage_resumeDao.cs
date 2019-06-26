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
    }
}
