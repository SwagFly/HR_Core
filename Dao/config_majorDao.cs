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
        public int config_majorDel(config_major ma, object keyValue)
        {
            return Delete(ma,keyValue);
        }

        public int config_majorInsert(config_major ma)
        {
            return Insert(ma);
        }

        public List<config_major> config_majorSelect()
        {
            return SelectAll();
        }

        public int config_majorUpdate(config_major ma, object keyValue)
        {
            return Update(ma,keyValue);
        }

        /// <summary>
        /// 按父级职业部门查询所有职位名称
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public List<config_major> GetMajor(config_major major) {
            return SelectWhere(e => e.major_kind_id.Equals(major.major_kind_id));
        }


    }
}
