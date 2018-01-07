<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="WOManage.aspx.cs" Inherits="Product_FilmQuery" %>

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

        /*<!-- 表格css-->*/
        .showcell {
            DISPLAY: none;
        }
    </style>
    <script src="../JS/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function ClickEvent(cId) {
            //调用LinkButton的单击事件，btnBindData是LinkButton的ID
            document.getElementById(cId).click();
        }

        // var prevselitem = null;
        function selectx(row) {
            //if (prevselitem != null) {
            row.style.backgroundColor = '#8EC26F';
            //}
            //row.style.backgroundColor = '#8EC26F';
            //prevselitem = row;
        }
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
                <img src="../image/home.png" />备料模块-工单管理
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="查询"
                            CssClass="daohang_btn_saveclose" OnClientClick=" return CheckData()" OnClick="btnSaveClose_Click" /></li>
                    <li>
                        <asp:Button ID="btnEdit" runat="server" Text="删除"
                            CssClass="daohang_btn_edit" OnClick="btnEdit_Click" /></li>
                    <li>
                        <asp:Button ID="btnReset" runat="server" OnClientClick="ClearAllTextBox()" Text="开启"
                            CssClass="daohang_btn_reset" OnClick="btnReset_Click" /></li>
                    <li>
                        <!--<input type="button" class="daohang_btn_return" value="关闭" onclick="window.location.reload('SpcWriter_Index.aspx');" />-->
                        <asp:Button ID="btnCloseWO" runat="server" Text="关闭" class="daohang_btn_return" OnClick="btnCloseWO_Click" />
                    </li>
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
                        <label class="labelinfo">开始时间：</label>
                        <asp:TextBox ID="txtBegintime" runat="server" CssClass="txtinfo" onClick="WdatePicker({qsEnabled:false,isShowClear:false,isShowOK:false,maxDate:'#F{\'%y-%M-%d\'}',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>

                    </td>
                    <td>
                        <label class="labelinfo">结束时间：</label>
                        <asp:TextBox ID="txtEndtime" runat="server" CssClass="txtinfo" onClick="WdatePicker({qsEnabled:false,isShowClear:false,isShowOK:false,maxDate:'#F{\'%y-%M-%d\'}',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>

                    </td>
                </tr>

            </table>
        </fieldset>

        <fieldset>
            <legend>工单信息</legend>
            <div align="center">

                <asp:GridView ID="GroupGrd" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" CellSpacing="1" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="True" OnPageIndexChanging="GroupGrd_PageIndexChanging"
                    PageSize="16" OnRowCommand="GroupGrd_RowCommand"
                    OnRowDataBound="GroupGrd_RowDataBound">
                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="首页"
                        LastPageText="末页" NextPageText="下一页" PreviousPageText="上一页" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="workorderid" HeaderText="工单" />
                        <asp:BoundField DataField="bomid" HeaderText="bomid" />
                        <asp:BoundField DataField="flowid" HeaderText="工艺路线" />
                        <asp:BoundField DataField="workshopid" HeaderText="车间" />
                        <asp:BoundField DataField="mouldpinmin" HeaderText="品名" />
                        <asp:BoundField DataField="mouldthinkness" HeaderText="厚度" />
                        <asp:BoundField DataField="mouldlength" HeaderText="长度" />
                        <asp:BoundField DataField="mouldwidth" HeaderText="宽度" />
                        <asp:BoundField DataField="mouldtype" HeaderText="型号" />
                        <asp:BoundField DataField="mouldpettype" HeaderText="PET型号" />
                        <asp:BoundField DataField="workordertype" HeaderText="工单类型" />
                        <asp:BoundField DataField="status" HeaderText="状态" />
                        <asp:BoundField DataField="createtime" HeaderText="创建时间" />
                        <asp:BoundField DataField="transfertime" HeaderText="抛转时间" />
                        
                        <asp:TemplateField ItemStyle-CssClass="showcell" HeaderStyle-CssClass="showcell">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDetail" CommandName="Detail" CommandArgument='<%# Eval("workorderid").ToString() %>'>辅助列</asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle CssClass="showcell"></HeaderStyle>

                            <ItemStyle CssClass="showcell"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CDDAF3" ForeColor="#0000FF" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </div>


        </fieldset>

    </div>

</asp:Content>

