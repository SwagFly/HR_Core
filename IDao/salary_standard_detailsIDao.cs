using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 薪酬标准单详细信息表IDao
    /// </summary>
    public interface salary_standard_detailsIDao
    {
        //薪酬标准单详细信息表
        int salary_standard_detailsInsert(salary_standard_details sd);
    }
}
