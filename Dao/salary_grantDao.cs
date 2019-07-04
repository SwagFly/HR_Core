using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Dao
{
    /// <summary>
    /// 薪酬发放登记表
    /// </summary>
    public class salary_grantDao : DaoBase<salary_grant>, salary_grantIDao
    {
        /// <summary>
        /// 薪酬模块
        /// 薪酬发放查询的分页
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="rows"></param>
        /// <param name="IndexPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<salary_grant> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize)
    public class salary_grantDao : DaoBase<salary_grant>, salary_grantIDao
    {
        //薪酬发放新增
        HR_DBEntities hr = new HR_DBEntities();
        /// <summary>
        /// 执行存储过程-->需要解决！！
        /// </summary>
        /// <param name="sql">存储过程的名字</param>
        /// <param name="frmName"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        //存储过程
        public static DataTable SelectProc(SqlParameter[] ps, string fileName)
        {
            string str = @"Data Source=DESKTOP-UQF2PKO\MSSQLSERVER2012;Initial Catalog=HR_DB;Integrated Security=True";
            SqlConnection cn = new SqlConnection(str);
            string sql = "procDanHaoFaFan";
            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            //执行的是存储过程
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            //命令对象添加参数对象
            ad.SelectCommand.Parameters.AddRange(ps);
            DataTable dt = new DataTable();
            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter("错误日志.txt", true))
                {
                    sw.WriteLine("错误信息：" + ex.Message);
                    sw.WriteLine("错误时间:" + DateTime.Now);
                    sw.WriteLine("报错窗体名:" + fileName);
                    sw.WriteLine("----------------------------");
                }
            }
            return dt;
        }
        public string GetIdFF()
        {
            //string sql = "[dbo].[procDanHao]";
            SqlParameter[] sp = {
                new SqlParameter(){ ParameterName="@danhaoFF", SqlDbType= SqlDbType.VarChar, Direction= ParameterDirection.Output,Size=14}
            };
            DataTable dt = SelectProc(sp, "salary_grantDao");
            return sp[0].Value.ToString();
        }



        public int salary_grantInsert(salary_grant sg)
        {
            return Insert(sg);
        }
        //薪酬发放复核（修改）
        public int salary_grantUpdate(salary_grant sg, object keyValue)
        {
            return Update(sg,keyValue);
        }

        /// <summary>
        /// 薪酬模块
        /// 薪酬发放查询的分页
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="rows"></param>
        /// <param name="IndexPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<salary_grant> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize)
    {
            HR_DBEntities entity = new HR_DBEntities();
            var select = entity.salary_grant.SqlQuery(sql).ToList();
            rows = select.Count();
            return select.Skip((IndexPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
