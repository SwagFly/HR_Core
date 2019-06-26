using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 页面表
    /// </summary>
    public interface RightsObjectIBLL
    {
        /// <summary>
        /// 查询权限下的所有网页
        /// </summary>
        /// <param name="adminRoleId"></param>
        /// <param name="fatherId"></param>
        /// <returns></returns>
        List<RightsObject> GetRoleResult(int adminRoleId, int fatherId);
        //根据rid查询权限
        //根据rid查询权限
        List<RightsObject> SelectRolesByrid(int rid, int fid);
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
