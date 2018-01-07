<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="11AGCoating1.aspx.cs" Inherits="Product_AGCoating" %>

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
            Width: 213px;
        }

        .tb tr td {
            /*width: 350px;*/
            width: 480px;
            text-align: left;
            /*border:solid;*/
        }

        .tb {
            margin-left: auto;
            margin-right: auto;
        }

        .tbflow tr td {
            /*width: 350px;*/
            width: 1440px;
            text-align: left;
            /*border:solid;*/
        }

        .tbflow {
            margin-left: auto;
            margin-right: auto;
        }

        .hide {
            display: none;
        }
        /*fieldset {
            text-align: center;
        }*/
    </style>

    <script src="../JS/jquery-1.8.3.min.js"></script>
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

            if (document.getElementById("<%=txtLength.ClientID%>").value == "") {
                alert("请输入幅宽规格！");
                return false;
            }

            if (document.getElementById("<%=txtWidth.ClientID%>").value == "") {
                alert("请输入卷材长度！");
                return false;
            }


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />制造模块-AG涂布
                <asp:Label ID="lblWorksiteID" runat="server" CssClass="hide">M35</asp:Label>
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="保存"
                            CssClass="daohang_btn_saveclose" OnClientClick=" return CheckForm()" OnClick="btnSaveClose_Click" /></li>
                    <li>
                        <asp:Button ID="btnEdit" runat="server" Text="修改"
                            CssClass="daohang_btn_edit" /></li>
                    <li>
                        <asp:Button ID="btnReset" runat="server" OnClientClick="ClearAllTextBox()" Text="重置"
                            CssClass="daohang_btn_reset" /></li>
                    <li>
                        <input type="button" class="daohang_btn_return" value="返回" onclick="window.location.reload('SpcWriter_Index.aspx');" /></li>

                </ul>
            </div>
            <!--end button-->
        </div>

    </div>

    <div id="worksite">

        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>站点信息</legend>

            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">批次号：</label>
                        <asp:TextBox ID="txtLot" runat="server" CssClass="txtinfo"></asp:TextBox>
                        <asp:Button ID="btnEnter" runat="server" CssClass="hide" Text="Button" OnClick="btnEnter_Click" />
                    </td>

                    <td>
                        <label class="labelinfo">车间：</label>
                        <asp:DropDownList ID="ddlWorkshop" runat="server" CssClass="txtinfo" disabled="disabled" BackColor="#e8e8e8"></asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelinfo">设备机台：</label>
                        <asp:DropDownList ID="ddlEqp" runat="server" CssClass="txtinfo"></asp:DropDownList>
                    </td>
                </tr>

            </table>
            <table class="tbflow">
                <tr>
                    <td>
                        <label class="labelinfo">批次流程：</label>
                        <asp:Label ID="lblLotprocess" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblCurrnentWorksite" runat="server" ForeColor="#ffffff" BackColor="#3366ff"></asp:Label>
                        <asp:Label ID="lblEndProcess" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>

    </div>
    <div id="material">
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>信息录入</legend>
            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">前站卷材长度：</label>
                        <asp:TextBox ID="txtPreLength" runat="server" CssClass="txtinfo" disabled="disabled" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelinfo">前站幅宽规格：</label>
                        <asp:TextBox ID="txtPreWidth" runat="server" CssClass="txtinfo" disabled="disabled" BackColor="#e8e8e8"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <label class="labelinfo">卷材长度：</label>
                        <asp:TextBox ID="txtLength" runat="server" CssClass="txtinfo"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelinfo">幅宽规格：</label>
                        <asp:TextBox ID="txtWidth" runat="server" CssClass="txtinfo"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
            </table>
        </fieldset>
    </div>

</asp:Content>

