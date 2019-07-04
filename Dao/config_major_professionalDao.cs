using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Models;

namespace Dao
{
    /// <summary>
    /// 职位
    /// </summary>
    public class config_major_professionalDao : DaoBase<config_major_professional>, config_major_professionalIDao
    {
        //职称设置删除
        public int config_major_professionalDelete(config_major_professional cmp, object keyValue)
        {
            return Delete(cmp,keyValue);
        }

        //职称设置查询
        public List<config_major_professional> config_major_professionalSelect()
        {
            return SelectAll();
        }
    }
}
