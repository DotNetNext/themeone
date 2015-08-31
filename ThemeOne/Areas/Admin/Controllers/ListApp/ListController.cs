using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQWidgetsSugar;
using ThemeOne.Areas.Admin.Controllers.ListApp.Domain;
using ThemeOne.Infrastructure;
using SqlSugar;
using ThemeOne.Entities;

namespace ThemeOne.Areas.Admin.Controllers.ListApp
{
    public class ListController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Grid = JQXGrid.BindGrid("#grid", GirdModel.GetDataAdapterSource(), GirdModel.GetGridConfig());
            return View();
        }

        [HttpPost]
        public JsonResult Add(list list)
        {
            using (ListService ls = new ListService())
            {
                ActionResultModel<string> model = new ActionResultModel<string>();
                model.isSuccess = ls.Save(list);
                model.respnseInfo = model.isSuccess ? "添加成功" : "添加失败";
                return Json(model);
            }
        }
        [HttpPost]
        public JsonResult Edit(list list)
        {
            using (ListService ls = new ListService())
            {
                ActionResultModel<string> model = new ActionResultModel<string>();
                model.isSuccess = ls.Save(list);
                model.respnseInfo = model.isSuccess ? "编辑成功" : "编辑失败";

                return Json(model);
            }
        }
        [HttpPost]
        public JsonResult Del(int id)
        {
            using (ListService ls = new ListService())
            {
                ActionResultModel<string> model = new ActionResultModel<string>();
                model.isSuccess =ls.Delete(id) ;
                model.respnseInfo = model.isSuccess ? "删除成功" : "删除失败";
                return Json(model);
            }
        }


        public JsonResult ListSource(GridSearchParams pars)
        {

            using (ListService ls = new ListService())
            {
                if (pars.sortdatafield == null)
                { //默认按id降序
                    pars.sortdatafield = "id";
                    pars.sortorder = "desc";
                }
                Sqlable sable = ls.GetListSqlable();
                var model = JQXGrid.GetWidgetsSource<list>(sable, pars, "*");//根据grid的参数自动查询
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
