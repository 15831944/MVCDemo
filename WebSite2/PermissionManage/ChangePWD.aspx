<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePWD.aspx.cs" Inherits="PermissionManage_ChangePWD" Title="HLMES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type ="text/javascript">
    function checkValue() {
        if (document.getElementById('<%=txtUserID.ClientID%>').value == ""
            || document.getElementById('<%=txtOriginalPWD.ClientID%>').value == ""
            || document.getElementById('<%=txtNewPWD.ClientID%>').value == ""
            || document.getElementById('<%=txtConfirmPWD.ClientID%>').value == "" 


            ) {
            alert("请输入参数值！")
            
            return false;
        }
        
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>  </div>
 <div   style="text-align: center">
    <div style =" height :25px"></div>
        <table  align="center" border="2px" bordercolor="#6699CC" cellpadding="2" 
                           cellspacing="0" 
            style=" margin:auto; border-collapse:collapse; height: 303px; width: 258px;">
            <tr>
                <td >
                    &nbsp; 用户名:</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    &nbsp; 原始密码:</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtOriginalPWD" runat="server" TextMode="Password" ></asp:TextBox></td>
            </tr>
            <tr>
                <td  >
                    &nbsp; 新密码:</td>
                <td >
                    &nbsp;
                    <asp:TextBox ID="txtNewPWD" runat="server" TextMode="Password" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    &nbsp; 确认新密码:</td>
                <td >
                    &nbsp;
                    <asp:TextBox ID="txtConfirmPWD" runat="server" TextMode="Password" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="style2"   >
                    
                    <input id="btnCancel" type ="button"  value="取消"  onclick ="window.location.href('../Index.aspx');"/>
                    &nbsp;
                    <asp:Button ID="btnConfirm" runat="server" Text="确定" 
                        OnClientClick="return checkValue()" onclick="btnConfirm_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

