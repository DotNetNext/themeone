using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQWidgetsSugar;

namespace ThemeOne.Areas.GridDemo.Controllers.ColumnsHierachiesApp
{
    public class ColHieModel
    {
        /// <summary>
        /// grid数据设置
        /// </summary>
        /// <returns></returns>
        public static GridDataAdapterSource GetDataAdapterSource()
        {
            var adp = new GridDataAdapterSource();
            adp.url = "/griddemo/ColumnsHierarchies/GetListSource";//数据源地址
            return adp;
        }
        /// <summary>
        /// grid参数设置
        /// </summary>
        /// <returns></returns>
        public static GridConfig GetGridConfig()
        {
            var gc = new GridConfig();
            gc.filterMode = FileModel.advanced;//高级筛选模式
            gc.pageSize = 20;
            gc.width = "90%";
            gc.showToolbar = false;
            gc.filterable = false;
            gc.columns = new List<GridColumn>(){
               new GridColumn(){ text="编号", datafield="id", width="40px", cellsalign=AlignType.left,datatype=Datatype.dataint  },
               new GridColumn(){ text="名称", datafield="name", cellsalign=AlignType.left,datatype=Datatype.datastring,columngroup="group1" },
               new GridColumn(){ text="产品名", datafield="productname", cellsalign=AlignType.left,datatype=Datatype.datastring ,columngroup="group1"},
               new GridColumn(){ text="数量", datafield="quantity", cellsalign=AlignType.right , datatype=Datatype.dataint,columngroup="group2" },
               new GridColumn(){ text="创建时间", datafield="date", cellsformat="yyyy-MM-dd",cellsalign=AlignType.right, datatype=Datatype.datadate ,columngroup="group2"
              }
            };
            gc.columnGroups = new List<ColumnGroups>()
            {
                new ColumnGroups(){ name="group1", text="标题1", align=AlignType.center},
                new ColumnGroups(){ name="group2", text="标题2", align=AlignType.center}
            };
            return gc;
        }
    }
}