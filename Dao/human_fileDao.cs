﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
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
    }
}
