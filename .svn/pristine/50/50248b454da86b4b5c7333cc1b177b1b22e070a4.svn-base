<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SubsectionCheck.aspx.cs" Inherits="Product_SubsectionCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
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
            /*width: 75px;*/
            width: 85px;
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
            /*Width: 213px;*/
            width: 180px;
            /*border-width: 2px;
    border-style: inset;
    border-color: initial;*/
        }

        .tb tr td {
            /*width: 350px;*/
            /*width: 380px;*/
            width: 300px;
            text-align: left;
            /*border:solid;*/
        }

        .tb {
            margin-left: auto;
            margin-right: auto;
        }
        /*fieldset {
            text-align: center;
        }*/
        .hide {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function EnterTextBox() {
            if (event.keyCode == 13 && document.getElementById("<%=txtLot.ClientID%>").value != "") {
                event.keyCode = 9;
                event.returnValue = false;
                document.getElementById("<%=btnEnter.ClientID %>").click();
            }
        }
        function CheckData() {
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
            //=================检查检验项目=========================================================

            //2、外观
            //检验信息可以不输入 modify by lei.xue on 2017-9-15
            //外观需要输入 modify by lei.xue on 2017-10-24
            if (document.getElementById("<%=txtAppearanceLeft.ClientID%>").value == "") {
                alert("请输入外观左检验信息！");
                return false;
            }
            if (document.getElementById("<%=txtAppearanceRight.ClientID%>").value == "") {
                alert("请输入外观右检验信息！");
                return false;
            }
            if (document.getElementById("<%=ddlAppearanceResult.ClientID%>").value == "") {
                alert("请输入外观检验结果！");
                return false;
            }
            //=================检查检验项目=========================================================


        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />制造模块-分条检验
                <asp:Label ID="lblWorksiteID" runat="server" CssClass="hide">M57</asp:Label>
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="确定"
                            CssClass="daohang_btn_saveclose" OnClientClick=" return CheckData()" OnClick="btnSaveClose_Click" /></li>
                    <%--                 <li>
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
                        <asp:DropDownList ID="ddlWorkshop" runat="server" CssClass="txtinfo" disabled="disabled"></asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelinfo">设备机台：</label>
                        <asp:DropDownList ID="ddlEqp" runat="server" CssClass="txtinfo" disabled="disabled"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>

            </table>
            <div>
                <table id="tbprocess" style="width: 1218px; margin-left: auto; margin-right: auto">
                    <tr>
                        <td style="text-align: left;">
                            <label class="labelinfo">批次流程：</label>
                            <asp:Label ID="lblLotprocess" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblCurrnentWorksite" runat="server" ForeColor="#ffffff" BackColor="#3366ff"></asp:Label>
                            <asp:Label ID="lblEndProcess" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
        <!-------------------------外观--------------------------------------->
        <div id="appearance">
            <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
                <legend>外观</legend>
                <table class="tb">
                    <tr>
                        <td>
                            <label class="labelinfo">左：</label>
                            <asp:TextBox ID="txtAppearanceLeft" runat="server" CssClass="txtinfo"></asp:TextBox>
                        </td>
                        <td>
                            <label class="labelinfo">右：</label>
                            <asp:TextBox ID="txtAppearanceRight" runat="server" CssClass="txtinfo"></asp:TextBox>
                        </td>
                        <td>
                            <label class="labelinfo">检验结果：</label>
                            <asp:DropDownList ID="ddlAppearanceResult" runat="server" CssClass="txtinfo"></asp:DropDownList>
                        </td>
                        <td></td>

                    </tr>
                </table>
            </fieldset>
        </div>
        <!-------------------------外观--------------------------------------->
    </div>
    <div id="material">
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>检验信息</legend>
            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">等级：</label>
                        <asp:TextBox ID="txtFilmLevel" runat="server" CssClass="txtinfo" disable="false" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                    <td>
                        <div class="labelinfo">
                            <asp:CheckBox ID="cbxUpdateLevel" runat="server" />
                            <label>等级：</label>
                        </div>
                        <asp:DropDownList ID="ddlFilmLevel" CssClass="txtinfo" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelinfo">变更原因：</label>
                        <asp:TextBox ID="txtReason" runat="server" CssClass="txtinfo"></asp:TextBox>
                    </td>
                    <td></td>

                </tr>
            </table>
        </fieldset>
    </div>

</asp:Content>


