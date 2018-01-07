<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="LotManage.aspx.cs" Inherits="Material_LotManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
        .hide {
            display: none;
        }

        .labelinfo {
            /*font-size: 14px;
            color: #666;
            font-weight: 700;
            padding-right: 10px;
            height: 42px;
            width: 75px;
            display: inline-block;
            text-align: right;*/
            display: inline-block;
            /*float: left;*/
            height: 42px;
            width: 75px;
            margin-right: 5px;
            line-height: 42px;
            font-size: 14px;
            color: #666;
            font-weight: 700;
            text-align: right;
            /*border:solid;*/
        }

        .txtinfo {
            box-sizing: border-box;
            height: 28px;
            Width: 213px;
        }

        .tb tr td {
            width: 350px;
            text-align: left;
            /*border:solid;*/
        }

        .tb {
            margin-left: auto;
            margin-right: auto;
        }
        .table-c table{border-right:1px solid #F00;border-bottom:1px solid #F00}
.table-c table td{border-left:1px solid #F00;border-top:1px solid #F00}
        /*fieldset {
            text-align: center;
        }*/
    </style>
    <script src="../JS/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //工单
            //=========1===============
            $("#ContentPlaceHolder1_txtWorkOrder").mouseenter(function () {
                $("#divChkListWorkOrder").slideDown("fast");
            });

            $("#divMultiWorkOrder").mouseleave(function () {
                $("#divChkListWorkOrder").slideUp("fast");
            });
            //========2=================
            //$("#cblWorkOrder_0").click(function () {
            //    $("#divChkListWorkOrder :checkbox").attr("checked", this.checked);
            //    if (this.checked == false) {
            //        $("#txtWorkOrder").val("");
            //    }
            //    if (this.checked == true) {
            //        $("#divChkListWorkOrder :checkbox").each(function () {
            //            $("#txtWorkOrder").val($("#txtWorkOrder").val() + $(this).next().text() + ",");
            //        })
            //    };
            //});
            //=================3===========
            $("#divChkListWorkOrder :checkbox").each(function () {
                $(this).click(function () {
                    var $txtList = $("#ContentPlaceHolder1_txtWorkOrder");
                    if (this.checked && $(this).attr("value") != "全选") {
                        //$txtList.val($txtList.val() + $(this).next().text() + ",");
                        $txtList.val($(this).next().text());
                    } else {
                        //$txtList.val($txtList[0].value.replace($(this).next().text() + ',', ''));
                        $txtList.val("");
                    }
                });
            });

        })
        //$(function () {
        //    var width = $('#tbworkorder').css('width');//document.getElementById('tbworkorder').offsetWidth;
        //    var tbprocess = document.getElementById('tbprocess');//.style.width = 1064;
        //    tbprocess.style.cssText = "width:1064px;margin-left:auto;margin-right:auto";

        //})

        function KeyNumber(ob) {
            //只能输入数字和小数点
            if (!ob.value.match(/^[\+\-]?\d*?\.?\d*?$/)) ob.value = ob.t_value; else ob.t_value = ob.value; if (ob.value.match(/^(?:[\+\-]?\d+(?:\.\d+)?)?$/)) ob.o_value = ob.value;

        }
        function NumberOnly(ob) {
            var c = ob;
            if (/[^\d]/.test(c.value)) {//替换非数字字符  
                var temp_amount = c.value.replace(/[^\d]/g, '');
                ob.value = (temp_amount);
            }
        }
        function EnterTextBox() {


            if (event.keyCode == 13 && document.getElementById("<%=txtLotCount.ClientID%>").value != "") {
                //批次长度和宽度是否输入====================================================================
<%--                if (document.getElementById("<%=txtLotLength.ClientID%>").value == "") {
                    alert("请先输入批次长度！");
                    return false;
                }
                if (document.getElementById("<%=txtLotWidth.ClientID%>").value == "") {
                    alert("请先输入批次宽度！");
                    return false;
                }--%>
                event.keyCode = 9;
                event.returnValue = false;
                document.getElementById("<%=txtBtnEnter.ClientID %>").click();
            }
        }

        function EnterTextBoxWO() {
            if (event.keyCode == 13 && document.getElementById("<%=txtWorkOrder.ClientID%>").value != "") {
                event.keyCode = 9;
                event.returnValue = false;
                document.getElementById("<%=btnWOEnter.ClientID %>").click();
            }
        }

        function writeFile(content) {
            //"C:\Program Files\Seagull\BarTender Suite\BarTender\bartend.exe" /F="D:\BT32\Pallet.btw" /D="D:\BT32\Pallet.txt" /P /x
            var fso, f, s, filename, f2
            fso = new ActiveXObject("Scripting.FileSystemObject");
            filename = 'C://BT32//FilmLabel.txt'
            if (fso.FileExists(filename) == true) {
                f2 = fso.GetFile(filename);
                f2.Delete();
            }
            //filecontent = document.getElementById('<%=txtLotCount.ClientID %>').value

            f = fso.OpenTextFile(filename, 8, true);
            f.WriteLine(content);
            f.Close();
        }
        function PrintLabel() {
            var labelContent = document.getElementById('<%=txtLotCount.ClientID %>').value;
            var content = '';
            var boxqty = 0;
            var qty = 0;


            //循环取明细表的值
            var gv = document.getElementById('<%=grd.ClientID%>');
            //去掉表头行循环i从1开始
            var printContent = "";
            for (var i = 1; i < gv.rows.length; i++) {
                //for (var j = 0; j < gv.rows[i].cells.length; j++) {
                //    content += gv.rows[i].cells[j].innerHTML + ',';
                //    if (j == 2) {
                //        boxqty++;
                //    }
                //    if (j == 3) {
                //        qty += parseInt(gv.rows[i].cells[j].innerHTML);
                //    }
                //}
                qty++;
                printContent += gv.rows[i].cells[0].innerHTML + '\r\n';
            }

            //labelContent = labelContent + ',' + boxqty + ',' + qty + ',' + content.substr(0, content.length - 1);
            writeFile(printContent);
            //bartender9.01是否安装
            fso = new ActiveXObject("Scripting.FileSystemObject");
            filename = 'C://Program Files//Seagull//BarTender Suite//bartend.exe';
            filename64 = 'C://Program Files (x86)//Seagull//BarTender Suite//bartend.exe';
            //C:\Program Files (x86)\Seagull\BarTender Suite\bartend.exe
            //bartender10.1路径
            if ((fso.FileExists(filename) != true) && (fso.FileExists(filename64) != true)) {
                alert("请先安装Bartender10.1软件，目前无法打印");
                return false;
            }
            var WshShell = new ActiveXObject("WScript.Shell");
            var exeContent = "bartend.exe /F=\"C:\\BT32\\MouldLabel.btw\" /D=\"C:\\BT32\\FilmLabel.txt\" /P /x"
            //exeContent = "ping 192.168.1.55";
            WshShell.run(exeContent);
            alert("操作成功，共打印" + qty + "张标签");
            //刷新页面
            window.location.replace("../Material/Createlot.aspx");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />备料模块-创建条码
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="确定"
                            CssClass="daohang_btn_saveclose" OnClientClick="" OnClick="btnSaveClose_Click" /></li>
                    <%--                    <li>
                        <asp:Button ID="btnEdit" runat="server" Text="修改"
                            CssClass="daohang_btn_edit" /></li>
                    <li>
                        <asp:Button ID="btnReset" runat="server" OnClientClick="ClearAllTextBox()" Text="重置"
                            CssClass="daohang_btn_reset" /></li>
                    <li>
                        <input type="button" class="daohang_btn_return" value="返回" onclick="window.location.reload('SpcWriter_Index.aspx');" /></li>--%>
                </ul>
            </div>
            <!--end button-->
        </div>

    </div>

    <div id="worksite">

        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>工单信息</legend>

            <table class="tb" id="tbworkorder">
                <tr>
                    <%--                    <td>
                        <label class="labelinfo">工单：</label>
                        <asp:DropDownList ID="ddlWorkorder" runat="server" CssClass="txtinfo" AutoPostBack="True" OnTextChanged="ddlWorkorder_TextChanged"></asp:DropDownList>
                    </td>--%>
                    <td>
                        <table class="sss">
                            <tr>
                                <td style="width: auto">
                                    <label class="labelinfo">工单：</label>
                                </td>
                                <td>
                                    <div id="divMultiWorkOrder">
                                        <asp:TextBox ID="txtWorkOrder" runat="server" CssClass="txtinfo"></asp:TextBox>
                                        <div id="divChkListWorkOrder" style="display: none; border: solid 1px #e8e8e8; position: fixed; z-index: 100; height: 160px; width: 213px; overflow-y: scroll; background-color: White">
                                            <asp:CheckBoxList ID="cblWorkOrder" runat="server" RepeatLayout="Table" RepeatDirection="Vertical">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <label class="labelinfo">车间：</label>
                        <asp:TextBox ID="txtWorkshopID" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>
                        <asp:Button ID="btnWOEnter" runat="server" CssClass="hide" Text="Button" OnClick="btnWOEnter_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </fieldset>

    </div>
    <div>
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>BOM信息</legend>

            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">BOM：</label>
                        <asp:TextBox ID="txtBOMID" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelinfo">工艺路线：</label>
                        <asp:TextBox ID="txtWorkflow" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>
                        <asp:TextBox ID="txtWorkflowID" runat="server" CssClass="hide"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelinfo">工单类型：</label>
                        <asp:TextBox ID="txtWorkorderType" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="labelinfo">品名：</label>
                        <%-- <asp:DropDownList ID="ddlMouldPinMin" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtMouldPinMin" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                    <td>

                        <label class="labelinfo">型号：</label>
                        <%--<asp:DropDownList ID="ddlMouldType" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtMouldType" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                    <td>

                        <label class="labelinfo">PET型号：</label>
                        <%--<asp:DropDownList ID="ddlMouldPETType" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtMouldPETType" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="labelinfo">工单长度：</label>
                        <%--<asp:DropDownList ID="ddlMouldLength" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtMouldLength" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>

                    </td>
                    <td>
                        <label class="labelinfo">工单宽度：</label>
                        <%--<asp:DropDownList ID="ddlMouldWidth" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtMouldWidth" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>

                    </td>
                    <td>
                        <label class="labelinfo">工单厚度：</label>
                        <%-- <asp:DropDownList ID="ddlMouldThinkness" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtMouldThinkness" runat="server" CssClass="txtinfo" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="labelinfo">批次长度：</label>
                        <%--<asp:DropDownList ID="ddlMouldLength" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtLotLength" runat="server" CssClass="txtinfo" onkeyup="NumberOnly(this);"></asp:TextBox>

                    </td>
                    <td>
                        <label class="labelinfo">批次宽度：</label>
                        <%--<asp:DropDownList ID="ddlMouldWidth" runat="server" CssClass="txtinfo"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtLotWidth" runat="server" CssClass="txtinfo" onkeyup="NumberOnly(this);"></asp:TextBox>

                    </td>
                    <td></td>
                </tr>

            </table>
            <div>
                <table id="tbprocess" style="">
                    <tr>
                        <td style="text-align: left;">
                            <label class="labelinfo">批次流程：</label>
                            <asp:Label ID="lblProcess" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <div id="material">
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>条码明细</legend>
            <table class="tb">
                <tr>
                    <td></td>
                    <td>
                        <label class="labelinfo">条码数量：</label>
                        <asp:TextBox ID="txtLotCount" onkeyup="NumberOnly(this);" runat="server" CssClass="txtinfo"></asp:TextBox>
                        <asp:Button ID="txtBtnEnter" CssClass="hide" runat="server" Text="Button" OnClick="txtBtnEnter_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <div align="center">
                <asp:GridView ID="grd" runat="server" CellPadding="4" CellSpacing="1"
                    ForeColor="#333333" Width="500px"
                    GridLines="None" AutoGenerateColumns="False">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />

                    <Columns>

                        <asp:BoundField DataField="mouldid" HeaderText="设备编号" />
                        <asp:BoundField DataField="Length" HeaderText="批次长度" />
                        <asp:BoundField DataField="Width" HeaderText="批次宽度" />
                    </Columns>



                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </div>
        </fieldset>
    </div>
    <div>
        <table class="table-c" cellspacing="1" cellpadding="3" border="1"  style="color:#333333;width:100%;" >
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Button" />
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                </td>

            </tr>
            <tr><td></td><td></td><td></td></tr>
        </table>
    </div>

</asp:Content>


