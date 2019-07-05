using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IBll
{
    /// <summary>
    /// 职位
    /// </summary>
    public interface config_major_professionalIBLL
    {
        //职称设置查询
        List<config_major_professional> config_major_professionalSelect();
        //职称设置删除
        int config_major_professionalDelete(config_major_professional cmp, object keyValue);
    }
}
