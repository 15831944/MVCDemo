<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Addpara.aspx.cs" Inherits="Configpara_Addpara" %>

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
            /*font-size: 14px;*/
            border: #999 1px solid;
            background: #f1fcff;
            /*padding-top: 30px;*/
            text-align: center;
            height: 30px;
            Width: 213px;

            /*百度注册按钮样式*/
            
            height: 50px;
            font-size: 16px;
            font-weight: 700;
            cursor: pointer;
            color: #fff;
                background-color: #3f89ec;
             -webkit-border-radius:3px;
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
            width: 95px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />系统设置-新增参数
            </div>
            <!--end daohang-->
            <%--   <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="扣留"
                            CssClass="button" OnClientClick=" return CheckForm()" /></li>
                    <li>
                        <asp:Button ID="btnEdit" runat="server" Text="修改"
                            CssClass="daohang_btn_edit" /></li>
                    <li>
                        <asp:Button ID="btnReset" runat="server" OnClientClick="ClearAllTextBox()" Text="重置"
                            CssClass="daohang_btn_reset" /></li>
                    <li>
                        <input type="button" class="daohang_btn_return" value="返回" onclick="window.location.reload('SpcWriter_Index.aspx');" /></li>

                </ul>
            </div>--%>
            <!--end button-->
        </div>

    </div>
    <div id="content" style="text-align: center">
        <div>
            <label class="labelinfo">参数类型</label><asp:DropDownList ID="ddlParatype" CssClass="txtinfo" runat="server"></asp:DropDownList>
        </div>
        <div>
            <label class="labelinfo">参数ID</label><asp:TextBox ID="txtParaID" CssClass="txtinfo" runat="server"></asp:TextBox>
        </div>
        <div>
            <label class="labelinfo">参数显示名称</label><asp:TextBox ID="txtParaname" CssClass="txtinfo" runat="server"></asp:TextBox>
        </div>
        <div>
            <label class="labelinfo"></label>
            <asp:Button ID="btnConfirm" CssClass="button" runat="server" Text="确认" OnClick="btnConfirm_Click" />
        </div>
    </div>
</asp:Content>

