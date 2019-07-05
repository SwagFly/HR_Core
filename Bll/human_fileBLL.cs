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
        /// <summary>
        /// 添加人力资源信息
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        public int InsertFile(human_file hf)
        {
            return dao.InsertFile(hf);
        }
        /// <summary>
        /// 根据条件查询单个对象
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public human_file SelectHuanm(Expression<Func<human_file, bool>> where) {
            return dao.SelectHuanm(where);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int UpdateFile(human_file file) {
            return dao.UpdateFile(file);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<human_file> ListFile()
        {
            return dao.ListFile();
        }
        /// <summary>
        /// 高级查询
        /// </summary>
        /// <returns></returns>
        public List<human_file> ListWhere(Expression<Func<human_file, bool>> where)
        {
            return dao.ListWhere(where);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public int DeleteClass(human_file file)
        {
            return dao.DeleteClass(file);
        }
        //薪酬按id查询
        public List<human_file> human_fileSelectWhere(Expression<Func<human_file, bool>> where)
        {
            return dao.human_fileSelectWhere(where);
        }

        public List<human_file> SelectWhere(Expression<Func<human_file, bool>> where)
        {
            return dao.SelectWhere(where);
        }
    }
}
