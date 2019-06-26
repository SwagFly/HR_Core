using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 页面IDao
    /// </summary>
    public interface RightsObjectIDao
    {
        /// <summary>
        /// 查询权限下的所有网页
        /// </summary>
        /// <param name="adminRoleId"></param>
        /// <param name="fatherId"></param>
        /// <returns></returns>
        List<RightsObject> GetRoleResult(int adminRoleId, int fatherId);
        //
        /// <summary>
        /// 根据rid查询权限
        /// </summary>
        /// <param name="rid">权限id</param>
        /// <param name="fid">权限的父id</param>
        /// <returns></returns>
        List<RightsObject> SelectRolesByrid(int rid,int fid);
        /// <summary>
        /// 查询fid为0并且state为closed
        /// </summary>
        /// <returns></returns>
        List<RightsObject> SelectZeroAndClosed();
        /// <summary>
        /// 查询fid不为0并且state为closed
        /// </summary>
        /// <returns></returns>
        List<RightsObject> SelectNotZeroAndClosed();
        /// <summary>
        /// 查询fid不为0并且state为open
        /// </summary>
        /// <returns></returns>
        List<RightsObject> SelectNotZeroAndOpen();
    }
}
