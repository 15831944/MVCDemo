<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="PermissionManage_AddUser" Title="HLMES" %>

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
        /*#right {
            padding-top: 30px;
        }*/
    </style>
    <script type="text/javascript">
        function CheckData() {
            if (document.getElementById('<%=txtID.ClientID %>').value == "") {
                alert("请输入用户工号！");
                return false;
            }
            if (document.getElementById('<%=txtName.ClientID %>').value == "") {
                alert("请输入用户姓名！");
                return false;
            }
            if (document.getElementById('<%=txtStation.ClientID %>').value == "") {
                alert("请输入用户岗位！");
                return false;
            }
            var ddlClass = document.getElementById('<%=ddlClass.ClientID %>')
            var indexClass = ddlClass.selectedIndex;

            if (ddlClass.options[indexClass].value == "") {
                alert("请输入用户班级！")
                return false;
            }

            var ddlWorkShop = document.getElementById('<%=ddlWorkShop.ClientID %>')
            var indexWorkShop = ddlWorkShop.selectedIndex;
            if (ddlWorkShop.options[indexWorkShop].value == "") {
                alert("请输入用户车间！")
                return false;
            }

            if (document.getElementById('<%=txtPWD.ClientID %>').value == "") {
                alert("请输入用户密码！");
                return false;
            }

            //判断群组是否选中
            var CheckBoxList = document.getElementById('<%=cblUsergroup.ClientID %>').getElementsByTagName("INPUT");
            var i = 0
            var j = 0
            if (CheckBoxList != undefined) {
                for (i = 0; i < CheckBoxList.length; i++) {
                    if (CheckBoxList[i].checked) {
                        j += 1;
                    }
                }
            }
            if (j == 0) { alert("请选择群组！"); return false; }
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="edit" style="border-width: 1px; border-color: #000000; border-bottom-style: double">
        <asp:Button ID="btnConfirm" runat="server" Text="确认" OnClientClick="return CheckData();"
            OnClick="btnConfirm_Click" />
    </div>
    <div id="title" style="">
        <p>添加用户</p>
    </div>
    <div id="content" align="center">
        <div style="width: 800px">
            <div id="left" align="center" style="border-width: 1px; border-color: #C0C0C0; width: 390px; height: 395px; border-right-style: solid;">
                <div>
                    <h4>员工信息</h4>
                </div>
                <div class="userinfo">
                    <span class="labelinfo">工号</span>
                    <asp:TextBox ID="txtID" runat="server" class="txtinfo">
                    </asp:TextBox>
                </div>
                <div class="userinfo">
                    <span class="labelinfo">姓名</span>
                    <asp:TextBox ID="txtName" runat="server" class="txtinfo">
                    </asp:TextBox>
                </div>
                <div class="userinfo">
                    <span class="labelinfo">班别</span>
                    <asp:DropDownList ID="ddlClass" runat="server" class="txtinfo">
                    </asp:DropDownList>
                </div>
                <div class="userinfo">
                    <span class="labelinfo">岗位</span>
                    <asp:TextBox ID="txtStation" runat="server" CssClass="txtinfo">
                    </asp:TextBox>
                </div>
                <div class="userinfo">
                    <span class="labelinfo">车间</span>
                    <asp:DropDownList ID="ddlWorkShop" runat="server" CssClass="txtinfo">
                    </asp:DropDownList>
                </div>
                <div class="userinfo">
                    <span class="labelinfo">密码</span>
                    <asp:TextBox ID="txtPWD" runat="server" class="txtinfo">
                    </asp:TextBox>
                </div>
            </div>
            <div id="right" style="width: 395px; height: 395px;">
                <div>
                    <h4>群组信息</h4>
                </div>
                <div style="padding-top: 30px">
                    <asp:CheckBoxList ID="cblUsergroup" runat="server" RepeatColumns="2"
                        RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

