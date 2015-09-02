var $page = function () {

    this.init = function () {
        addEvent();
    }
    //所有元素选择器
    var selector = {
        $form: function () { return $("form") },
        $userName: function () { return $("#user_name"); },
        $password: function () { return $("#password"); },
        $btnSubmit: function () { return $("#btnSubmit"); },
        $btnRest: function () { return $("#btnRest"); },
        $return_url: function () { return $("#return_url") }
    }; //selector end

    //所有事件
    function addEvent() {
        //绑定验证事件
        selector.$form().jqxValidator({
            rules: [
                  { input: selector.$userName().selector, message: '长度为3到15个字符!', action: 'keyup, blur', rule: 'length=3,12' },
                  { input: selector.$password().selector, message: '长度为3到15个字符!', action: 'keyup, blur', rule: 'length=3,12' }
            ]
        });

        //绑定提交事件
        selector.$btnSubmit().on('click', function () {
            var isSuccess = selector.$form().jqxValidator('validate');
            if (isSuccess) {
                jqxSubmit({
                    url: "/user/loginsubmit",
                    form: selector.$form(),
                    success: function (msg) {
                        $.response.redirect(selector.$return_url().val());
                    }
                })
            }
        });

        //绑定重置事件
        selector.$btnRest().on('click', function () {
            selector.$form().formClear();
        });

        //绑定表单回车事件
        $("input").keydown(function (e) {
            if (e.keyCode == 13) {
                selector.$btnSubmit().click();
            }
        });


    }; //addEvent end

    var tool = {

    }; // tool end

};


$(function () {
    var page = new $page();
    page.init();
})