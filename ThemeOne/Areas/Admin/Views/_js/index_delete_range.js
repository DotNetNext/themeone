
var $page = function () {

    this.init = function () {
        addEvent();
    }

    //所有元素选择器
    var selector = {
        //表格
        $grid: function () { return $("#grid") },
        //表单元素
        $form: function () { return $("#frmtable") },
        $date: function () { return $("#date") },
        $editButton: function () { return $("#editbox button") },
        $editButtonCancel: function () { return $("#editbox #cancel") },
        $editButtonSave: function () { return $("#editbox #save") },
        $editbox: function () { return $("#editbox") }



    }; //selector end

    this.gridMethod = {
        //添加
        add: function (row) {
            save(row, true);
        },

        //编辑
        edit: function (row) {
            save(row, false);
        },

        //删除
        del: function (row) {
            var grid = selector.$grid();
            selection = [];
            grid.find(".jqx_datatable_checkbox:checked").each(function () {
                var th = $(this);
                if (th.is(":checked")) {
                    var index = th.attr("index");
                    var data = grid.jqxDataTable('getRows')[index];
                    selection.push(data.id);
                }
            })
            if (selection.length == 0) {
                jqxAlert('请选择一条记录！')
                return;
            }
            jqxDelete({ gridSelector: selector.$grid().selector,
                url: "/Admin/List/DelRange",
                data: { ids: selection }
            });
        }
    }


    //所有事件
    function addEvent() {
        selector.$date().jqxDateTimeInput({ formatString: 'd', culture: "zh" });
        //绑定验证事件
        selector.$form().jqxValidator({
            rules: [
                  { input: "#name", message: '长度为3到15个字符!', action: 'keyup, blur', rule: 'length=3,12' },
                  { input: "#quantity", message: '必需为数字!', action: 'keyup, blur', rule: 'number' },
                  { input: "#quantity", message: '必填!', action: 'keyup, blur', rule: 'required' }
            ]
        });

    }; //addEvent end


    var tool = {

    }; // tool end


    //other method
    function save(row, isAdd) {
        var isEdit = !isAdd;
        if (isEdit) {
            if (row == null) {
                jqxAlert('请选择一条记录！')
                return;
            }
        }
        //弹出框
        jqxWindow(selector.$editbox().selector, isAdd ? "添加" : "编辑", 330, "auto");

        //美化 button
        selector.$editButton().jqxButton();

        //取消事件
        selector.$editButtonCancel().unbind();
        selector.$editButtonCancel().on('click', function (e) {
            selector.$editbox().jqxWindow("close");
        });

        if (isAdd) {
            //清空表单
            selector.$form().formClear();
        } else {
            //格日化日期
            row.date = $.convert.toDate(row.date, "yyyy-MM-dd")
            //通过JSON自动填充表单，也可以自已实现
            selector.$form().formFill({ data: row })
        }
        //确定事件
        selector.$editButtonSave().unbind();
        selector.$editButtonSave().on('click', function (e) {
            var isSuccess = selector.$form().jqxValidator('validate');
            if (isSuccess) {
                var url = isAdd ? "/admin/list/add" : "/admin/list/edit";
                jqxSubmit({
                    url: url,
                    form: selector.$form(),
                    success: function (msg) {
                        if (msg.isSuccess == false) {
                            jqxAlert(msg.respnseInfo);
                        }
                        selector.$grid().jqxDataTable('updateBoundData');
                        $("#editbox").jqxWindow("close")
                    }
                })
            }
        });

    }
};


$(function () {
    var page = new $page();
    page.init();
})


 