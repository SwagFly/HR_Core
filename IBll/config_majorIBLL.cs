using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 职位分类
    /// </summary>
    public interface config_majorIBLL
    {
        /// <summary>
        /// 查询所有职位名称
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        List<config_major> GetMajor(config_major major);
    }
}
