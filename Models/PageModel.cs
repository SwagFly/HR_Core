using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 分页实体类
    /// </summary>
    public class PageModel
    {
        private int currentPage;
        private int pageSize;
        private int pages;
        private int rows;
        /// <summary>
        /// 当前第CurrentPage页
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }

            set
            {
                currentPage = value;
            }
        }
        /// <summary>
        /// 一页PageSize条数据
        /// </summary>
        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }
        /// <summary>
        /// 总共Pages页
        /// </summary>
        public int Pages
        {
            get
            {
                return pages;
            }

            set
            {
                pages = value;
            }
        }
        /// <summary>
        /// 一共Rows行数据
        /// </summary>
        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }
    }
}
