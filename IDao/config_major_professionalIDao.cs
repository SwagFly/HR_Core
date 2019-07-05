using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDao
{
    /// <summary>
    /// 职位IDao
    /// </summary>
    public interface config_major_professionalIDao
    {
        //职称设置查询
        List<config_major_professional> config_major_professionalSelect();
        //职称设置删除
        int config_major_professionalDelete(config_major_professional cmp,object keyValue);
    }
}
