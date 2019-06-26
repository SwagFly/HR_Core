﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDao
{
    /// <summary>
    /// 权限表
    /// </summary>
    public interface PermissionIDao
    {
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="per"></param>
        /// <returns></returns>
        int Insert(Permission per);
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="per"></param>
        /// <returns></returns>
        int Deletes(int rid);
    }
}
