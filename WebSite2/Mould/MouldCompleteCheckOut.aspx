﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MouldCompleteCheckOut.aspx.cs" Inherits="Mould_MouldCompleteCheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
        .hide {
            display: none;
        }

        .reworklabel {
            font-size: 14px;
            color:red;
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
            width: 95px;
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

        #rework {
            width: auto;
        }

        /*fieldset {
            text-align: center;
        }*/
    </style>
    <script src="../JS/jquery-1.8.3.min.js"></script>
    <script src="../JS/JH2017-5-31.js"></script>
    <script type="text/javascript">


        function EnterTextBox() {
            if (event.keyCode == 13 && document.getElementById("<%=txtLot.ClientID%>").value != "") {
                event.keyCode = 9;
                event.returnValue = false;
                document.getElementById("<%=btnEnter.ClientID %>").click();
            }
        }
        i = new Object();
        i.index = 0;
        function CheckData() {

            function CheckData() {

                if ($('#<%=txtReturn.ClientID%>').val() == "") {
                    alert("请先退回原因！");
                    return false;
                }

                if (document.getElementById("<%=txtLot.ClientID%>").value == "") {
                    alert("请输入批次号！");
                    return false;
                }
                if (document.getElementById("<%=lblLotprocess.ClientID%>").innerText == "" &&
                    document.getElementById("<%=lblCurrnentWorksite.ClientID%>").innerText == "" &&
                    document.getElementById("<%=lblEndProcess.ClientID%>").innerText == "") {
                    alert("请先输入批次号！");
                    return false;
                }

                return PreventSubmit01(i);
            }
        }

        function writeFile(content) {
            //"C:\Program Files\Seagull\BarTender Suite\BarTender\bartend.exe" /F="D:\BT32\Pallet.btw" /D="D:\BT32\Pallet.txt" /P /x
            var fso, f, s, filename, f2
            fso = new ActiveXObject("Scripting.FileSystemObject");
            filename = 'C://BT32//Pallet.txt'
            if (fso.FileExists(filename) == true) {
                f2 = fso.GetFile(filename);
                f2.Delete();
            }
            //filecontent = document.getElementById('<%=txtLabelInfo.ClientID %>').value

            f = fso.OpenTextFile(filename, 8, true);
            f.WriteLine(content);
            f.Close();
        }
        function PrintLabel() {
            var labelContent = document.getElementById('<%=txtLabelInfo.ClientID %>').value;
            var content = '';
            var boxqty = 0;
            var qty = 0;

            //循环取明细表的值

            <%--var gv = document.getElementById('<%=grdSum.ClientID %>');
            //去掉表头行循环i从1开始

            for (var i = 1; i < gv.rows.length; i++) {
                for (var j = 0; j < gv.rows[i].cells.length; j++) {
                    content += gv.rows[i].cells[j].innerHTML + ',';
                    if (j == 2) {
                        boxqty++;
                    }
                    if (j == 3) {
                        qty += parseInt(gv.rows[i].cells[j].innerHTML);
                    }
                }
            }

            labelContent = labelContent + ',' + boxqty + ',' + qty + ',' + content.substr(0, content.length - 1);--%>
            writeFile(labelContent);
            //bartender9.01是否安装
            fso = new ActiveXObject("Scripting.FileSystemObject");
            filename = 'C://Program Files//Seagull//BarTender Suite//BarTender//bartend.exe';
            if (fso.FileExists(filename) != true) {
                alert("请先安装Bartender10.1软件，目前无法打印");
                return false;
            }
            var WshShell = new ActiveXObject("WScript.Shell");
            var exeContent = "\"C:\\Program Files\\Seagull\\BarTender Suite\\BarTender\\bartend.exe\" /F=\"C:\\BT32\\Pallet.btw\" /D=\"D:\\BT32\\Pallet.txt\" /P /x"
            //exeContent = "ping 192.168.1.55";
            WshShell.run(exeContent);
            alert("操作成功，生成精雕标签：" + document.getElementById('<%=txtLabelInfo.ClientID %>').value);
            //刷新页面
            window.location.replace("../Mould/CarveCheckOut.aspx");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />模具模块-成型出站<asp:Label ID="lblWorksiteID" runat="server" CssClass="hide">M30</asp:Label>
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="确定"
                            CssClass="daohang_btn_saveclose" OnClientClick="return CheckData();" OnClick="btnSaveClose_Click" /></li>
                    <%--                    <li>
                       <asp:Button ID="btnEdit" runat="server" Text="修改"
                            CssClass="daohang_btn_edit" OnClick="btnEdit_Click" /></li>--%>
                    <%--<li>
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
            <legend>站点信息</legend>

            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">批次号：</label>
                        <asp:TextBox ID="txtLot" runat="server" CssClass="txtinfo"></asp:TextBox>
                        <asp:Button ID="btnEnter" runat="server" CssClass="hide" Text="Button" OnClick="btnEnter_Click" />
                    </td>
                    <td>
                        <label class="labelinfo">车间：</label>
                        <asp:DropDownList ID="ddlWorkshop" runat="server" disabled="disabled" CssClass="txtinfo"></asp:DropDownList>
                        <%--<asp:TextBox ID="txtWorkshop" runat="server" disabled ="disabled" CssClass="txtinfo"></asp:TextBox>--%>
                    </td>
                    <td>
                        <label class="labelinfo">设备机台：</label>
                        <asp:DropDownList ID="ddlEqp" runat="server" disabled="disabled" CssClass="txtinfo"></asp:DropDownList>

                        <%--<asp:TextBox ID="txtEqp" runat="server" disabled="disabled" CssClass="txtinfo"></asp:TextBox>--%>
                    </td>

                </tr>
                <tr>
                    <td>
                        <label class="labelinfo">批次流程：</label>
                        <asp:Label ID="lblLotprocess" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblCurrnentWorksite" runat="server" ForeColor="#ffffff" BackColor="#3366ff"></asp:Label>
                        <asp:Label ID="lblEndProcess" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>

    </div>
    <div id="material">
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>出站信息</legend>
            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">标签信息：</label>
                        <asp:TextBox ID="txtLabelInfo" CssClass="txtinfo" runat="server" ReadOnly="true" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                    <%--                    <td id="rework">
                        <asp:CheckBox ID="cbxReworkID" runat="server" />
                        <label class="labelinfo">返工站点</label>
                        <asp:DropDownList ID="ddlWorksite" CssClass="txtinfo" runat="server">
                            <asp:ListItem Value="M25">WIP</asp:ListItem>

                        </asp:DropDownList>
                    </td>--%>
                    <td>
                        <label class="labelinfo">退回原因：</label>
                        <asp:TextBox ID="txtReturn" runat="server" CssClass="txtinfo"></asp:TextBox>
                    </td>
                    <td>
                        <div class="labelinfo">
                            <asp:CheckBox ID="cbxReworkID" runat="server" />
                            <label class="reworklabel">返工站点</label>
                        </div>
                        <asp:DropDownList ID="ddlWorksite" CssClass="txtinfo" runat="server">
                            <asp:ListItem Value="M25">WIP</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                   
                </tr>
            </table>
        </fieldset>
    </div>

</asp:Content>

