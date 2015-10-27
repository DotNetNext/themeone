var $page = function () {

    this.init = function () {
        addEvent();
    }

    //所有元素选择器
    var selector = {
        $form: function () { return $("form") },
        $jqxImgUpload: function () { return $("#jqxImgUpload") },
        $jqxFileUpload: function () { return $("#jqxFileUpload") },
        $img: function () { return $("img") },
        $imgPath: function () { return $("#imgPath") },
        $aFile: function () { return $("#aFile") },
        $filePath: function () { return $("#filePath") }
    }; //selector end

    //所有事件
    function addEvent() {
        //绑定验证事件


        //上传图片
        var imageTypes = ['.gif', '.jpg', '.png'];
        selector.$jqxImgUpload().jqxFileUpload({ accept: imageTypes, localization: jqxLocalizationUpload, width: 300, "uploadUrl": '/FormControl/UploadFile/UploadImg', autoUpload: false, fileInputName: 'img' });
        selector.$jqxImgUpload().on('uploadEnd', function (event) {
            var args = event.args;
            var fileName = args.file;
            var serverResponce = $.convert.strToJson(args.response);
            if (serverResponce.IsError) {
                jqxAlert(serverResponce.Message)
            } else {
                selector.$img().attr("src", serverResponce.WebPath)
                selector.$imgPath().val(serverResponce.WebPath);
            }
        });


        //上传文件
        var fileTypes = ['.docx', '.txt', '.doc', '.jpg', '.gif', '.xls', '.xlsx'];
        selector.$jqxFileUpload().jqxFileUpload({ accept: fileTypes, localization: jqxLocalizationUpload, width: 300, "uploadUrl": '/FormControl/UploadFile/UploadFile', autoUpload: false, fileInputName: 'file' });
        selector.$jqxFileUpload().on('uploadEnd', function (event) {
 
            var args = event.args;
            var fileName = args.file;
            var serverResponce = $.convert.strToJson(args.response);
            if (serverResponce.IsError) {
                jqxAlert(serverResponce.Message)
            } else {
                selector.$aFile().attr("href", serverResponce.WebPath)
                selector.$aFile().text(serverResponce.FileName);
                selector.$filePath().val(serverResponce.WebPath);
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