using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQWidgetsSugar;
using ThemeOne.Entities;
using ThemeOne.Infrastructure;
using SqlSugar;

namespace ThemeOne.Areas.GridDemo.Controllers.CheckboxApp
{
    /// <summary>
    /// checkbox多选
    /// </summary>
    public class CheckboxController : Controller
    {
        private ListService ls;
        public CheckboxController(ListService ls)
        {
            this.ls = ls;
        }
        public ActionResult Index()
        {
            ViewBag.Grid = JQXGrid.BindGrid("#grid", CheckboxGridModel.GetDataAdapterSource(), CheckboxGridModel.GetGridConfig());
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
        public JsonResult DelRange(int[] ids)
        {
            ActionResultModel<string> model = new ActionResultModel<string>();
            model.isSuccess = ls.DeleteRange(ids);
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
            GC.Collect();
            return Json(model, JsonRequestBehavior.AllowGet);

        }

    }
}
