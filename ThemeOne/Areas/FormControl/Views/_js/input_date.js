var $page = function () {

    this.init = function () {
        addEvent();
    }

    //所有元素选择器
    var selector = {
        $form: function () { return $("form") },
        $input: function () { return $("#input") },
 
    }; //selector end

    //所有事件
    function addEvent() {
        //绑定验证事件
            selector.$input().jqxDateTimeInput({ formatString: 'd',culture:"zh" });


    }; //addEvent end

    var tool = {

    }; // tool end

};


$(function () {
    var page = new $page();
    page.init();
})