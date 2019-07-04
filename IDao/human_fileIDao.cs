using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IDao
{
    /// <summary>
    /// 人力资源档案
    /// </summary>
    public interface human_fileIDao
    {
        //薪酬调用人力资源显示
        List<human_file> Selecthuman_file(human_file hf);
        //薪酬按id查询
        List<human_file> human_fileSelectWhere(Expression<Func<human_file,bool>>where);
    }
}
