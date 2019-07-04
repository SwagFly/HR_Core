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
    /// 一级结构设置
    /// </summary>
    public class config_file_first_kindDao:DaoBase<config_file_first_kind>,config_file_first_kindIDao
    {
      

        /// <summary>
        /// 查询所有一级机构
        /// </summary>1
        /// <returns></returns>
        public List<config_file_first_kind> SelectFirst_kind() {
            return SelectAll();
        }
        //一级机构新增
        public int config_file_first_kindInsert(config_file_first_kind first)
        {
            return Insert(first);
        }
        //一级机构删除
        public int config_file_first_kindDel(config_file_first_kind first, object keyValue)
        {
            return Delete(first,keyValue);
        }
        //一级机构按id查询
        public List<config_file_first_kind> selectWhere(Expression<Func<config_file_first_kind, bool>> where)
        {
            return SelectWhere(where);
        }
        //一级机构修改
        public int config_file_first_kindUpdate(config_file_first_kind first,object keyValue)
        {
            return Update(first,keyValue);
        }
       
    }
}
