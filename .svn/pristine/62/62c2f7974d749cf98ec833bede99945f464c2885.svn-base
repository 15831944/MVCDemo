<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QCQuery.aspx.cs" Inherits="QC_QCQuery" %>

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
    </style>
    <script src="../JS/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

        function CheckData() {
            if (document.getElementById("<%=txtBegintime.ClientID%>").value == "") {
                alert("请输入开始时间！");
                return false;
            }

            if (document.getElementById("<%=txtEndtime.ClientID%>").value == "") {
                alert("请输入结束时间！");
                return false;
            }


        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />质量模块-检验记录查询
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
    <div id="content">
        <fieldset style="border-color: #e8e8e8; border-style: solid; border-width: 1px 1px 1px 1px;">
            <legend>查询条件</legend>

            <table class="tb">
                <tr>
                    <td>
                        <label class="labelinfo">车间：</label>
                        <asp:DropDownList ID="ddlWorkshop" runat="server" CssClass="txtinfo" AutoPostBack="True"></asp:DropDownList>
                    </td>

                    <td>
                        <label class="labelinfo">开始时间：</label>
                        <asp:TextBox ID="txtBegintime" runat="server" CssClass="txtinfo" onClick="WdatePicker({qsEnabled:false,isShowClear:false,isShowOK:false,maxDate:'#F{\'%y-%M-%d\'}',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>

                    </td>
                    <td>
                        <label class="labelinfo">结束时间：</label>
                        <asp:TextBox ID="txtEndtime" runat="server" CssClass="txtinfo" onClick="WdatePicker({qsEnabled:false,isShowClear:false,isShowOK:false,maxDate:'#F{\'%y-%M-%d\'}',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="labelinfo">站点：</label>
                        <asp:DropDownList ID="ddlWorksiteID" runat="server" CssClass="txtinfo" AutoPostBack="True" >
                            <asp:ListItem Value="">All</asp:ListItem>
                            <asp:ListItem Value="M47">UV成型检验</asp:ListItem>
                            <asp:ListItem Value="M52">贴膜检验</asp:ListItem>
                            <asp:ListItem Value="M57">分条检验</asp:ListItem>
                            <asp:ListItem Value="M37">AG检验</asp:ListItem>
                            <asp:ListItem Value="M40">UV背涂检验</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                      

                    </td>
                    <td></td>
                    <td></td>
                </tr>

            </table>
        </fieldset>

        <fieldset>
            <legend>过站信息</legend>
            <div align="center">

                <asp:GridView ID="grd" runat="server" Width="100%" CellPadding="4" CellSpacing="1" EnableModelValidation="True" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        NoData
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                    <Columns>

                        <asp:BoundField DataField="lotid" HeaderText="批次号" />
                        <asp:BoundField DataField="worksitename" HeaderText="站点名称" />
                        <asp:BoundField DataField="eqpid" HeaderText="设备号" />
                        <asp:BoundField DataField="result" HeaderText="检验结果" />
                        <asp:BoundField DataField="mouldlevel" HeaderText="等级" />
                        <asp:BoundField DataField="paratype" HeaderText="检验项目" />
                        <asp:BoundField DataField="parasubtype" HeaderText="检验子项" />
                        <asp:BoundField DataField="paraid" HeaderText="检验内容" />
                        <asp:BoundField DataField="subresult" HeaderText="检验项目结果" />
                        <asp:BoundField DataField="createtime" HeaderText="检验时间" />
                        <asp:BoundField DataField="createuser" HeaderText="检验人员" />

                    </Columns>
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>


        </fieldset>

    </div>

</asp:Content>

