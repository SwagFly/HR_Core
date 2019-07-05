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
    }
}
