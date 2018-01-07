<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .hide {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function EnterTextBox() {
            if (event.keyCode == 13 && document.getElementById("<%=txt.ClientID%>").value != "") {
                alert("tt");
                return false;
                event.keyCode = 9;
                event.returnValue = false;
                document.getElementById("<%=btnEnter.ClientID %>").click();
                    }
                }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt" runat="server" onkeypress="EnterTextBox()"></asp:TextBox>
            <asp:Button ID="btnEnter" runat="server" Text="btnEnter" OnClick="btnEnter_Click" CssClass="hide" />
            <asp:Button ID="btnConfirm" runat="server" Text="btnConfirm" OnClick="btnConfirm_Click" />
        </div>
    </form>
</body>
</html>
