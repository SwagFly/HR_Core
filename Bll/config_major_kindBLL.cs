﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Models;
using Dao;
using IDao;
using IOC;
namespace Bll
{
    /// <summary>
    /// 职位部门
    /// </summary>
    public class config_major_kindBLL: config_major_kindIBLL
    {
        private static config_major_kindIDao dao = IocType.GetIocType<config_major_kindDao>("config_major_kindDao", "config_major_kindDao");

        public int config_major_kindDel(config_major_kind cmk, object keyValue)
        {
            return dao.config_major_kindDel(cmk,keyValue);
        }
        public int config_major_kindInsert(config_major_kind cmk)
        {
            return dao.config_major_kindInsert(cmk);
        }

        /// <summary>
        /// 查询全部部门分类
        /// </summary>
        /// <returns></returns>
        public List<config_major_kind> GetMajorKind()
        {
            return dao.GetMajorKind();
        }

    }
}
