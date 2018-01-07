<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Configpara.aspx.cs" Inherits="Configpara_Configpara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
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
                <img src="../image/home.png" />系统设置-参数设置
            </div>
            <!--end daohang-->
            <%--            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="保存"
                            CssClass="daohang_btn_saveclose" OnClientClick=" return CheckForm()" /></li>
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
        <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="button" OnClick="btnAdd_Click" />
        <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="button" OnClick="btnDel_Click" />



    </div>
    <div id="content">
        <table>
            <tr>
                <td>
                    <label class="labelinfo">参数类型：</label><asp:DropDownList ID="ddlParatype" runat="server" CssClass="txtinfo"></asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/image/icon_search.gif" OnClick="btnQuery_Click" />
                </td>
                <td></td>
            </tr>

        </table>
    </div>
    <div id="divgrd" style="text-align: center">
        <asp:GridView ID="grd" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" BackColor="#6BA5D8" CellSpacing="1" Width="100%"
            AllowPaging="True" 
            PageSize="20" AutoGenerateColumns="False" OnPageIndexChanging="grd_PageIndexChanging" >
            <PagerSettings FirstPageText="首页" LastPageText="末页"
                Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField ControlStyle-Width="17px" ItemStyle-Width="17px" ItemStyle-HorizontalAlign="Center">

                    <ItemTemplate>
                        <asp:CheckBox ID="cbx" runat="server"
                            Enabled="true" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:BoundField DataField="paratype" HeaderText="参数类型" />
                <asp:BoundField DataField="paraid" HeaderText="参数ID" />
                <asp:BoundField DataField="paraname" HeaderText="参数显示名称" />

                <asp:BoundField DataField="createtime" HeaderText="创建时间" />
                <asp:BoundField DataField="createuser" HeaderText="创建人员" />

            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CDDAF3" ForeColor="#0B44B7" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>



</asp:Content>

