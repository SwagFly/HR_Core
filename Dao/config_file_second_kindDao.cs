﻿using System;
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

        public int config_file_second_kindInsert(config_file_second_kind second)
        {
            return Insert(second);
        }

        public int config_file_second_kindDel(config_file_second_kind second, object keyValue)
        {
            return Delete(second,keyValue);
        }

        public List<config_file_second_kind> config_file_second_kindselectWhere(Expression<Func<config_file_second_kind, bool>> where)
        {
            return SelectWhere(where);
        }

        public int config_file_second_kindUpdate(config_file_second_kind second, object keyValue)
        {
            return Update(second,keyValue);
        }
    }
}
