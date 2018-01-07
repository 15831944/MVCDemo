<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HLMES</title>

    <link href="css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .style1 {
            text-align: center;
        }

        #background-size4 {
            /*background-size:contain;*/
            /*background:top center repeat-x;background="image/newloginbackground.gif"*/
            /*width: 150px;
            height: 50px;*/
            background-image: url(image/newloginbackground1.gif);
            background-size: 100%;
            /*filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='image/newloginbackground.gif',sizingMethod='scale'); /*兼容ie8以下*/
            /*background-image: url(./btn.png);
            -moz-background-size: 100% 100%;
            -o-background-size: 100% 100%;
            -webkit-background-size: 100% 100%;
            background-size: 100% 100%;
            -moz-border-image: url(./btn.png) 0;
            background-repeat: no-repeat\9;
            background-image: none\9;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='./btn.png', sizingMethod='scale')\9;*/
        }
    </style>

    <script src="JS/jquery-1.8.3.min.js"></script>
    <script src="JS/JH.js"></script>
    <script type="text/javascript">
        $(function () {
            var checkIE = CheckIEBrowser();
        })
    </script>
    <!--[if lt IE 9]>
      <div> you are using the brower below IE9</div>
    <![endif]-->
</head>
<body id="background-size4">
    <form id="form1" runat="server">
        <div style="padding-top: 200px; color: #FFFFFF; font-family: "
            align="center">


            <a style="font-size: 30px; color: black; font-family: 微软雅黑">HLMES</a>
            <table style="border: thin ridge #CCFFFF; width: 21%;">
                <tr>
                    <td class="style1" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1" style="color: black">账号</td>
                    <td class="style1">
                        <asp:TextBox ID="txtID" runat="server" Width="130px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtID" ErrorMessage="*" ForeColor="White"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1" style="color: black">密码</td>
                    <td class="style1">
                        <asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" Width="130px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtPassWord" ErrorMessage="*" ForeColor="White"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style1" colspan="2">
                        <asp:Button ID="btnLogin" runat="server" Text="登陆" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>

        </div>

        <div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                <div class="col-sm-10">
                    <input type="email" class="form-control" id="inputEmail3" placeholder="Email">
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="inputPassword3" placeholder="Password">
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox">
                            Remember me
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <button type="submit" class="btn btn-default">Sign in</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
