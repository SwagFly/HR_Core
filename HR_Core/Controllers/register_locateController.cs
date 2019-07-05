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
        private static human_fileIBLL hum = IocType.GetIocType<human_fileBLL>("human_fileBLL", "human_fileBLL");//人力资源档案
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
         //string sql = "select * from major_change where 1=1 and [check_status]<1";
        //string sql = "select * from [dbo].[human_file] where 1=1 and [check_status]<1";
        string sql = "select * from [dbo].[human_file] where 1=1";
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
            var list = hum.SelectFenYeBySelect(where, out rows, IndexPage, PageSize);
            //var list = major.SelectFenYeBySelect(where,out rows, IndexPage, PageSize);
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
        #region 调动
        //public ActionResult register(int id)
        //{
        //    users u = Session["userClass"] as users;//从登录进来的session里面获取uname
        //    Session["uname"]=u.u_name;
        //    //string u_name = u.u_name;
        //    List<major_change> list = major.SelectWhere(e => e.mch_id == id);//根据id查询
        //    major_change maj = new major_change()
        //    {
        //        mch_id = list[0].mch_id,
        //        human_name = list[0].human_name, //姓名
        //        first_kind_id = list[0].first_kind_id,//一级编号
        //        first_kind_name = list[0].first_kind_name,//一级结构名称
        //        second_kind_id = list[0].second_kind_id,//二级编号
        //        second_kind_name = list[0].second_kind_name,//二级名字
        //        third_kind_id = list[0].third_kind_id,//三级编号
        //        third_kind_name = list[0].third_kind_name,//三级机构名称
        //        major_kind_id = list[0].major_kind_id,//职位分类编号
        //        major_kind_name = list[0].major_kind_name,//职位分类名称
        //        major_id = list[0].major_id,//职位编号
        //        major_name = list[0].major_name,//职位名称
        //        new_first_kind_id = list[0].new_first_kind_id,//新一级机构编号    
        //        new_first_kind_name = list[0].new_first_kind_name,//新一级机构名称     
        //        new_second_kind_id = list[0].new_second_kind_id,//新二级机构编号
        //        new_second_kind_name = list[0].new_second_kind_name,//新二级机构名称    
        //        new_third_kind_id = list[0].new_third_kind_id,//新三级机构编号   
        //        new_third_kind_name = list[0].new_third_kind_name,//新三级机构名称
        //        new_major_kind_id = list[0].new_major_kind_id,//新职位分类编号
        //        new_major_kind_name = list[0].new_major_kind_name,//新职位分类名称
        //        new_major_id = list[0].new_major_id,//新职位编号
        //        new_major_name = list[0].new_major_name,//新职位名称 
        //        human_id = list[0].human_id,//人力资源档案编号
        //        salary_standard_id = list[0].salary_standard_id,//薪酬标准编号
        //        salary_standard_name = list[0].salary_standard_name,//薪酬标准名称
        //        salary_sum = list[0].salary_sum,//薪酬总额
        //        new_salary_standard_id = list[0].new_salary_standard_id,//新薪酬标准编号 
        //        new_salary_standard_name = list[0].new_salary_standard_name,//新薪酬标准名称 
        //        new_salary_sum = list[0].new_salary_sum,//新薪酬总额 
        //        change_reason = list[0].change_reason,//调动原因
        //        check_reason = list[0].check_reason,//审核通过意见
        //        check_status = list[0].check_status,//复核通过状态
        //        register = list[0].register,//登记人
        //        checker = list[0].checker,//复核人
        //        regist_time = list[0].regist_time,//登记时间
        //        check_time = list[0].check_time,//复核时间
        //    };
        //    return View(maj);
        //}
        #endregion
        public ActionResult register(int id)
        {
            users u = Session["userClass"] as users;//从登录进来的session里面获取uname
            Session["uname"] = u.u_name;
            List<human_file> list = hum.SelectWhere(e=>e.huf_id==id);//根据id查询
            human_file h = new human_file()
            {
                huf_id=list[0].huf_id,
 	            human_id=list[0].human_id,
                first_kind_id=list[0].first_kind_id,
                first_kind_name=list[0].first_kind_name,
                second_kind_id=list[0].second_kind_id,
                second_kind_name=list[0].second_kind_name,
                third_kind_id=list[0].third_kind_id,
                third_kind_name=list[0].third_kind_name,
                human_name=list[0].human_name,
                human_address=list[0].human_address,
                human_postcode=list[0].human_postcode,
                human_pro_designation=list[0].human_pro_designation,
                human_major_kind_id=list[0].human_major_kind_id,
                human_major_kind_name=list[0].human_major_kind_name,
                human_major_id=list[0].human_major_id,
                hunma_major_name=list[0].hunma_major_name,
                human_telephone=list[0].human_telephone,
                human_mobilephone=list[0].human_mobilephone,
                human_bank=list[0].human_bank,
                human_account=list[0].human_account,
                human_qq=list[0].human_qq,
                human_email=list[0].human_email,
                human_hobby=list[0].human_hobby,
                human_speciality=list[0].human_speciality,
                human_sex=list[0].human_sex,
                human_religion=list[0].human_religion,
                human_party=list[0].human_party,
                human_nationality=list[0].human_nationality,
                human_race=list[0].human_race,
                human_birthday=list[0].human_birthday,
                human_birthplace=list[0].human_birthplace,
                human_age=list[0].human_age,
                human_educated_degree=list[0].human_educated_degree,
                human_educated_years=list[0].human_educated_years,
                human_educated_major=list[0].human_educated_major,
                human_society_security_id=list[0].human_society_security_id,
                human_id_card=list[0].human_id_card,
                remark=list[0].remark,
                salary_standard_id=list[0].salary_standard_id,
                salary_standard_name=list[0].salary_standard_name,
                salary_sum=list[0].salary_sum,
                demand_salaray_sum= list[0].demand_salaray_sum,
                paid_salary_sum= list[0].paid_salary_sum,
                major_change_amount= list[0].major_change_amount,
                bonus_amount=list[0].bonus_amount,
                training_amount=list[0].training_amount,
                file_chang_amount= list[0].file_chang_amount,
                human_histroy_records= list[0].human_histroy_records,
                human_family_membership= list[0].human_family_membership,
                human_picture= list[0].human_picture,
                attachment_name= list[0].attachment_name,
                check_status= list[0].check_status,
                register= list[0].register,
                checker= list[0].checker,
                changer=list[0].changer,
                regist_time= list[0].regist_time,
                check_time= list[0].check_time,
                change_time=list[0].change_time,
                lastly_change_time= list[0].lastly_change_time,
                delete_time= list[0].delete_time,
                recovery_time=list[0].recovery_time,
                human_file_status=list[0].human_file_status
            };
            return View(h);
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
        /// <summary>
        /// 调动登记的添加事件
        /// 根据人力资源档案做添加操作
        /// 调动原因
        /// </summary>
        /// <param name="change">修改的列名</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult register(major_change change2)
        {
            //给状态修改成1
            string name = Session["uname"].ToString();
            change2.check_status = 1;
            change2.regist_time = DateTime.Now;
            if (change2.new_second_kind_name == "-----请选择-----")
                change2.new_second_kind_name = null;
            if (change2.new_third_kind_name == "-----请选择-----")
                change2.new_third_kind_name = null;
            if (change2.new_major_name == "-----请选择-----")
                change2.new_major_name = null;
            //int result = major.Updates(change2);
            int result = major.Insert(change2);
            if (result > 0)
            {
                return Content("<script>window.location.href='/register_locate/register_success';</script>");
            }
            else
            {
                return Content("<script>alert('登记失败!');window.location.href='/register_locate/register_list';</script>");
            }
        }
        /// <summary>
        /// 调动登记成功
        /// </summary>
        /// <returns></returns>
        public ActionResult register_success()
        {
            return View();
        }
        /// <summary>
        /// 调动审核
        /// 
        /// </summary>
        /// <returns></returns>

        public ActionResult check_list()
        {
            return View();
        }
        /// <summary>
        /// 调动审核分页查询全部
        /// </summary>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="IndexPage">当前页</param>
        /// <returns></returns>
        public ActionResult SelectFenYe2(int PageSize, int IndexPage)
        {
            string where = string.Format(@"select * from [dbo].[major_change] where [check_status]=1");//根据条件查询
            int rows = 0;//总行数
            var list = major.SelectFenYeBySelect(where, out rows, IndexPage, PageSize);
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
        /// 调动审核
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult check(int id)
        {
            users u = Session["userClass"] as users;//从登录进来的session里面获取uuname
            Session["uuname"] = u.u_name;
            List<major_change> list = major.SelectWhere(e => e.mch_id == id);
            List<SelectListItem> list2 = SelectClass();
            ViewData["list"] = list2;
            major_change mc = new major_change()
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
            return View(mc);
        }
        /// <summary>
        /// 一级机构下拉列表给下拉框赋显示和隐藏值
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> SelectClass()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<config_file_first_kind> list2 = first.SelectFirst_kind();
            foreach (config_file_first_kind ll in list2)
            {
                SelectListItem bc = new SelectListItem()
                {
                    Text = ll.first_kind_name,
                    Value = ll.first_kind_id.ToString()
                };
                list.Add(bc);
            }
            return list;
        }
        /// <summary>
        /// 调动审核
        /// 职位分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult zhiwei3(string id)
        {
            List<config_major> list = cmb.SelectWhere(e => e.major_kind_name == id);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 调动审核
        /// 修改major_change check_status：通过的状态为2，不通过为0
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public ActionResult check(major_change change)
        {
            if (change.new_second_kind_name == "-----请选择-----")
                change.new_second_kind_name = null;
            if (change.new_third_kind_name == "-----请选择-----")
                change.new_third_kind_name = null;
            if (change.new_major_name == "-----请选择-----")
            {
                change.new_major_name = null;
                change.new_major_id = null;
            }
            int result = major.Updates(change);
            if (result > 0)
            {
                return Content("<script>window.location.href='/register_locate/check_success';</script>");
            }
            else
            {
                return Content("<script>alert('复核失败！');window.location.href='/register_locate/check_success';</script>");
            }
        }
        /// <summary>
        /// 复核成功的页面
        /// </summary>
        /// <returns></returns>
        public ActionResult check_success()
        {
            return View();
        }
        /// <summary>
        /// 调动查询的视图
        /// </summary>
        /// <returns></returns>
        public ActionResult locate()
        {
            return View();
        }
        /// <summary>
        /// 调动查询
        /// 根据条件拼接SQL
        /// </summary>
        /// <param name="oo"></param>
        /// <returns></returns>
        public ActionResult SelectMajorWheres(FormCollection oo)
        {
            //一级机构
            string yiji = oo["yiji"];
            //二级机构
            string erji = oo["erji"];
            //三级机构
            string sanji = oo["sanji"];
            //职位分类
            string fenlei = oo["fenlei"];
            //职位
            string zhiwei = oo["mingcheng"];
            //开始事件
            string Start = oo["utilbean.startDate"];
            //截止事件
            string End = oo["utilbean.endDate"];
            string sql = "select * from major_change where 1=1 and [check_status]=2";
            //一级为空           
            if (sanji != "" && sanji != "0")
            {
                sql += string.Format(@" and [third_kind_name]='{0}'", sanji);
            }
            else if (erji != "" && erji != "0")
            {
                sql += string.Format(@" and [second_kind_name]='{0}'", erji);
            }
            else if (yiji != "" && yiji != "0")
            {
                sql += string.Format(@" and [first_kind_name]='{0}'", yiji);
            }
            //职位分类为空
            if (fenlei != "" && fenlei != "0")
            {
                sql += string.Format(@"and [major_kind_name]='{0}'", fenlei);
            }
            else if (zhiwei != "" && zhiwei != "0")
            {
                sql += string.Format(@"and [major_name]='{0}'", zhiwei);
            }
            if (Start != "")
            {
                sql += string.Format(@" and [regist_time]>'{0}'", Start);
            }
            if (End != "")
            {
                sql += string.Format(@" and [regist_time]<'{0}'", End);
            }
            Session["SelectMajorWheres"] = sql;
            return Content("<script>window.location.href='/register_locate/list';</script>");
        }
        /// <summary>
        /// 调动管理
        /// 调动查询的分页视图页面
        /// </summary>
        /// <returns></returns>
        public ActionResult list()
        {
            return View();
        }
        /// <summary>
        /// 调动管理
        /// 调动查询分页查询
        /// </summary>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="IndexPage">当前页</param>
        /// <returns></returns>
        public ActionResult SelectFenYes(int PageSize,int IndexPage)
        {
            string sql = Session["SelectMajorWheres"].ToString();
            int rows = 0;//总行数
            var list = major.SelectFenYeBySelect(sql, out rows, IndexPage, PageSize);
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
        /// 调动管理
        /// 调动管理查看
        /// </summary>
        /// <param name="id">根据id查询</param>
        /// <returns></returns>
        public ActionResult detail(int id)
        {
            List<major_change> list = major.SelectWhere(e => e.mch_id == id);
            major_change change = new major_change()
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
            return View(change);
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
