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
using System.Linq.Expressions;

namespace Bll
{
    /// <summary>
    /// 人力资源档案
    /// </summary>
    public class human_fileBLL: human_fileIBLL
    {
        private static human_fileIDao dao = IocType.GetIocType<human_fileDao>("human_fileDao", "human_fileDao");

        public List<human_file> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize)
        {
            return dao.SelectFenYeBySelect(sql, out rows, IndexPage, PageSize);
        }

        //薪酬调用人力资源显示
        public List<human_file> Selecthuman_file(human_file hf)
        {
            return dao.Selecthuman_file(hf);
        }

        public List<human_file> SelectWhere(Expression<Func<human_file, bool>> where)
        {
            return dao.SelectWhere(where);
        }
    }
}
