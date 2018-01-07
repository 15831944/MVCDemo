<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FilmLotHistory.aspx.cs" Inherits="Report_FilmLotHistory" %>




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
            width: 85px;
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
            /*Width: 213px;*/
            width: 213px;
        }

        .tb tr td {
            /*width: 350px;*/
            width: 350px;
            text-align: left;
            /*border:solid;*/
        }

        .tb {
            margin-left: auto;
            margin-right: auto;
        }
        /*fieldset {
            text-align: center;
        }*/
        .hide {
            display: none;
        }

        .auto-style1 {
            height: 21px;
        }

        .tbhistory table {
            border: 1px;
            border-style: solid;
            border-collapse: collapse;
        }
                .tblothistory td {
            width: 175px;
            text-align: center;
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }

        .tdtitle {
            font-weight: bolder;
            font-size: 16px;
        }

        .tblothistory {
            border-collapse: collapse;
            padding: 2px;
        }

        .trlothistory {
            border-top-style: solid;
            border-top-width: 2px;
            border-top-color: #000000;
        }

        .trlothistory01 {
            border-top-style: solid;
            border-bottom-style: solid;
            border-top-width: 2px;
            border-bottom-width: 2px;
        }
    </style>
    
    <script src="../JS/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

        function CheckData() {
            if (document.getElementById("<%=txtLot.ClientID%>").value == "") {
                alert("请输入批次号！");
                return false;
            }
        }
        function loaddata01(content) {
            var div = document.getElementById('divcontent');
            div.innerHTML = content;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />报表模块-产品追溯
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="查询"
                            CssClass="daohang_btn_saveclose" OnClientClick=" return CheckData()" OnClick="btnSaveClose_Click" /></li>
                    <%--                    <li>
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
    <div id="content" >
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>查询条件</legend>

            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">批次号：</label>
                        <asp:TextBox ID="txtLot" runat="server" CssClass="txtinfo"></asp:TextBox>
                    </td>

                    <td></td>
                    <td></td>
                </tr>


            </table>
        </fieldset>

        <fieldset>
            <legend>过站信息</legend>
            
            <div id="divcontent"></div>

        </fieldset>

    </div>
    <div>
      
    </div>

</asp:Content>

