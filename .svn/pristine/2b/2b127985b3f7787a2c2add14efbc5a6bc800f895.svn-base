<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EqpManage.aspx.cs" Inherits="Eqp_EqpManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <script type="text/javascript">
        function CheckData() {
            if (document.getElementById('<%=txtEqpID.ClientID %>').value == "") {
                alert("请输入设备编号！");
                return false;
            }
            if (document.getElementById('<%=txtEqpName.ClientID %>').value == "") {
                alert("请输入设备名称！");
                return false;
            }
            if (document.getElementById('<%=ddlWorkshop.ClientID %>').value == "") {
                alert("请选择车间！");
                return false;
            }
            if (document.getElementById('<%=ddlWorksite.ClientID %>').value == "") {
                alert("请选择站点！");
                return false;
            }

        }

        function selectx(row) {
            //if (prevselitem != null) {
            row.style.backgroundColor = '#8EC26F';
            //}
            //row.style.backgroundColor = '#8EC26F';
            //prevselitem = row;
        }

        function ClickEvent(cId) {
            //调用LinkButton的单击事件，btnBindData是LinkButton的ID
            document.getElementById(cId).click();
        }
    </script>
    <style type="text/css">
                /*<!-- 表格css-->*/
        .showcell {
            DISPLAY: none;
        }
        .hide {
            display: none;
        }

        .style1 {
            color: #333333;
        }

        .button {
            /*background-color: #3f89ec; 
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;*/
            font-size: 14px;
            border: #999 1px solid;
            background: #f1fcff;
            /*padding-top: 30px;*/
            text-align: center;
        }

        fieldset {
            border-color: #e8e8e8;
            border-style: solid;
            border-width: 1px 1px 1px 1px;
        }

        .labelinfo {
            display: inline-block;
            /*float: left;*/
            height: 42px;
            width: 75px;
            margin-right: 5px;
            line-height: 42px;
            font-size: 14px;
            color: #666;
            font-weight: 700;
            text-align: right;
        }

        .txtinfo {
            box-sizing: border-box;
            height: 28px;
            Width: 213px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />设备模块-设备管理
            </div>
            <!--end daohang-->
            <%--   <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="扣留"
                            CssClass="button" OnClientClick=" return CheckForm()" /></li>
                    <li>
                        <asp:Button ID="btnEdit" runat="server" Text="修改"
                            CssClass="daohang_btn_edit" /></li>
                    <li>
                        <asp:Button ID="btnReset" runat="server" OnClientClick="ClearAllTextBox()" Text="重置"
                            CssClass="daohang_btn_reset" /></li>
                    <li>
                        <input type="button" class="daohang_btn_return" value="返回" onclick="window.location.reload('SpcWriter_Index.aspx');" /></li>

                </ul>
            </div>--%>
            <!--end button-->
        </div>

    </div>
    <div id="menu1" style="margin: 5px; border-bottom-style: hidden; border-bottom-width: 1px; border-bottom-color: #000000;">
        <asp:Button ID="cmdAdd" runat="server" Text="新增" CssClass="button" OnClick="cmdAdd_Click" OnClientClick =" return CheckData();" />
        <asp:Button ID="cmdDel" runat="server" Text="删除" CssClass="button" OnClick="cmdDel_Click" />
        <asp:Button ID="cmdUpdate" runat="server" Text="更新" CssClass="button" OnClick="cmdUpdate_Click" />
        <asp:Button ID="cmdQuery" runat="server" Text="查询" CssClass="button" OnClick="cmdQuery_Click" />


        &nbsp;
       


    </div>
    <!--    gsbFormatGrid grdData, "^24,选择^30,箱号^180,QA^80,QA判定^80,FQC结果^80,封箱情况^60,备注说明^50"

-->
    <div id="content">
        <table>
            <tr>
                <td>
                    <label class="labelinfo">设备编号：</label><asp:TextBox ID="txtEqpID" CssClass="txtinfo" runat="server" onkeypress="EnterTextBox();"></asp:TextBox>
                </td>
                <td>
                    <label class="labelinfo">设备名称：</label><asp:TextBox ID="txtEqpName" CssClass="txtinfo" runat="server"></asp:TextBox>
                </td>
                <td>
                    <label class="labelinfo">状态：</label><asp:DropDownList ID="ddlStatus" CssClass="txtinfo" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label class="labelinfo">站点：</label><asp:DropDownList ID="ddlWorksite" CssClass="txtinfo" runat="server"></asp:DropDownList></td>
                <td>
                    <label class="labelinfo">车间：</label><asp:DropDownList ID="ddlWorkshop" CssClass="txtinfo" runat="server"></asp:DropDownList></td>
                <td>
                    <label class="labelinfo">备注：</label><asp:TextBox ID="txtRemark" CssClass="txtinfo" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <!--<asp:Panel ID="Panel2" runat="server" GroupingText="包装信息">-->
        <fieldset>
            <legend>设备信息</legend>
            <asp:GridView ID="grd" runat="server" CellPadding="4" CellSpacing="1"
                ForeColor="#333333" Width="100%"
                GridLines="None" AutoGenerateColumns="False" OnRowCommand="grd_RowCommand" OnRowDataBound="grd_RowDataBound">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbx" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="eqpid" HeaderText="设备编号" />
                    <asp:BoundField DataField="eqpname" HeaderText="设备名称" />
                    <asp:BoundField DataField="workshopid" HeaderText="车间代码" />
                    <asp:BoundField DataField="status" HeaderText="运行状态" />
                    <asp:BoundField DataField="createuser" HeaderText="创建人员" />
                    <asp:BoundField DataField="createtime" HeaderText="创建时间" />
                    <asp:BoundField DataField="maintainuser" HeaderText="维护人员" />
                    <asp:BoundField DataField="maintaintime" HeaderText="维护时间" />
                    <asp:TemplateField ItemStyle-CssClass="showcell" HeaderStyle-CssClass="showcell">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDetail" CommandName="Detail" CommandArgument='<%# Eval("eqpid").ToString()+"|"+Eval("eqpname") +"|"+Eval("status")+"|"+Eval("worksiteid")+"|"+Eval("workshopid")%>'>辅助列</asp:LinkButton>
                        </ItemTemplate>

                        <HeaderStyle CssClass="showcell"></HeaderStyle>

                        <ItemStyle CssClass="showcell"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <!--</asp:Panel>-->
        </fieldset>

    </div>

</asp:Content>


