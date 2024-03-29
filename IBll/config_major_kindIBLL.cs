﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 职位部门
    /// </summary>
    public interface config_major_kindIBLL
    {
        /// <summary>
        /// 查询全部部门分类
        /// </summary>
        /// <returns></returns>
        List<config_major_kind> GetMajorKind();
        //新增
        int config_major_kindInsert(config_major_kind cmk);
        //删除
        int config_major_kindDel(config_major_kind cmk, object keyValue);
    }
}
