using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Runtime.Remoting.Messaging;
using System.Linq.Expressions;
using System.Data;

namespace Dao
{
    /// <summary>
    /// EF数据模型通用Dao层操作
    /// </summary>
    /// <typeparam name="T">实体模型</typeparam>
    public class DaoBase<T> where T : class
    {
        private static HR_DBEntities models = CreateDBContent();
        /// <summary>
        /// 获取模型数据对象
        /// </summary>
        /// <returns>数据对象</returns>
        public static HR_DBEntities CreateDBContent()
        {
            HR_DBEntities modelSet = CallContext.GetData("modelClass") as HR_DBEntities;
            if (modelSet == null)
            {
                modelSet = new HR_DBEntities();
                CallContext.SetData("modelClass", modelSet);
            }
            return modelSet;
        }
        /// <summary>
        /// 查询全部数据集
        /// </summary>
        /// <returns>某个模型的数据集</returns>
        public List<T> SelectAll()
        {
            return models.Set<T>().Select(e => e).ToList();
        }
        /// <summary>
        /// 按条件查询数据集
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>条件查询数据集</returns>
        public List<T> SelectWhere(Expression<Func<T,bool>> where) {
            return models.Set<T>().Where(where)
                .Select(e => e)
                .ToList();
        //public IQueryable<T> LoadItems(Expression<Func<T, bool>> whereLambda)
        //{
        //    return MyBaseDbContext.Set<T>().Where(whereLambda).AsQueryable();
        //}
        }
        /// <summary>
        /// EF分页
        /// </summary>
        /// <typeparam name="K">泛型返回类型</typeparam>
        /// <param name="order">order</param>
        /// <param name="where">where</param>
        /// <param name="page">PageModel类</param>
        /// <returns>返回过滤后的数据集合</returns>
        public List<T> PageData<K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where,PageModel page) {
            var data = models.Set<T>().OrderBy(order).Where(where);//获取符合要求的所有数据
            page.Rows = data.Count();//获取总数据条数
            page.Pages = (page.Rows - 1) / page.PageSize + 1;//获取一共多少页
            return data.Skip((page.CurrentPage - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();//返回过滤后的数据集合

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <returns>0：添加失败，1：添加成功</returns>
        public int Insert(T t) {
            models.Entry<T>(t).State = System.Data.Entity.EntityState.Added;
            return models.SaveChanges();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <param name="keyValue">删除对象的主键值</param>
        /// <returns>0：修改失败，1：修改成功</returns>
        public int Update(T t, object keyValue) {
            var entity = models.Set<T>().Find(keyValue);
            if (entity != null)
            {
                models.Entry<T>(entity).State = System.Data.Entity.EntityState.Detached;
            }
            models.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            return models.SaveChanges();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <returns>0：删除失败，1：删除成功</returns>
        public int Delete(T t) {
            models.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;
            return models.SaveChanges();
        }
        /// <summary>
        /// 应急：通用方法无解时，使用本方法；
        /// </summary>
        /// <param name="sql">Sql语句（只做增删改，查询不可使用）</param>
        /// <returns></returns>
        public int AUD(string sql) {
            return models.Database.ExecuteSqlCommand(sql);
        }
        /// <summary>
        /// 通用查询Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> SelectSQL(string sql) {
            return models.Database.SqlQuery<T>(sql).ToList();
        }

    }
}
