using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IBll
{
    /// <summary>
    /// 薪酬标准单详细信息表
    /// </summary>
    public interface salary_standard_detailsIBLL
    {
        //薪酬标准单详细信息表
        int salary_standard_detailsInsert(salary_standard_details sd);
        //薪酬标准登记复核详细表按id查询
        List<salary_standard_details> salary_standard_detailsselectWhere(string id);
        int salary_standard_detailsUpdate(salary_standard_details sd);
    }
}
