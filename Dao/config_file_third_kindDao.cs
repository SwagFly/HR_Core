using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Models;

namespace Dao
{
    /// <summary>
    /// 三级机构设置
    /// </summary>
    public class config_file_third_kindDao:DaoBase<config_file_third_kind>,config_file_third_kindIDao
    {
        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <param name="third"></param>
        /// <returns></returns>
        public List<config_file_third_kind> GetThird(config_file_third_kind third) {
            return SelectWhere(e => e.third_kind_id.Equals(third.third_kind_id));
        }
    }
}
