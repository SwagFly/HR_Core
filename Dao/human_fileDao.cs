using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Linq.Expressions;

namespace Dao
{
    /// <summary>
    /// 人力资源档案
    /// </summary>
    public class human_fileDao : DaoBase<human_file>, human_fileIDao
    {

        //薪酬调用人力资源显示
        public List<human_file> Selecthuman_file(human_file hf)
        {
            return SelectAll();
        }
        //薪酬按id查询
        public List<human_file> human_fileSelectWhere(Expression<Func<human_file, bool>> where)
        {
            return SelectWhere(where);
        }
    }
}
