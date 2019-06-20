using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 一级结构设置
    /// </summary>
    public interface config_file_first_kindIBLL
    {
        /// <summary>
        /// 查询所有一级机构
        /// </summary>
        /// <returns></returns>
        List<config_file_first_kind> SelectFirst_kind();
    }
}
