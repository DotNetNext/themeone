using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQWidgetsSugar;
using ThemeOne.Infrastructure;
using SqlSugar;
using ThemeOne.Entities;


namespace ThemeOne.Areas.GridDemo.Controllers.DefaultApp
{

    public class DefaultController : Controller
    {
        ListService ls;
        public DefaultController(ListService ls)
        {
            this.ls = ls;
        }
        public ActionResult Index()
        {
            ViewBag.Grid = JQXGrid.BindGrid("#grid", DefaultGridModel.GetDataAdapterSource(), DefaultGridModel.GetGridConfig());
            return View();
        }

        [HttpPost]
        public JsonResult Add(list list)
        {

            ActionResultModel<string> model = new ActionResultModel<string>();
            model.isSuccess = ls.Save(list);
            model.respnseInfo = model.isSuccess ? "添加成功" : "添加失败";
            return Json(model);
        }
        [HttpPost]
        public JsonResult Edit(list list)
        {

            ActionResultModel<string> model = new ActionResultModel<string>();
            model.isSuccess = ls.Save(list);
            model.respnseInfo = model.isSuccess ? "编辑成功" : "编辑失败";
            return Json(model);
        }
        [HttpPost]
        public JsonResult Del(int id)
        {

            ActionResultModel<string> model = new ActionResultModel<string>();
            model.isSuccess = ls.Delete(id);
            model.respnseInfo = model.isSuccess ? "删除成功" : "删除失败";
            return Json(model);
        }

        public JsonResult GetListSource(GridSearchParams pars)
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
