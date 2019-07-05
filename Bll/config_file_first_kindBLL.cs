using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Models;
using Dao;
using IDao;
using IOC;
using System.Linq.Expressions;

namespace Bll
{
    /// <summary>
    /// 一级结构设置
    /// </summary>
    public class config_file_first_kindBLL:config_file_first_kindIBLL
    {
        private static config_file_first_kindIDao dao = IocType.GetIocType<config_file_first_kindDao>("config_file_first_kindDao", "config_file_first_kindDao");

        

        /// <summary>
        /// 查询所有一级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_first_kind> SelectFirst_kind()
        {
            return dao.SelectFirst_kind();
        }
        //一级机构新增
        public int config_file_first_kindInsert(config_file_first_kind first)
        {
            return dao.config_file_first_kindInsert(first);
        }
        //一级机构删除
        public int config_file_first_kindDel(config_file_first_kind first, object keyValue)
        {
            return dao.config_file_first_kindDel(first,keyValue);
        }
        //一级机构按id查询
        public List<config_file_first_kind> selectWhere(Expression<Func<config_file_first_kind, bool>> where)
        {
            return dao.selectWhere(where);
        }
        //一级机构修改
        public int config_file_first_kindUpdate(config_file_first_kind first, object keyValue)
        {
            return dao.config_file_first_kindUpdate(first,keyValue); 
        }
    }
}
