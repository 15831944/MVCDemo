<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeLot.aspx.cs" Inherits="Material_ChangeLot" %>

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
            width: 105px;
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
            width: 213px;
        }

        .tb tr td {
            /*width: 350px;*/
            width: 350px;
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

            if (document.getElementById("<%=lblLotprocess.ClientID%>").innerText == "") {
                alert("请输入批次号并回车！");
                return false;
            }

        }




    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />备料模块-批次变更<asp:Label ID="lblWorksiteID" runat="server" CssClass="hide"></asp:Label>
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="确定"
                            CssClass="daohang_btn_saveclose" OnClientClick="return CheckData();" OnClick="btnSaveClose_Click" /></li>
                    <%-- <li>
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
            <legend>条码信息</legend>

            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">条码类型：</label>
                        <asp:DropDownList ID="ddlLabelType" runat="server" CssClass="txtinfo">
                            <asp:ListItem>模具条码</asp:ListItem>
                            <asp:ListItem>制造条码</asp:ListItem>

                        </asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelinfo">批次号：</label>
                        <asp:TextBox ID="txtLot" runat="server" CssClass="txtinfo"></asp:TextBox>
                        <asp:Button ID="btnEnter" runat="server" CssClass="hide" Text="Button" OnClick="btnEnter_Click" />
                    </td>
                    <td></td>
                </tr>
                <%--                <tr>
                    <td>
                        <label class="labelinfo">批次流程：</label>
                        <asp:Label ID="lblLotprocess" runat="server" CssClass="txtinfo" Text=""></asp:Label>
                    </td>
                </tr>--%>
            </table>
            <div>
                <table id="tbprocess" style="width: 1062px; margin-left: auto; margin-right: auto">
                    <tr>
                        <td style="text-align: left;">
                            <label class="labelinfo">批次流程：</label>
                            <asp:Label ID="lblLotprocess" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>

    </div>
    <div id="material">
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>流程站点信息</legend>
            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">选项：</label>
                        <asp:DropDownList ID="ddlChangeType" runat="server" CssClass="txtinfo" AutoPostBack="True" OnTextChanged="ddlChangeType_TextChanged">
                            
                            <asp:ListItem>======请选择======</asp:ListItem>
                            
                            <asp:ListItem>跳站</asp:ListItem>
                            <asp:ListItem>跳流程</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelinfo">流程：</label>
                        <asp:DropDownList ID="ddlWorkflow" runat="server" CssClass="txtinfo" AutoPostBack="True" OnTextChanged="ddlWorkflow_TextChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelinfo">站点：</label>
                        <asp:DropDownList ID="ddlStation" runat="server" CssClass="txtinfo"></asp:DropDownList>
                    </td>

                </tr>

            </table>
        </fieldset>
    </div>

</asp:Content>

