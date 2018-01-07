<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="PermissionManage_EditUser" Title="HLMES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #left {
            float: left;
        }

        #right {
            float: right;
        }

        .userinfo {
            height: 30px;
            padding-top: 30px;
        }

                .labelinfo {
            font-size: 14px;
            color: #666;
            font-weight: 700;
            padding-right: 10px;
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

    <div id="edit" style="">
        <asp:Button ID="btnConfirm" runat="server" Text="确认"
            OnClick="btnConfirm_Click" />
    </div>
    <div id="title" style="border-width: 1px; border-color: #000000; border-bottom-style: double">
        <p>修改权限</p>
    </div>
    <div id="content" align="center">
        <div style="width: 800px">
            <div id="left" align="center" style="border-width: 1px; border-color: #C0C0C0; width: 390px; height: 395px; border-right-style: solid;">
                <div class="userinfo"><label class="labelinfo">工号</label><asp:TextBox class="txtinfo" ID="txtID" runat="server"></asp:TextBox></div>
                <div class="userinfo"><label class="labelinfo">姓名</label><asp:TextBox class="txtinfo" ID="txtName" runat="server"></asp:TextBox></div>
                <div class="userinfo"><label class="labelinfo">班别</label><asp:TextBox class="txtinfo" ID="txtClass" runat="server"></asp:TextBox></div>
                <div class="userinfo"><label class="labelinfo">岗位</label><asp:TextBox class="txtinfo" ID="txtStation" runat="server"></asp:TextBox></div>
                <div class="userinfo"><label class="labelinfo">车间</label><asp:TextBox class="txtinfo" ID="txtWorkShop" runat="server"></asp:TextBox></div>
            </div>
            <div id="right" style="width: 395px; height: 395px;">
                <div style="padding-top:30px">
                    <asp:CheckBoxList ID="cblUsergroup" runat="server" RepeatColumns="2"
                        RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

