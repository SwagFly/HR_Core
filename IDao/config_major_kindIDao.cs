﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 职位部门IDao
    /// </summary>
    public interface config_major_kindIDao
    {
        /// <summary>
        /// 查询全部部门分类
        /// </summary>
        /// <returns></returns>
        List<config_major_kind> GetMajorKind();
        //新增
        int config_major_kindInsert(config_major_kind cmk);
        //删除
        int config_major_kindDel(config_major_kind cmk,object keyValue);
    }
}
