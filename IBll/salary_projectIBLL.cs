using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IBll
{
    /// <summary>
    /// 薪酬报销分类
    /// </summary>
    public interface salary_projectIBLL
    {
        //查询
        List<salary_project> selectsalary_project();
    }
}
