<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bootstraptable.aspx.cs" Inherits="Report_bootstraptable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="form-inline">
                <label for="TextBox1">Name</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder ="Chris"></asp:TextBox>
            </div>
            <!-- <table data-toggle="table">
                <thead>
                    <tr>
                        <th>Item ID</th>
                        <th>Item Name</th>
                        <th>Item Price</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>Item 1</td>
                        <td>$1</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Item 2</td>
                        <td>$2</td>
                    </tr>
                </tbody>
            </table>-->

        </div>
    </form>

</body>
</html>
