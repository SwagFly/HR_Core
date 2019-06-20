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
    /// 二级机构设置
    /// </summary>
    public class config_file_second_kindDao:DaoBase<config_file_second_kind>, config_file_second_kindIDao
    {
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectSecond_kind(config_file_second_kind second) {
            return SelectWhere(e=>e.second_kind_id.Equals(second.second_kind_id));
        }

    }
}
