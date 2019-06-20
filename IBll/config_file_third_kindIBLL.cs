using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 三级机构设置
    /// </summary>
    public interface config_file_third_kindIBLL
    {
        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <param name="third"></param>
        /// <returns></returns>
        List<config_file_third_kind> GetThird(config_file_third_kind third);
    }
}
