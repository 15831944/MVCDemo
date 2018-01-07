//===================javascript Date format(js日期格式化)===========================
// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18
//var time1 = new Date().Format("yyyy-MM-dd");
//var time2 = new Date().Format("yyyy-MM-dd HH:mm:ss"); 
//============================================================================ 
Date.prototype.Format = function(fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

function FormatNumber(number, format) {
    
    if (isNaN(number) || (number<=0)) {
        alert("请输入数字");
        return false;

    }
    var strNumber = number.toString();
    var result="";
    for (var i = 1;i<= strNumber.length; i++) {
        if (strNumber.indexOf("0") == 0) {
            result = strNumber.substring(i, strNumber.length);
        }
        else {break;}
    }
    
        if ((format - strNumber.length) > 0) {
            var strAdd = "";
            for (i = 1; i <= (format - strNumber.length); i++) {
                strAdd = strAdd + "0";
            }
            return strAdd + strNumber;
        }
    
    else {return strNumber;}
}

function onlyNumber() {
    //            var val = document.getElementById("tb_txtNum").value;
    //            if (!((/(^[0-9]\d*$)/).test(val))) {

    //                document.getElementById("tb_txtNum").value = val.replace(/\D/g, '');
    //                return false;
    //            }
    //var txtval = textbox.value;
    var key = event.keyCode;
    if ((key < 48 || key > 57) && key != 46) {
        event.keyCode = 0;
    }
    else {
        if (key == 46) {
            //if (txtval.indexOf(".") != -1 )
            event.keyCode = 0;
        }
    }
}

//=============
//JS loading 效果
//js添加遮罩层，在遮罩层上添加loading效果
//=============
function AddElement() {
    var over = document.createElement("div");
    document.body.appendChild(over);
    over.id = "over";
    over.setAttribute("style", "display: block;position: absolute;top: 0;left: 0;width: 100%;height: 100%;background-color: #f5f5f5;opacity:0.5; z-index: 1000;")

    var layout = document.createElement("div")
    document.body.appendChild(layout);
    layout.id = "layout";
    layout.setAttribute("style", "display: block;position: absolute;top: 40%;left: 40%; width: 20%; height: 20%; z-index: 1001; text-align:center;");

    var img = document.createElement("img")
    layout.appendChild(img)
    img.id = "loadimg";
    img.setAttribute("src", "../image/loading.gif")
}


function DelLoadingEffection() {
    //var div = document.getElementById("loadimg");
    //div.parentNode.removeChild(div);
    ////div.removeNode(true);
    //var div1 = document.getElementById("over");
    ////div1.removeNode(true);
    //div.parentNode.removeChild(div);
    //var div2 = document.getElementById("layout");
    ////div2.removeNode(true);
    //div.parentNode.removeChild(div);
    var f = document.getElementById("All");
    var childs = f.childNodes;
    for (var i = childs.length - 1; i >= 0; i--) {
        alert(childs[i].nodeName);
        f.removeChild(childs[i]);
    }


}
//==========
//打开页面并传递参数
//
//==========
function openwindow(id,url) {
    u = url
    u += "?ID=" + id;
    var newwin = window.open(u, 'Edit', 'toolbar=no,,menubar=no,location=no,scrollbars=no,height=390,width=800');
    //toolbar=no,,menubar=no,location=no,scrollbars=no
    //resizable=no,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,left=' + (window.screen.width - 810) / 2 + ',top=' + (screen.height - 400) / 2 + ',height=390,width=800

    newwin.focus()
    return false
}