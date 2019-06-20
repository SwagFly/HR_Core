using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 二级机构设置IDao
    /// </summary>
    public interface config_file_second_kindIDao
    {
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        List<config_file_second_kind> SelectSecond_kind(config_file_second_kind second);
    }
}
