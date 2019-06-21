using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IBll
{
    /// <summary>
    /// 薪酬标准单详细信息表
    /// </summary>
    public interface salary_standard_detailsIBLL
    {
        //薪酬标准单详细信息表
        int salary_standard_detailsInsert(salary_standard_details sd);
    }
}
