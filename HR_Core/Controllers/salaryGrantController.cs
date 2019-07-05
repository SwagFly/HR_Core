using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using IBll;
using Bll;
using IOC;
using System.Transactions;//事务包
using Newtonsoft.Json;
namespace HR_Core.Controllers
{
    public class salaryGrantController : Controller
    {
        //一级机构
        config_file_first_kindIBLL firstbll = IocType.GetIocType<config_file_first_kindBLL>("config_file_first_kindBLL", "config_file_first_kindBLL");
        //二级机构
        config_file_second_kindIBLL secondbll = IocType.GetIocType<config_file_second_kindBLL>("config_file_second_kindBLL", "config_file_second_kindBLL");
        //三级机构
        config_file_third_kindIBLL thirdbll = IocType.GetIocType<config_file_third_kindBLL>("config_file_third_kindBLL", "config_file_third_kindBLL");
        //人力资源
        human_file hf = new human_file();
        human_fileIBLL hfbll = IocType.GetIocType<human_fileBLL>("human_fileBLL", "human_fileBLL");
        //薪酬标准详情
        salary_standard_detailsIBLL sdbll = IocType.GetIocType<salary_standard_detailsBLL>("salary_standard_detailsBLL", "salary_standard_detailsBLL");
        //薪酬发放登记
        salary_grantIBLL sgbll = IocType.GetIocType<salary_grantBLL>("salary_grantBLL", "salary_grantBLL");
        //薪酬发放登记详情
        salary_grant_detailsIBLL sgdbll = IocType.GetIocType<salary_grant_detailsBLL>("salary_grant_detailsBLL", "salary_grant_detailsBLL");
        // GET: salaryGrant
        #region 薪酬发放登记
        [HttpGet]
        public ActionResult register_locate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register_locate(int submitType)
        {
            if (submitType == 1)//如果是一级机构就查询一级全部
            {
                ViewBag.submitType = 1;
                ViewBag.first = firstbll.SelectFirst_kind();
            }
            else if (submitType == 2)//如果是二级机构就查询二级全部
            {
                ViewBag.submitType = 2;
                ViewBag.second = secondbll.Second_kind();
            }
            else if (submitType == 3)//如果是三级机构就查询三级全部
            {
                ViewBag.submitType = 3;
                ViewBag.third = thirdbll.third_kind();
            }
            ViewBag.human_file = hfbll.Selecthuman_file(hf);
            return View("register_list");
        }
        //薪酬发放登记(负责人控制) 
        public ActionResult register_list()
        {
            return View();
        }
        //工资详情
        public ActionResult register_GZXQ(string id)
        {
            List<salary_standard_details> sd = sdbll.salary_standard_detailsselectWhere(id);
            return View(sd);
        }

        [HttpGet]
        public ActionResult register_commit()
        {
            //生成薪酬订单编号
            ViewBag.guid = sgbll.GetIdFF();


            int submitType =Convert.ToInt32(Request.QueryString["submitType"]);
            string id = Request.QueryString["id"];
            if (submitType==1)
            {
                ViewBag.submitType = 1;
                List<human_file> firstlist = hfbll.human_fileSelectWhere(e => e.first_kind_id == id);
                ViewBag.firsthu = firstlist;
                string[] listId = new string[firstlist.Count];
                for (int i=0;i<listId.Length ;i++) {
                    listId[i] = firstlist[i].salary_standard_id;
                }
                List<List<salary_standard_details>> detailsList =new List<List<salary_standard_details>>();
                foreach (string item in listId) {
                    detailsList.Add(sdbll.salary_standard_detailsselectWhere(item));
                }
                ViewBag.firstsd = detailsList;
            }
            else if(submitType==2)
            {
                ViewBag.submitType = 2;
                List<human_file> secondlist = hfbll.human_fileSelectWhere(e => e.second_kind_id == id);
                ViewBag.secondhu = secondlist;
                string[] listId = new string[secondlist.Count];
                for (int i = 0; i < listId.Length; i++)
                {
                    listId[i] = secondlist[i].salary_standard_id;
                }
                List<List<salary_standard_details>> detailsList = new List<List<salary_standard_details>>();
                foreach (string item in listId)
                {
                    detailsList.Add(sdbll.salary_standard_detailsselectWhere(item));
                }
                ViewBag.secondsd = detailsList;
            }
            else if (submitType==3)
            {
                ViewBag.submitType = 3;
                List<human_file> thirdlist = hfbll.human_fileSelectWhere(e => e.third_kind_id == id);
                ViewBag.thirdhu = thirdlist;
                string[] listId = new string[thirdlist.Count];
                for (int i = 0; i < listId.Length; i++)
                {
                    listId[i] = thirdlist[i].salary_standard_id;
                }
                List<List<salary_standard_details>> detailsList = new List<List<salary_standard_details>>();
                foreach (string item in listId)
                {
                    detailsList.Add(sdbll.salary_standard_detailsselectWhere(item));
                }
                ViewBag.thirdsd = detailsList;
            }
            return View();
        }
        //事务新增
        [HttpPost]
        public ActionResult register_commit(salary_grant sg,salary_grant_details [] sgd)
        {
            int num = 0;
            int j = 0;
            using (TransactionScope ts=new TransactionScope()) {
                foreach (salary_grant_details item in sgd)
                {
                    if (item.salary_paid_sum > 0)
                    {
                        j++;
                        item.salary_grant_id = sg.salary_grant_id;
                        num += sgdbll.salary_grant_detailsInsert(item);
                    }
                }
                if (sgbll.salary_grantInsert(sg) > 0 && num == j)
                {
                    ts.Complete();
                    return RedirectToAction("register_success", "salaryGrant");
                }
                else
                {
                    return View();
                }
            };
        }
        public ActionResult register_success()
        {
            return View();
        }
        #endregion
        #region 薪酬发放登记审核
        public ActionResult check_list()
        {
            return View();
        }
        /// <summary>
        /// 薪酬发放登记复核分页查询
        /// </summary>
        /// <returns></returns>
        public ActionResult FenYe2(int PageSize, int IndexPage)
        {
            string sql = string.Format(@"select * from [dbo].[salary_grant]");
            int rows = 0;//总行数
            var list = sgbll.SelectFenYeBySelect(sql, out rows, IndexPage, PageSize);
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
        //薪酬发放登记复核
        [HttpGet]
        public ActionResult check(short id)
        {
            //薪酬发放登记条件查询
            List<salary_grant> sglist = sgbll.SelectWhere(e=>e.sgr_id==id);
            ViewBag.sg = sglist;
            //薪酬标准编号
            string[] listId = new string[sglist.Count];
            //薪酬发放编号
            string[] listid2 = new string[sglist.Count];
            for (int i = 0; i < listId.Length; i++)
            {
                listId[i] = sglist[i].salary_standard_id;
                listid2[i] = sglist[i].salary_grant_id;
            }
            //根据订单编号查询薪酬标准详情
            List<salary_standard_details> sdist = new List<salary_standard_details>();
            foreach (string item in listId)
            {
                sdist.Add(sdbll.salary_standard_detailsselectWhere(item).FirstOrDefault());
            }
            ViewBag.sd = sdist;
            //根据发放编号查询薪酬发放详情
            List<salary_grant_details> sgdlist = new List<salary_grant_details>();
            foreach (string item2 in listid2)
            {
                sgdlist.Add(sgdbll.salary_grant_detailsSelectWhere(e=>e.salary_grant_id==item2).FirstOrDefault());
            }
            ViewBag.sgd = sgdlist;
            return View();
        }
        //事务修改
        [HttpPost]
        public ActionResult check(salary_grant sg,salary_grant_details [] sgd )
        {
            int num = 0;
            int j = 0;
            salary_grant sg2 = new salary_grant() {
                sgr_id=sg.sgr_id,
                salary_grant_id=sg.salary_grant_id,
                salary_standard_id=sg.salary_standard_id,
                first_kind_id=sg.first_kind_id,
                first_kind_name=sg.first_kind_name,
                second_kind_id=sg.second_kind_id,
                second_kind_name=sg.second_kind_name,
                third_kind_id=sg.third_kind_id,
                third_kind_name=sg.third_kind_name,
                human_amount=sg.human_amount,
                salary_standard_sum=sg.salary_standard_sum,
                salary_paid_sum=sg.salary_paid_sum,
                register=sg.register,
                regist_time=sg.regist_time,
                checker = sg.register,
                check_time = sg.check_time,
                check_status = 1,
            };
            using (TransactionScope ts =new TransactionScope()) {
                foreach (salary_grant_details item in sgd)
                {
                    j++;
                    num += sgdbll.salary_grant_detailsUpdate(item,item.grd_id);
                }
            if (sgbll.salary_grantUpdate(sg2, sg2.sgr_id) > 0 && num == j)
            {
                ts.Complete();
                return RedirectToAction("check_success", "salaryGrant");
            }
            else
            {
                return View();
            }
          };
        }
        public ActionResult check_success()
        {
            return View();
        }
        #endregion
        #region 薪酬发放查询 
        public ActionResult query_locate()
        {
            return View();
        }
        /// <summary>
        /// 根据薪酬单号、关键字：复核人及登记人、登记时间查询
        /// SQL拼接 
        /// </summary>
        /// <param name="salary_grant_id">薪酬发放单号</param>
        /// <param name="primary_key">登记人和复核人的模糊查询</param>
        /// <param name="regist_time">发放登记的时间</param>
        /// /// <param name="check_time">复核的时间</param>
        /// <returns></returns>
        string sql = "select * from [dbo].[salary_grant] where 1=1";
        public ActionResult SelectWhere(string salary_grant_id, string primary_key, string regist_time, string check_time)
        {
            if (salary_grant_id != null && salary_grant_id != "")
            {
                sql += string.Format(@" and [salary_grant_id]='{0}'", salary_grant_id);
            }
            else if (primary_key != null && primary_key != "")
            {
                sql += string.Format(@" and [register] like '%{0}%' or [checker] like '%{1}%'", primary_key, primary_key);
            }
            else if (regist_time != null && regist_time != "")
            {
                sql += string.Format(@" and [regist_time]> '{0}'", regist_time);
            }
            else if (check_time != null && check_time != "")
            {
                sql += string.Format(@" and [check_time]<'{0}'", check_time);
            }
            Session["sgSql"] = sql;
            return Content("ok");
        }
        /// <summary>
        /// 发放分页查询
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="IndexPage"></param>
        /// <returns></returns>
        public ActionResult SelectFenYe(int PageSize, int IndexPage)
        {
            string where = Session["sgSql"].ToString();//根据条件查询
            int rows = 0;//总行数
            var list = sgbll.SelectFenYeBySelect(where, out rows, IndexPage, PageSize);
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
        public ActionResult query_list()
        {
            return View();
        }
       
        public ActionResult query(short id)
        {
            ////人力资源按id查询
            //List<human_file> hflist = hfbll.human_fileSelectWhere(e=>e.salary_standard_id==id);
            //ViewBag.hu = hflist;
            //string[] listId = new string[hflist.Count];
            //for (int i = 0; i < listId.Length; i++)
            //{
            //    listId[i] = hflist[i].salary_standard_id;
            //}

            ////拿人力资源订单编号查询薪酬标准详情
            //List<salary_standard_details> sdist = new List<salary_standard_details>();
            //foreach (string item in listId)
            //{
            //    sdist.Add(sdbll.salary_standard_detailsselectWhere(item).FirstOrDefault());
            //}
            //ViewBag.sd = sdist;

            ////拿人力资源订单编号查询薪酬发放详情
            //List<salary_grant_details> sglist = new List<salary_grant_details>();
            //foreach (string item2 in listId)
            //{
            //    sglist.Add(sgdbll.salary_grant_detailsSelectWhere(e=>e.salary_grant_id==item2).FirstOrDefault());
            //}
            //ViewBag.sgd = sglist;
            //return View();
            //薪酬发放登记条件查询
            List<salary_grant> sglist = sgbll.SelectWhere(e => e.sgr_id == id);
            ViewBag.sg = sglist;
            //薪酬标准编号
            string[] listId = new string[sglist.Count];
            //薪酬发放编号
            string[] listid2 = new string[sglist.Count];
            for (int i = 0; i < listId.Length; i++)
            {
                listId[i] = sglist[i].salary_standard_id;
                listid2[i] = sglist[i].salary_grant_id;
            }

            //拿人力资源订单编号查询薪酬标准详情
            //根据订单编号查询薪酬标准详情
            List<salary_standard_details> sdist = new List<salary_standard_details>();
            foreach (string item in listId)
            {
                sdist.Add(sdbll.salary_standard_detailsselectWhere(item).FirstOrDefault());
            }
            ViewBag.sd = sdist;

            //根据发放编号查询薪酬发放详情
            List<salary_grant_details> sgdlist = new List<salary_grant_details>();
            foreach (string item2 in listid2)
            {
                sgdlist.Add(sgdbll.salary_grant_detailsSelectWhere(e => e.salary_grant_id == item2).FirstOrDefault());
            }
            ViewBag.sgd = sgdlist;
            return View();
        }
        #endregion
    }
}