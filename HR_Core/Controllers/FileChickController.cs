using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using IBll;
using Bll;
using IOC;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace HR_Core.Controllers
{
    public class FileChickController : Controller
    {
        private human_fileIBLL file_bll = IocType.GetIocType<human_fileBLL>("human_fileBLL", "human_fileBLL");
        // GET: FileChick
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询全部的信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            List<human_file> list = file_bll.ListFile();
            ViewBag.count = list.Count;
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 复核页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetShow(string id)
        {
            Int16 humanId = Convert.ToInt16(id);
            human_file file = file_bll.SelectHuanm(e => e.huf_id == humanId);
            return View(file);
        }
        /// <summary>
        /// 复核修改
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult UpdateFile(human_file file) {
            human_file fileUpdate = file_bll.SelectHuanm(e => e.huf_id == file.huf_id);
            fileUpdate.check_time = file.check_time;
            fileUpdate.checker = file.checker;
            fileUpdate.change_time = DateTime.Now;
            fileUpdate.lastly_change_time = DateTime.Now;
            fileUpdate.remark = file.remark;
            if (file_bll.UpdateFile(fileUpdate) > 0)
            {
                return View("Index");
            }
            else {
                return RedirectToAction("GetShow", "FileChick", file.human_id);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectList() {
            return View();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult ListFile(human_file file) {
            int i = 0;
            List<human_file> list = new List<human_file>();
            Expression<Func<human_file, bool>> where = (e => e.huf_id > 0);
            if (file.first_kind_id != "" && file.first_kind_id != null)
            {
                where = (e => e.first_kind_id == file.first_kind_id);
                i++;
                if (file.second_kind_id != "" && file.second_kind_id != null)
                {
                    i++;
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id);
                    if (file.third_kind_id != "" && file.third_kind_id != null)
                    {
                        i++;
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id);
                    }
                }
            }

            if (i == 1) {
                where = (e => e.first_kind_id == file.first_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null) {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            else if (i == 2) {
                where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            else if (i == 3) {
                where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            list = file_bll.ListWhere(where);
            return View(list);
        }
        /// <summary>
        /// 单纯的查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>e
        public ActionResult SelectShow(string id) {
            human_file file = new human_file() {
                huf_id = Convert.ToInt16(id)
            };
            file = file_bll.SelectHuanm(e => e.huf_id == file.huf_id);
            return View(file);
        }
        /// <summary>
        /// 变更的模糊查询页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateSelect() {
            return View();
        }
        /// <summary>
        /// 更改列表
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult UpdateListShow(human_file file) {
            int i = 0;
            List<human_file> list = new List<human_file>();
            Expression<Func<human_file, bool>> where = (e => e.huf_id > 0);
            if (file.first_kind_id != "" && file.first_kind_id != null)
            {
                where = (e => e.first_kind_id == file.first_kind_id);
                i++;
                if (file.second_kind_id != "" && file.second_kind_id != null)
                {
                    i++;
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id);
                    if (file.third_kind_id != "" && file.third_kind_id != null)
                    {
                        i++;
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id);
                    }
                }
            }

            if (i == 1)
            {
                where = (e => e.first_kind_id == file.first_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            else if (i == 2)
            {
                where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            else if (i == 3)
            {
                where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            list = file_bll.ListWhere(where);
            return View(list);
        }
        /// <summary>
        /// 修改展示页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateShow(string id) {
            human_file file = new human_file() {
                huf_id=Convert.ToInt16(id)
            };
            file = file_bll.SelectHuanm(e => e.huf_id == file.huf_id);
            return View(file);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePage"></param>
        /// <returns></returns>
        public ActionResult UpdateData(human_file filePage) {
            if (file_bll.UpdateFile(filePage) > 0)
            {
                return RedirectToAction("UpdateSelect", "FileChick");
            }
            else {
                return RedirectToAction("UpdateShow", "FileChick", filePage.huf_id);
            }
        }

    }
}