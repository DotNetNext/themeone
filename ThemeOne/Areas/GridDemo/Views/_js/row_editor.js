var $page = function () {

    this.init = function () {
        addEvent();
    }

    //所有元素选择器
    var selector = {
        $form: function () { return $("form") },
        $return_url: function () { return $("#return_url") },
        $grid: function () { return $("#grid") }
    }; //selector end

    this.grid = {

        /***自定义事件的input***/
        initCustomEditor: function (row, cellvalue, editor, cellText, width, height) {
            var inputElement=editor.find("input")
            inputElement.css({ height: height, width: width })
            inputElement.val(cellvalue)
        },
        getCustomEditorValue: function (row, cellvalue, editor, celltext, width, height) {

            // return the editor's value.
            return editor.find('input').val();
        },
        createCustomEditor: function (row, cellvalue, editor, celltext, width, height) {

            // construct the editor.
            var inputElement = $("<input  class=\"editor_input\" style='padding-left: 4px; ;'/>").appendTo(editor);
            //改变第二格的值
            inputElement.change(function () {
                var th = $(this);
                var change_input = th.closest("tr").find(".change_input");
                change_input.val("上一格的值拿过来了" + inputElement.val());
            })
            inputElement.css({ height: height, width: width })
            inputElement.val(cellvalue);
        },

        /***普通的input***/
        initInputEditor: function (row, cellvalue, editor, cellText, width, height) {
            // construct the editor.
            var inputElement=editor.find("input")
            inputElement.css({ height: height, width: width })
            inputElement.val(cellvalue)
        },
        getInputEditorValue: function (row, cellvalue, editor, celltext, width, height) {

            var inputElement = editor.find('input');
            return inputElement.val();
        },
        createInputEditor: function (row, cellvalue, editor, celltext, width, height, n) {
            // construct the editor.
            var inputElement = $("<input class='editor_input change_input' class='editor_input' style='padding-left: 4px; ;'/>").appendTo(editor);
            inputElement.css({ height: height, width: width })
            inputElement.val(cellvalue);
        }



    }

    //所有事件
    function addEvent() {
        //绑定验证事件
        selector.$grid().on('rowEndEdit',
            function (event) {
                // event args.
                var args = event.args;
                // row data.
                var row = args.row;
                // row index.
                var index = args.index;
                // row's data bound index.
                var boundIndex = args.boundIndex;
                // row key.
                var key = args.key;

                alert("这儿调用数据库更新方法");
 
            });


    }; //addEvent end

    var tool = {

    }; // tool end

};


$(function () {
    var page = new $page();
    page.init();
})