using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQWidgetsSugar;

namespace ThemeOne.Areas.GridDemo.Controllers.DefaultApp
{
    public class DefaultGridModel
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
            gc.filterMode = FileModel.advanced;//高级筛选模式
            gc.gridbuttons = new List<GridButton>()
            {
               new GridButton(){ click="new $page().gridMethod.add", name="addbutton", icon="jqx-icon-plus", title="添加"},
               new GridButton(){ click="new $page().gridMethod.edit", name="editbutton", icon="jqx-icon-edit", title="编辑"},
               new GridButton(){ click="new $page().gridMethod.del", name="delbutton", icon="jqx-icon-delete", title="删除"}
            };
            gc.pageSize = 20;
            gc.width = "90%";
            gc.columns = new List<GridColumn>(){
               new GridColumn(){ text="编号", datafield="id", width="40px", cellsalign=AlignType.left,datatype=Datatype.dataint  },
               new GridColumn(){ text="名称", datafield="name", cellsalign=AlignType.left,datatype=Datatype.datastring },
               new GridColumn(){ text="产品名", datafield="productname", cellsalign=AlignType.left,datatype=Datatype.datastring },
               new GridColumn(){ text="数量", datafield="quantity", cellsalign=AlignType.right , datatype=Datatype.dataint },
               new GridColumn(){ text="创建时间", datafield="date", cellsformat="yyyy-MM-dd",cellsalign=AlignType.right, datatype=Datatype.datadate 
              }
            };
            return gc;
        }


      
    }
}