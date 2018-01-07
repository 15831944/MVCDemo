
//过滤输入数据  保证只能输入小数或整数
function validate(textbox) {

    var txtval = textbox.value;
    var key = event.keyCode;

    if ((key < 48 || key > 57) && key != 46) {

        event.keyCode = 0;

    }

    else {

        if (key == 46) {

            if (txtval.indexOf(".") != -1 || txtval.length == 0)

                event.keyCode = 0;

        }

    }
}


             //过滤输入数据  保证只能输入小数或整数
function onlyNumber(textbox) {
    var txtval = document.getElementById(textbox).value;

    var key = event.keyCode;

    if ((key < 48 || key > 57) && key != 46) {

        event.keyCode = 0;

    }

    else {

        if (key == 46) {

            if (txtval.indexOf(".") != -1 || txtval.length == 0)

                event.keyCode = 0;

        }

    }
}




        document.documentElement.onkeydown = function(evt) {
            var b = !!evt, oEvent = evt || window.event;
            if (oEvent.keyCode == 8) {
                var node = b ? oEvent.target : oEvent.srcElement;
                var reg = /^(input|textarea)$/i, regType = /^(text|textarea)$/i;
                if (!reg.test(node.nodeName) || !regType.test(node.type) || node.readOnly || node.disabled) {
                    if (b) {
                        oEvent.stopPropagation();
                    }
                    else {
                        oEvent.cancelBubble = true;
                        oEvent.keyCode = 0;
                        oEvent.returnValue = false;
                    }
                }
            }
        }