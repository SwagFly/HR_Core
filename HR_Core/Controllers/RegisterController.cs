using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll;
using IBll;
using IOC;
using System.Transactions;

namespace HR_Core.Controllers
{
    public class RegisterController : Controller
    {
        private engage_resumeIBLL resume_bll = IocType.GetIocType<engage_resumeBLL>("engage_resumeBLL", "engage_resumeBLL");
        private engage_interviewIBLL inter_bll = IocType.GetIocType<engage_interviewBLL>("engage_interviewBLL", "engage_interviewBLL");
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currNum"]),
                PageSize = 3
            };
            List<engage_interview> engList = inter_bll.GetLuYong();//查询所有可以录用的
            page.Rows = engList.Count;//总行数
            page.Pages = (engList.Count - 1) / page.PageSize + 1;//总页数
            List<engage_resume> list = new List<engage_resume>();
            for (int i = page.CurrentPage * page.PageSize-page.PageSize; i<page.CurrentPage*page.PageSize ; i++)
            {
                if (i<engList.Count)
                {
                    engage_resume listSon = new engage_resume()
                    {
                        res_id = Convert.ToInt16(engList[i].resume_id)
                    };
                    listSon = resume_bll.GetWhereResume(listSon);
                    list.Add(listSon);
                }
                else {
                    break;
                }
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", list);
            dic.Add("page", page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        /// <summary>
        /// 是否录取
        /// </summary>
        /// <returns></returns>
        public ActionResult GetShow(int id)
        {
            engage_interview inter = inter_bll.GetResumeIdClass(id);//面试对象
            return View(inter);
        }
        /// <summary>
        /// 查询Resume
        /// </summary>
        /// <returns></returns>
        public ActionResult GetResume()
        {
            engage_resume resume = new engage_resume()
            {
                res_id = Convert.ToInt16(Request["thisId"])
            };
            resume = resume_bll.GetWhereResume(resume);
            return Content(JsonConvert.SerializeObject(resume));
        }
        /// <summary>
        /// 修改申请复核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateRegister(string id) {
            engage_resume resume = new engage_resume()
            {
                res_id = Convert.ToInt16(id)
            };
            resume = resume_bll.GetWhereResume(resume);//查询
            resume.pass_checkComment = Request["erId"];
            engage_interview inter = inter_bll.GetResumeIdClass(resume.res_id);//面试对象
            int ok = 0;
            if (Request["erId"].Equals("申请录用"))
            {
                inter.result = "申请录用";
                //修改信息表的pass_checkComment、
            }
            else {
                inter.result = "建议面试";
            }
            using (TransactionScope ts = new TransactionScope()) {
                ok += resume_bll.UpdateResumeState(resume);
                ok += inter_bll.UpdateInter(inter);
                if (ok == 2)
                {
                    ts.Complete();//提交事务
                    return RedirectToAction("Index", "Register");
                }
                else {
                    return RedirectToAction("GetShow", "Register", inter.ein_id);
                }
            }
        }
        /// <summary>
        /// 录用审批
        /// </summary>
        /// <returns></returns>
        public ActionResult RegisterShenPi() {
            return View();
        }
        /// <summary>
        /// 审批分页
        /// </summary>
        /// <returns></returns>
        public ActionResult GetListShen()
        {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currNum"]),
                PageSize = 3
            };
            List<engage_interview> engList = inter_bll.GetShenpi();//查询所有可以录用的
            page.Rows = engList.Count;//总行数
            page.Pages = (engList.Count - 1) / page.PageSize + 1;//总页数
            List<engage_resume> list = new List<engage_resume>();
            for (int i = page.CurrentPage * page.PageSize - page.PageSize; i < page.CurrentPage * page.PageSize; i++)
            {
                if (i < engList.Count)
                {
                    engage_resume listSon = new engage_resume()
                    {
                        res_id = Convert.ToInt16(engList[i].resume_id)
                    };
                    listSon = resume_bll.GetWhereResume(listSon);
                    list.Add(listSon);
                }
                else {
                    break;
                }
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", list);
            dic.Add("page", page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        /// <summary>
        /// 审批是否通过
        /// </summary>
        /// <returns></returns>
        public ActionResult GetShowShen(int id)
        {
            engage_interview inter = inter_bll.GetResumeIdClass(id);//面试对象
            return View(inter);
        }
        /// <summary>
        /// 修改审批复核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateRegisterState(string id)
        {
            engage_resume resume = new engage_resume()
            {
                res_id = Convert.ToInt16(id)
            };
            resume = resume_bll.GetWhereResume(resume);//查询
            resume.pass_passComment = Request["erId"];
            engage_interview inter = inter_bll.GetResumeIdClass(resume.res_id);//面试对象
            int ok = 0;
            if (Request["erId"].Equals("通过"))
            {
                inter.result = "申请通过";
                //修改信息表的pass_checkComment、
            }
            else {
                inter.result = "建议面试";
            }
            using (TransactionScope ts = new TransactionScope())
            {
                ok += resume_bll.UpdateResumeState(resume);
                ok += inter_bll.UpdateInter(inter);
                if (ok == 2)
                {
                    ts.Complete();//提交事务
                    return RedirectToAction("RegisterShenPi", "Register");
                }
                else {
                    return RedirectToAction("GetShowShen", "Register", inter.ein_id);
                }
            }
        }

    }
}