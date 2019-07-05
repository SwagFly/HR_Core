using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Linq.Expressions;

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
        /// <summary>
        /// 添加人力资源信息
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        public int InsertFile(human_file hf) {
            return Insert(hf);
        }
        /// <summary>
        /// 根据条件查询单个对象
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public human_file SelectHuanm(Expression<Func<human_file,bool>> where) {
            return SelectWhere(where).FirstOrDefault();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int UpdateFile(human_file file) {
            return Update(file, file.huf_id);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<human_file> ListFile() {
            return SelectAll();
        }
        /// <summary>
        /// 高级查询
        /// </summary>
        /// <returns></returns>
        public List<human_file> ListWhere(Expression<Func<human_file, bool>> where) {
            return SelectWhere(where);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public int DeleteClass(human_file file) {
            return Delete(file, file.huf_id);
        }
        //薪酬按id查询
        public List<human_file> human_fileSelectWhere(Expression<Func<human_file, bool>> where)
        {
            return SelectWhere(where);
        }
        /// <summary>
        /// 调动模块
        /// 根据一级机构、二级结构、三级结构、登记时间和复核时间根据条件做分页查询
        /// </summary>
        /// <param name="sql">根据sql筛选</param>
        /// <param name="rows">总行数</param>
        /// <param name="IndexPage">当前页</param>
        /// <param name="PageSize">总页数</param>
        /// <returns></returns>
        public List<human_file> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize)
        {
            HR_DBEntities entity = new HR_DBEntities();
            var select = entity.human_file.SqlQuery(sql).ToList();//根据条件查询
            rows = select.Count();//获取总记录数
            return select.Skip((IndexPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
