using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 二级机构设置
    /// </summary>
    public interface config_file_second_kindIBLL
    {
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        List<config_file_second_kind> SelectSecond_kind(config_file_second_kind second);

    }
}
