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

    var tool = {

    }; // tool end

};


$(function () {
    var page = new $page();
    page.init();
})