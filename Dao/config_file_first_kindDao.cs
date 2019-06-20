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
    /// 一级结构设置
    /// </summary>
    public class config_file_first_kindDao:DaoBase<config_file_first_kind>,config_file_first_kindIDao
    {
        /// <summary>
        /// 查询所有一级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_first_kind> SelectFirst_kind() {
            return SelectAll();
        }
    }
}
