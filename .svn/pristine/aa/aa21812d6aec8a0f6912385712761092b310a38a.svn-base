<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FQCAction.aspx.cs" Inherits="FQC_FQCAction" Title="HLMES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
        .hide {
            display: none;
        }

        .style1 {
            color: #333333;
        }

        .button {
            /*background-color: #3f89ec; 
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;*/
            font-size: 14px;
            border: #999 1px solid;
            background: #f1fcff;
            /*padding-top: 30px;*/
            text-align: center;
        }

        fieldset {
            border-color: #e8e8e8;
            border-style: solid;
            border-width: 1px 1px 1px 1px;
        }

        .labelinfo {
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
        }

        .txtinfo {
            box-sizing: border-box;
            height: 28px;
            Width: 213px;
        }
    </style>
    <script type="text/javascript">
        function EnterTextBox(button) {
            if (event.keyCode == 13 && document.getElementById("<%=txtLotID.ClientID%>").value != "") {
                event.keyCode = 9;
                event.returnValue = false;
                document.getElementById("<%=btnEnter.ClientID %>").click();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />质量模块-质量检验
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="确定"
                            CssClass="daohang_btn_saveclose" OnClientClick=" return CheckForm()" OnClick="btnSaveClose_Click" /></li>
                    <%--<li>
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

    <div id="content">
        <table>
            <tr>
                <td>
                    <label class="labelinfo">批次号：</label><asp:TextBox ID="txtLotID" CssClass="txtinfo" runat="server" onkeypress="EnterTextBox();"></asp:TextBox>
                </td>
                <td>
                    <label class="labelinfo">原始等级：</label><asp:TextBox ID="txtFilmLevel" CssClass="txtinfo" runat="server" disable="false" BackColor="#e8e8e8"></asp:TextBox>
                </td>
                <td>
                    <label class="labelinfo">
                        变更等级：
                    </label>
                    <asp:DropDownList ID="ddlFilmLevel" CssClass="txtinfo" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnEnter" runat="server" Text="Button" CssClass="hide" OnClick="btnEnter_Click" />
                </td>
            </tr>

        </table>
    </div>

</asp:Content>

