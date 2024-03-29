﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Models;
using Dao;
using IDao;
using IOC;
namespace Bll
{
    /// <summary>
    /// 薪酬报销分类
    /// </summary>
    public class salary_projectBLL : salary_projectIBLL
    {
        private static salary_projectIDao dao = IocType.GetIocType<salary_projectDao>("salary_projectDao", "salary_projectDao");

        public int salary_projectDel(salary_project sp, object keyValue)
        {
            return dao.salary_projectDel(sp,keyValue);
        }

        public int salary_projectInsert(salary_project sp)
        {
            return dao.salary_projectInsert(sp);
        }

        //查询
        public List<salary_project> selectsalary_project()
        {
            return dao.selectsalary_project();
        }
    }
}
