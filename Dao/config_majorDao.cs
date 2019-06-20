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
    /// 职位分类IDao设置
    /// </summary>
    public class config_majorDao:DaoBase<config_major>,config_majorIDao
    {
        /// <summary>
        /// 查询所有职位名称
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public List<config_major> GetMajor(config_major major) {
            return SelectWhere(e => e.major_kind_id.Equals(major.major_kind_id));
        }


    }
}
