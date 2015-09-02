//弹出框
function jqxAlert(msg, title) {
    if (title == null) title = "消息提醒";
    var html = "<div id=\"eventWindow\" >" +
    "<div>" + title +
        "</div>" +
    "<div>" +
    "<div class=\"body\">" +
         msg +
        "</div>" +
       " <div style=\"float: right; margin-top: 15px; height: 30px\">" +
            "<input type=\"button\" id=\"ok\" value=\"确定\" style=\"margin-right: 10px\" />" +
       " </div>" +
    "</div>" +
"</div>";
    var winObj = $(html);
    winObj.find('#ok').jqxButton({ width: '65px' });
    winObj.find('#ok').focus();
    winObj.jqxWindow({
        maxWidth: 380, minWidth: 250, width: 270,
        resizable: false, isModal: true, modalOpacity: 0.3,
        okButton: winObj.find('#ok'),
        initContent: function () {

        }
    });
}
//确定
function jqxConfirm(okFun, msg, title) {
    if (title == null) title = "消息提醒";
    var html = "<div id=\"eventWindow\" >" +
    "<div>" + title +
        " </div>" +
    "<div>" +
    "<div class=\"body\">" +
         msg +
        "</div>" +
       " <div style=\"float: right; margin-top: 15px; height: 30px\">" +
            "<input type=\"button\" id=\"ok\" value=\"确定\" style=\"margin-right: 10px\" />" +
            "<input type=\"button\" id=\"cancel\" value=\"取消\" />" +
       " </div>" +
    "</div>" +
"</div>";
    var winObj = $(html);
    winObj.find('#ok').jqxButton({ width: '65px' });
    winObj.find('#ok').click(function () {
        if (okFun != null) {
            okFun();
        }
    })
    winObj.find('#ok').focus();
    winObj.find('#cancel').jqxButton({ width: '65px' });
    winObj.jqxWindow({
        maxWidth: 380, minWidth: 250, width: 270,
        resizable: false, isModal: true, modalOpacity: 0.3,
        okButton: winObj.find('#ok'), cancelButton: winObj.find('#cancel'),
        initContent: function () {

        }
    });

}
//清除验证
function jqxValidateRemove() {
    $(".jqx-validator-hint").css({ left: -1000, top: -1000 });
}
//弹出窗口
function jqxWindow(selector, title, width, height) {
    $(selector).show();
    $(selector).removeClass("hide");
    if ($(selector).find(".jqx-window-content").size() > 0) {
        $(selector).jqxWindow("open");
    } else {
        $(selector).jqxWindow({ width: width, height: height, isModal: true, modalOpacity: 0.3,resizable:false });
    }
    $(selector).jqxWindow('setTitle', title);
    $(selector).on('close', function (event) {
        jqxValidateRemove();
    });
    $(selector).on('moving', function (event) {
        jqxValidateRemove();
    });
}





function jqxDelete(options) {
    var gridSelector = options.gridSelector;
    var url = options.url;
    var data = options.data;
    jqxConfirm(function () {
        $.ajax({
            type: "post",
            url: url,
            data: data,
            dataType: "json",
            success: function (msg) {
                if (msg.isSuccess == false) {
                    jqxAlert(msg.respnseInfo);
                }
                $(gridSelector).jqxDataTable('updateBoundData');
            }, error: function (msg) {
                console.log(msg);
            }
        })
    }, "您确定要删除吗？")
}



function jqxSubmit(options) {
    var gridSelector = options.gridSelector;
    var url = options.url;
    var form = options.form;
    var success = options.success;
    form.ajaxSubmit({
        type: "post",
        url: url,
        dataType: "json",
        success: function (msg) {
            if (msg.isSuccess == true) {
                if (success != null) {
                    success(msg);
                }
            } else {
                jqxAlert(msg.respnseInfo);
            }
        }, error: function (msg) {
            console.log(msg);
        }
    })

}


$(function () {
    $(".jqx-icon-close").on("click", function () {
        alert(1)
    })
})