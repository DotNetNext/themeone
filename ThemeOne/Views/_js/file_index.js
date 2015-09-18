var $page = function () {

    this.init = function () {
        addEvent();
    }

    //所有元素选择器
    var selector = {
        $form: function () { return $("form") },
        $jqxFileUpload: function () { return $("#jqxFileUpload") },
        $img: function () { return $("img") },
        $imgPath: function () { return $("#imgPath") }
    }; //selector end

    //所有事件
    function addEvent() {
        //绑定验证事件

        var imageTypes = ['.gif', '.jpg', '.png'];
            selector.$jqxFileUpload().jqxFileUpload({ accept: imageTypes, localization: jqxLocalizationUpload, width: 300, "uploadUrl": '/File/UploadImg', autoUpload: false, fileInputName: 'img' });
            selector.$jqxFileUpload().on('uploadEnd', function (event) {
                var args = event.args;
                var fileName = args.file;
                var serverResponce = $.convert.strToJson($(args.response).text());
                if (serverResponce.IsError) {
                    jqxAlert(serverResponce.Message)
                } else {
                   selector.$img().attr("src", serverResponce.WebPath)
                   selector.$imgPath().val(serverResponce.WebPath);
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