<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EditWO.aspx.cs" Inherits="Material_EditWO" Title="HLMES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
        #left {
            float: left;
        }

        #right {
            float: right;
        }

        .userinfo {
            height: 10px;
            padding-top: 30px;
        }

        .labelinfo {
            font-size: 14px;
            color: #666;
            font-weight: 700;
            padding-right: 10px;
            display: inline-block;
            width: 100px;
        }

        .txtinfo {
            box-sizing: border-box;
            height: 28px;
            Width: 213px;
        }

        /*#cblUsergroup {
            padding-top: 30px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />备料模块 -修改工单
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="确定"
                            CssClass="daohang_btn_saveclose" OnClientClick=" return CheckData()" OnClick="btnSaveClose_Click" /></li>
                    <li>
                        <input type="button" class="daohang_btn_return" value="返回" onclick="window.location.href='WOManage.aspx';" />
                    </li>
                </ul>
            </div>
            <!--end button-->
        </div>

    </div>
    <div id="content" align="center">
        <div style="width: 800px">
            <div align="center" style="border-width: 1px; border-color: #C0C0C0; width: 390px; height: 395px;">
                <div class="userinfo">
                    <label class="labelinfo">工单</label><asp:TextBox class="txtinfo" ID="txtWOID" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">工艺路径</label><asp:DropDownList class="txtinfo" ID="ddlWorkFlow" runat="server"></asp:DropDownList>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">车间</label><asp:TextBox class="txtinfo" ID="txtWorkshop" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">品名</label><asp:TextBox class="txtinfo" ID="txtPinmin" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">厚度</label><asp:TextBox class="txtinfo" ID="txtThinkness" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">长度</label><asp:TextBox class="txtinfo" ID="txtLength" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">宽度</label><asp:TextBox class="txtinfo" ID="txtWidth" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">型号</label><asp:TextBox class="txtinfo" ID="txtType" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">PET型号</label><asp:TextBox class="txtinfo" ID="txtPETType" runat="server"></asp:TextBox>
                </div>
                <div class="userinfo">
                    <label class="labelinfo">工单类型</label><asp:DropDownList ID="ddlWOType" class="txtinfo" runat="server"></asp:DropDownList>
                </div>

            </div>

        </div>
    </div>

</asp:Content>

