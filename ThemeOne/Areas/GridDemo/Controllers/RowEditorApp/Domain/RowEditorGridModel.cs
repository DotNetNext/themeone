using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQWidgetsSugar;

namespace ThemeOne.Areas.GridDemo.Controllers.RowEditorApp
{
    public class RowEditorGridModel
    {
        /// <summary>
        /// grid数据设置
        /// </summary>
        /// <returns></returns>
        public static GridDataAdapterSource GetDataAdapterSource()
        {
            var adp = new GridDataAdapterSource();
            adp.url = "/griddemo/RowEditor/GetListSource";//数据源地址
            return adp;
        }
        /// <summary>
        /// grid参数设置 
        /// </summary>
        /// <returns></returns>
        public static GridConfig GetGridConfig()
        {
            var gc = new GridConfig();
            gc.filterMode = FilterModel.advanced;//高级筛选模式
            gc.showToolbar = false;
            gc.pageSize = 20;
            gc.editable = true;
            gc.width = "50%";
            gc.columns = new List<GridColumn>(){
                 new GridColumn(){ text="编号", datafield="id", width="80px", cellsalign=AlignType.left,datatype=Datatype.dataint
                  },
                    new GridColumn(){ text="名称", datafield="name",columntype= ColumnType.template, cellsalign=AlignType.left,datatype=Datatype.datastring,
                  initEditor="new $page().grid.initCustomEditor", 
                  getEditorValue="new $page().grid.getCustomEditorValue" , 
                  createEditor="new $page().grid.createCustomEditor"},
                    new GridColumn(){ text="产品名", datafield="productname",columntype= ColumnType.template, cellsalign=AlignType.left,datatype=Datatype.datastring,// BUG 使用createEditor , cellsformat一定要等于空 并且不能锁表头
                   initEditor="new $page().grid.initInputEditor", 
                   getEditorValue="new $page().grid.getInputEditorValue" , 
                   createEditor="new $page().grid.createInputEditor"}
                  
            };
            return gc;
        }
    }
}