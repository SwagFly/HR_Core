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
        /// 调动模块
        /// 查询全部二级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectAllSecond_kind()
        {
            return SelectAll();
        }

        /// <summary>
        /// 按父级查询二级
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectSecond_kind(config_file_second_kind second) {
            return SelectWhere(e=>e.first_kind_id.Equals(second.first_kind_id));
        }
        /// <summary>
        /// 查询全部的二级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectAllSecond() {
            return SelectAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> Second_kind()
        {
            return SelectAll();
        }
    }
}
