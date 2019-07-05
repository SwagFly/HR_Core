using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return SelectWhere(e => e.second_kind_id.Equals(third.second_kind_id));
        }

        public List<config_file_third_kind> SelectAllThird()
        {
            return SelectAll();
        }
        //薪酬调用三级机构
        public List<config_file_third_kind> third_kind()
        {
            return SelectAll();
        }
        public int config_file_third_kindDel(config_file_third_kind third, object keyValue)
        {
            return Delete(third,keyValue);
        }

        public int config_file_third_kindInsert(config_file_third_kind third)
        {
            return Insert(third);
        }

        public List<config_file_third_kind> config_file_third_kindselectWhere(Expression<Func<config_file_third_kind, bool>> where)
        {
            return SelectWhere(where);
        }

        public int config_file_third_kindUpdate(config_file_third_kind third, object keyValue)
        {
            return Update(third,keyValue);
        }
    }
}
