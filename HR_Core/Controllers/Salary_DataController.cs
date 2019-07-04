using Bll;
using IBll;
using IOC;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Transactions;//事务包
using System.Linq.Expressions;

namespace HR_Core.Controllers
{
    public class Salary_DataController : Controller
    {
        //薪酬标准登记表
        salary_standardIBLL slbll = IocType.GetIocType<salary_standardBLL>("salary_grantBLL", "salary_grantBLL");
        //薪酬报销分类
        salary_projectIBLL spbll = IocType.GetIocType<salary_projectBLL>("salary_projectBLL", "salary_projectBLL");
        //薪酬标准详细表
        salary_standard_detailsIBLL sdbll = IocType.GetIocType<salary_standard_detailsBLL>("salary_standard_detailsBLL", "salary_standard_detailsBLL");
        // GET: Salary/Salary_Data
        public ActionResult Index()
        {
            //生成订单编号
            ViewData["dt"] = slbll.GetId();
            //制定人名称
            users us =(users) Session["userClass"];
            ViewData["user"] = us.u_name;
            //查询薪酬报销分类
            List<salary_project> list = spbll.selectsalary_project();
            return View(list);
        }
        // GET: Salary/Salary_Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salary/Salary_Data/Create
        [HttpPost]
        public ActionResult Create(salary_standard sl, salary_standard_details[] sd)
        {
            int num = 0;
            int j = 0;
            //事务提交
            using (TransactionScope ts = new TransactionScope())
            {
                    foreach (salary_standard_details item in sd)
                    {
                    if (item.salary>0)
                    {
                        j++;
                        item.standard_id = sl.standard_id;
                        item.standard_name = sl.standard_name;
                        num += sdbll.salary_standard_detailsInsert(item);
                    }
                }
                if (slbll.salary_standardInsert(sl)>0&&num==j)
                {
                    ts.Complete();
                    return RedirectToAction("salarystandard_register_success", "Salary_Data");
                }
                else
                {
                    return View();
                }

            }
                
        }
        public ActionResult salarystandard_register_success()
        {
            return View();
        }





        //薪酬标准登记复核分页视图
        // GET: Salary/Salary_Data/Create
        public ActionResult salarystandard_check_list()
        {
            //总例数
            List<salary_standard> uh = slbll.FindAll<salary_standard>(e => e.check_status != 1);//查询分页总数 没有复核的所有数据
            ViewBag.str = uh.Count;//查询表中数据 几条 返回到前台
            return View();
        }
        //薪酬标准登记复核分页
        public ActionResult salarystandard_check_listFenYe()
        {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currentPage"]),
                PageSize=1//每页显示三条
            };
            List<salary_standard> dt = slbll.PageData(e=>e.ssd_id,e=>e.ssd_id>0,page);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", dt);
            dic.Add("page",page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        //薪酬标准登记复核修改按id查询
        [HttpGet]
        public ActionResult salarystandard_check(short id)
        {
            ViewBag.id = id;
            //复核人名称
            users us = (users)Session["userClass"];
            ViewData["user"] = us.u_name;
            //薪酬标准表查询一个对象
            salary_standard list = slbll.salary_standardselectWhere(e => e.ssd_id == id);
            //把对象存ViewBag.Class传到前端
            ViewBag.Class = list;
            //薪酬标准详情表查询
            List<salary_standard_details> detaList= sdbll.salary_standard_detailsselectWhere(list.standard_id);//数据集合
            return View(detaList);
        }
        //薪酬标准登记复核修改
        [HttpPost]
        public ActionResult salarystandard_check(salary_standard sl,short id)
        {
            users us = (users)Session["userClass"];
            salary_standard u = new salary_standard()
            {
                ssd_id = id,
                standard_id = sl.standard_id,
                standard_name = sl.standard_name,
                salary_sum = sl.salary_sum,
                designer = sl.designer,//制定者名字 
                register=sl.register,//登记人:register
                checker = us.u_name, /*sl.register*///前台复核人:checker就是登记人:register
                check_time = sl.check_time,//复核时间：check_time
                regist_time = sl.regist_time,//登记时间：regist_time
                check_comment = sl.check_comment,
                check_status = 1//当此方法通过时 就是通过复核
            };
            int num = slbll.salary_standardUpdate(u);
            if (num>0)
            {
                return RedirectToAction("salarystandard_check_success", "Salary_Data");
            }
            else
            {
                return View();
            }
            
        }
        //薪酬标准登记复核修改成功
        public ActionResult salarystandard_check_success()
        {
            return View();
        }



        //薪酬标准查询
        [HttpGet]
        public ActionResult salarystandard_query_locate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult salarystandard_query_locate(FormCollection s)
        {
            string standardId = s["standardId"];//薪酬编号 /*Request.QueryString["standardId"];*/
            string primarKey = s["primarKey"];//关键字
            string startDate = s["startDate"];
            string endDate = s["endDate"];
            string sql = string.Format("select * from [dbo].[salary_standard] where 1=1");
            if (standardId != "")
            {
               sql += string.Format(" and [standard_id] like '%{0}%' ", standardId);
            }
            if (primarKey != "")
            {
                //同时在多个列模糊查询一个值 用括号
                sql += string.Format(" and ([standard_name] like '%{0}%' or [designer] like '%{1}%' or [register] like '%{2}%' or [checker] like '%{3}%')", primarKey, primarKey, primarKey, primarKey);
            }
            if (startDate != "")
            {
                sql += string.Format(" and [regist_time] > '{0}' ", startDate);//请输入建档时间就是同时在登记时间判断两段时间之内的值  输入比登记时间小的值
            }
            if (endDate != "")
            {
                sql += string.Format(" and [change_time] < '{0}' ", endDate);//输入比登记时间大的值
            }
            Session["sql"] = sql;//走到这一步时已经将sql语句完成 存入session以便其他方法用
            return RedirectToAction("salarystandard_query_list");
        }
        //薪酬标准登记查询
        [HttpGet]
        public ActionResult salarystandard_query_list()
        {
            //总例数
            List<salary_standard> uh = slbll.FindAll<salary_standard>(e => e.check_status != 1);//查询分页总数 没有复核的所有数据
            ViewBag.str = uh.Count;//查询表中数据 几条 返回到前台
            return View();
        }
        [HttpPost]
        public ActionResult salarystandard_query_listFenYe(int size,int index)
        {
            int rows = 0;
            string sl = Session["sql"].ToString();//获取salarystandard_query_locate前一个页面的方法用session存储的所有sql语句拼接起来的语句
            List<salary_standard> list = slbll.SelectBy(sl, out rows, index, size);//自己定义的方法  注意参数！！！！！！
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["rows"] = rows;
            dic["index"] = index;
            dic["list"] = list;
            if (rows > 0)
            {
                dic["pages"] = (rows - 1) / size + 1;
            }
            else
            {
                dic["pages"] = 0;
            }
            return Json(dic);
        }
        //薪酬标准登记查询
        public ActionResult salarystandard_query(short id)
        {
            ViewBag.id = id;
            //复核人名称
            users us = (users)Session["userClass"];
            ViewData["user"] = us.u_name;
            //薪酬标准表查询一个对象
            salary_standard list = slbll.salary_standardselectWhere(e => e.ssd_id == id);
            //把对象存ViewBag.Class传到前端
            ViewBag.Class = list;
            //薪酬标准详情表查询
            List<salary_standard_details> detaList = sdbll.salary_standard_detailsselectWhere(list.standard_id);//数据集合
            return View(detaList);
        }
      




        //薪酬变更
        [HttpGet]
        public ActionResult salarystandard_change_locate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult salarystandard_change_locate(FormCollection s)
        {
            string standardId = s["standardId"];//薪酬编号 /*Request.QueryString["standardId"];*/
            string primarKey = s["primarKey"];//关键字
            string startDate = s["startDate"];
            string endDate = s["endDate"];
            string sql = string.Format("select * from [dbo].[salary_standard] where 1=1");
            if (standardId != "")
            {
                sql += string.Format(" and [standard_id] like '%{0}%' ", standardId);
            }
            if (primarKey != "")
            {
                //同时在多个列模糊查询一个值 用括号
                sql += string.Format(" and ([standard_name] like '%{0}%' or [designer] like '%{1}%' or [register] like '%{2}%' or [checker] like '%{3}%')", primarKey, primarKey, primarKey, primarKey);
            }
            if (startDate != "")
            {
                sql += string.Format(" and [regist_time] > '{0}' ", startDate);//请输入建档时间就是同时在登记时间判断两段时间之内的值  输入比登记时间小的值
            }
            if (endDate != "")
            {
                sql += string.Format(" and [change_time] < '{0}' ", endDate);//输入比登记时间大的值
            }
            Session["sql"] = sql;//走到这一步时已经将sql语句完成 存入session以便其他方法用
            return RedirectToAction("salarystandard_change_list");
        }
        [HttpGet]
        public ActionResult salarystandard_change_list()
        {
            //总例数
            List<salary_standard> uh = slbll.FindAll<salary_standard>(e => e.check_status != 1);//查询分页总数 没有复核的所有数据
            ViewBag.str = uh.Count;//查询表中数据 几条 返回到前台
            return View();
        }
        [HttpPost]
        public ActionResult salarystandard_change_listFenYe(int size, int index)
        {
            int rows = 0;
            string sl = Session["sql"].ToString();//获取salarystandard_query_locate前一个页面的方法用session存储的所有sql语句拼接起来的语句
            List<salary_standard> list = slbll.SelectBy(sl, out rows, index, size);//自己定义的方法  注意参数！！！！！！
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["rows"] = rows;
            dic["index"] = index;
            dic["list"] = list;
            if (rows > 0)
            {
                dic["pages"] = (rows - 1) / size + 1;
            }
            else
            {
                dic["pages"] = 0;
            }
            return Json(dic);
        }
        //薪酬变更按id查询
        [HttpGet]
        public ActionResult salarystandard_change(short id)
        {
            ViewBag.id = id;
            //复核人名称
            users us = (users)Session["userClass"];
            ViewData["user"] = us.u_name;
            //薪酬标准表查询一个对象
            salary_standard list = slbll.salary_standardselectWhere(e => e.ssd_id == id);
            //把对象存ViewBag.Class传到前端
            ViewBag.Class = list;
            //薪酬标准详情表查询
            List<salary_standard_details> detaList = sdbll.salary_standard_detailsselectWhere(list.standard_id);//数据集合
            return View(detaList);
        }
        //薪酬变更修改重新提交
        [HttpPost]
        public ActionResult salarystandard_change(salary_standard sl,short id)
        {
            salary_standard u = new salary_standard()
            {
                ssd_id = id,
                standard_id = sl.standard_id,
                standard_name = sl.standard_name,
                salary_sum = sl.salary_sum,
                designer = sl.designer,//制定者名字 
                register = sl.register,//登记人:register
                checker = sl.checker, /*sl.register*///前台复核人:checker就是登记人:register
                changer=sl.checker,//变更人
                regist_time = sl.regist_time,//登记时间：regist_time
                check_time = sl.check_time,//复核时间：check_time
                change_time=sl.check_time,//变更时间
                check_comment=sl.check_comment,
                remark = sl.remark,
                check_status=sl.check_status,//复核状态
                change_status = 1//当此方法通过时 就是通过变更
            };
            int num = slbll.salary_standardUpdate(u);
            if (num > 0)
            {
                return RedirectToAction("salarystandard_change_success", "Salary_Data");
            }
            else
            {
                return View();
            }
        }
        public ActionResult salarystandard_change_success()
        {
            return View();
        }
    }
}
