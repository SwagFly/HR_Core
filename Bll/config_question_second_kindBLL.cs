using System;
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
    /// 试题二级分类
    /// </summary>
    public class config_question_second_kindBLL: config_question_second_kindIBLL
    {
        private static config_question_second_kindIDao dao = IocType.GetIocType<config_question_second_kindDao>("config_question_second_kindDao", "config_question_second_kindDao");
    }
}
