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
    /// 职位部门
    /// </summary>
    public class config_major_kindDao : DaoBase<config_major_kind>, config_major_kindIDao
    {
        /// <summary>
        /// 查询全部部门分类
        /// </summary>
        /// <returns></returns>
        public List<config_major_kind> GetMajorKind() {
            return SelectAll();
        } 
    }
}
