using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 职位分类IDao设置
    /// </summary>
    public interface config_majorIDao
    {
        /// <summary>
        /// 查询所有职位名称
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        List<config_major> GetMajor(config_major major);


    }
}
