using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQWidgetsSugar;
using ThemeOne.Infrastructure;
using SqlSugar;
using ThemeOne.Entities;

namespace ThemeOne.Areas.GridDemo.Controllers.MasterDetailApp
{
    /// <summary>
    /// 二级表格
    /// </summary>
    public class MasterDetailController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Grid = JQXGrid.BindGrid("#grid", MasterDetailGrid.GetDataAdapterSource(), MasterDetailGrid.GetGridConfig());
            return View();
        }
        public JsonResult GetListSource(GridSearchParams pars)
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

        public JsonResult GetListSourceById(GridSearchParams pars,int whereId)
        {

            using (ListService ls = new ListService())
            {
                if (pars.sortdatafield == null)
                { //默认按id降序
                    pars.sortdatafield = "id";
                    pars.sortorder = "desc";
                }
                Sqlable sable = ls.GetListSqlable().Where("id=@id");
                var model = JQXGrid.GetWidgetsSource<list>(sable, pars, "*", new  { id=whereId});//根据grid的参数自动查询
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
