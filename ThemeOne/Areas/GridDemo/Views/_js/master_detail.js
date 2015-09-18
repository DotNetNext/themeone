var $page = function () {

    this.init = function () {
        addEvent();
    }

    //所有元素选择器
    var selector = {
        $form: function () { return $("form") },
        $return_url: function () { return $("#return_url") }
    }; //selector end

    //所有事件
    function addEvent() {
        //绑定验证事件



    }; //addEvent end


    this.grid = {
        //加载2级表格
        initRowDetails: function (id, row, element, rowinfo) {
            element.append($("<div style='margin: 10px;'></div>"));
            var source =
            {
                dataType: "json",
                dataFields: [{ "name": "id", "type": "int" },
                            { "name": "name", "type": "string" },
                            { "name": "productname", "type": "string" },
                            { "name": "quantity", "type": "int" },
                            { "name": "date", "type": "date"}],
                url: "/GridDemo/MasterDetail/GetListSourceById"
            };
            var dataAdapter = new $.jqx.dataAdapter(source,
                {
                    formatData: function (data) {
                        $.extend(data, {
                            whereId: row.id
                        });
                        return data;
                    }
                }
            );
            element.find(">div:first").jqxDataTable(
            {
                width: 400,
                pageable: true,
                height: 160,
                pagerButtonsCount: 5,
                source: dataAdapter,
                columnsResize: true,
                columns: [
                     { text: '编号', dataField: 'id', width: 200 },
                     { text: '姓名', dataField: 'productname', width: 200 }
                ]
            });
        }

    }


    var tool = {

    }; // tool end

};


$(function () {
    var page = new $page();
    page.init();
})