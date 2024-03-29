﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 职位分类IDao设置
    /// </summary>
    public interface config_majorIDao
    {
        /// <summary>
        /// 查询所有职位名称
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        List<config_major> GetMajor(config_major major);
        /// <summary>
        /// 根据职位名称查询职位设置表
        /// </summary>
        /// <param name="where">职位名称</param>
        /// <returns></returns>
        List<config_major> SelectWhere(Expression<Func<config_major, bool>> where);
        //新增
        int config_majorInsert(config_major ma);
        //删除
        int config_majorDel(config_major ma, object keyValue);
        //修改
        int config_majorUpdate(config_major ma, object keyValue);
        //查询所有
        List<config_major> config_majorSelect();
    }
}
