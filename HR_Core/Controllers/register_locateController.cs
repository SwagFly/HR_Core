using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IOC;
using Models;
using Bll;
using IBll;
using Newtonsoft.Json;

namespace HR_Core.Controllers
{
    public class register_locateController : Controller
    {
        private static config_file_first_kindIBLL first = IocType.GetIocType<config_file_first_kindBLL>("config_file_first_kindBLL", "config_file_first_kindBLL");//一级机构
        private static config_file_second_kindIBLL second = IocType.GetIocType<config_file_second_kindBLL>("config_file_second_kindBLL", "config_file_second_kindBLL");//二级机构
        private static config_file_third_kindIBLL third = IocType.GetIocType<config_file_third_kindBLL>("config_file_third_kindBLL", "config_file_third_kindBLL");//三级机构
        private static major_changeIBLL major = IocType.GetIocType<major_changeBLL>("major_changeBLL", "major_changeBLL");//职位调动
        private static UsersIBll user = IocType.GetIocType<UsersBLL>("UsersBLL", "UsersBLL");//用户
        private static config_major_kindIBLL cmk = IocType.GetIocType<config_major_kindBLL>("config_major_kindBLL", "config_major_kindBLL");//职位分类设置 
        private static config_majorIBLL cmb = IocType.GetIocType<config_majorBLL>("config_majorBLL", "config_majorBLL");//职位设置
        private static salary_standardIBLL ssb = IocType.GetIocType<salary_standardBLL>("salary_standardBLL", "salary_standardBLL");//薪酬标准基本信息
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询一级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectFirst()
        {
            List<config_file_first_kind> list = first.SelectFirst_kind();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectSecond()
        {
            List<config_file_second_kind> list = second.SelectAllSecond_kind();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 根据一级机构名称查询二级机构
        /// </summary>
        /// <param name="firstname">一级机构名称</param>
        /// <returns></returns>
        public ActionResult SelectSecondByWhere(string firstname)
        {
            List<config_file_second_kind> list = second.SelectWhere(e => e.first_kind_name == firstname);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectThird()
        {
            List<config_file_third_kind> list = third.SelectAllThird();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 根据二级机构名称查询三级机构
        /// </summary>
        /// <param name="second_kind_name"></param>
        /// <returns></returns>
        public ActionResult SelectThirdByWhere(string secondname)
        {
            List<config_file_third_kind> list = third.SelectWhere(e => e.second_kind_name== secondname);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询的条件拼接
        /// </summary>
        /// <param name="first">一级机构</param>
        /// <param name="second">二级机构</param>
        /// <param name="third">三级机构</param>
        /// <param name="registtime">登记时间</param>
        /// <param name="checktime">复核时间</param>
        /// <returns></returns>
        string sql = "select * from major_change where 1=1 and [check_status]<1";
        public ActionResult SelectWheres(string first,string second,string third,string registtime,string checktime)
        {
            if (third != "" && third != "0")
            {
                sql += string.Format(" and [third_kind_name]='{0}'", third);
            }else if (second != "" && second != "0")
            {
                sql += string.Format(@" and [second_kind_name]='{0}'", second);
            }else if (first != "" && first != "0")
            {
                sql += string.Format(@" and [first_kind_name]='{0}'", first);
            }
            if (registtime != "")
            {
                sql += string.Format(@" and [regist_time]>'{0}'", registtime);
            }
            if (checktime != "")
            {
                sql += string.Format(@" and [check_time]<'{0}'", checktime);
            }
            Session["sql"] = sql;
            return Content("ok");
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="IndexPage">当前页</param>
        /// <returns></returns>
        public ActionResult SelectFenYe(int PageSize,int IndexPage)
        {
            string where = Session["sql"].ToString();//根据条件查询
            int rows = 0;//总行数
            var list = major.SelectFenYeBySelect(where,out rows, IndexPage, PageSize);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["rows"] = rows;
            dic["IndexPage"] = IndexPage;
            dic["list"] = list;
            if (rows > 0)
            {
                dic["pages"] = (rows - 1) / PageSize + 1;
            }
            else
            {
                dic["pages"] = 0;
            }
            return Content(JsonConvert.SerializeObject(dic));
        }
        /// <summary>
        /// 分页查询的视图
        /// </summary>
        /// <returns></returns>
        public ActionResult register_list()
        {
            return View();
        }
        /// <summary>
        /// 根据mch_id查询显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult register(int id)
        {
            users u = Session["userClass"] as users;//从登录进来的session里面获取uname
            Session["uname"]=u.u_name;
            //string u_name = u.u_name;
            List<major_change> list = major.SelectWhere(e => e.mch_id == id);//根据id查询
            major_change maj = new major_change()
            {
                mch_id = list[0].mch_id,
                human_name = list[0].human_name, //姓名
                first_kind_id = list[0].first_kind_id,//一级编号
                first_kind_name = list[0].first_kind_name,//一级结构名称
                second_kind_id = list[0].second_kind_id,//二级编号
                second_kind_name = list[0].second_kind_name,//二级名字
                third_kind_id = list[0].third_kind_id,//三级编号
                third_kind_name = list[0].third_kind_name,//三级机构名称
                major_kind_id = list[0].major_kind_id,//职位分类编号
                major_kind_name = list[0].major_kind_name,//职位分类名称
                major_id = list[0].major_id,//职位编号
                major_name = list[0].major_name,//职位名称
                new_first_kind_id = list[0].new_first_kind_id,//新一级机构编号    
                new_first_kind_name = list[0].new_first_kind_name,//新一级机构名称     
                new_second_kind_id = list[0].new_second_kind_id,//新二级机构编号
                new_second_kind_name = list[0].new_second_kind_name,//新二级机构名称    
                new_third_kind_id = list[0].new_third_kind_id,//新三级机构编号   
                new_third_kind_name = list[0].new_third_kind_name,//新三级机构名称
                new_major_kind_id = list[0].new_major_kind_id,//新职位分类编号
                new_major_kind_name = list[0].new_major_kind_name,//新职位分类名称
                new_major_id = list[0].new_major_id,//新职位编号
                new_major_name = list[0].new_major_name,//新职位名称 
                human_id = list[0].human_id,//人力资源档案编号
                salary_standard_id = list[0].salary_standard_id,//薪酬标准编号
                salary_standard_name = list[0].salary_standard_name,//薪酬标准名称
                salary_sum = list[0].salary_sum,//薪酬总额
                new_salary_standard_id = list[0].new_salary_standard_id,//新薪酬标准编号 
                new_salary_standard_name = list[0].new_salary_standard_name,//新薪酬标准名称 
                new_salary_sum = list[0].new_salary_sum,//新薪酬总额 
                change_reason = list[0].change_reason,//调动原因
                check_reason = list[0].check_reason,//审核通过意见
                check_status = list[0].check_status,//复核通过状态
                register = list[0].register,//登记人
                checker = list[0].checker,//复核人
                regist_time = list[0].regist_time,//登记时间
                check_time = list[0].check_time,//复核时间
            };
            return View(maj);
        }
        /// <summary>
        /// 查询职位分类设置 
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectConfig_major_kind()
        {
            List<config_major_kind> list = cmk.GetMajorKind();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 根据职位分类查询职位名称
        /// </summary>
        /// <param name="MajorKindName">职位名称</param>
        /// <returns></returns>
        public ActionResult Selectconfig_majorBymajor_kind_name(string MajorKindName)
        {
            List<config_major> list = cmb.SelectWhere(e => e.major_kind_name == MajorKindName);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询全部新薪酬标准
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectSalary_standard()
        {
            List<salary_standard> list = ssb.SelectAll();
            return Content(JsonConvert.SerializeObject(list));
        }




















        // GET: register_locate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: register_locate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: register_locate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: register_locate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: register_locate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: register_locate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: register_locate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
