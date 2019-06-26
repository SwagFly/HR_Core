using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IBll
{
    public interface checkedsIBll
    {
        //
        /// <summary>
        /// 根据rid查询权限
        /// </summary>
        /// <param name="rid">权限id</param>
        /// <param name="fid">权限的父id</param>
        /// <returns></returns>
        List<vw_checked> SelectRolesByrid(int rid, int fid);
    }
}
