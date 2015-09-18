using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQWidgetsSugar;

namespace ThemeOne.Areas.GridDemo.Controllers.LockApp
{
    public class LockGridModel
    {
        /// <summary>
        /// grid数据设置
        /// </summary>
        /// <returns></returns>
        public static GridDataAdapterSource GetDataAdapterSource()
        {
            var adp = new GridDataAdapterSource();
            adp.url = "/griddemo/default/GetListSource";//数据源地址
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
            gc.width = "90%";
            gc.columns = new List<GridColumn>(){
               new GridColumn(){ text="编号", datafield="id", width="40px", cellsalign=AlignType.left,datatype=Datatype.dataint, pinned=true  },
               new GridColumn(){ text="名称", datafield="name",width="200px", cellsalign=AlignType.left,datatype=Datatype.datastring, pinned=true },
               new GridColumn(){ text="产品名", datafield="productname",width="1000px", cellsalign=AlignType.left,datatype=Datatype.datastring },
               new GridColumn(){ text="数量", datafield="quantity", width="800px", cellsalign=AlignType.right , datatype=Datatype.dataint },
               new GridColumn(){ text="创建时间", datafield="date",width="200px", cellsformat="yyyy-MM-dd",cellsalign=AlignType.right, datatype=Datatype.datadate 
              }
            };
            return gc;
        }

    }
}