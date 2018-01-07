<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="PermissionManage_UserManage" Title="HLMES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type ="text/javascript">
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
    </script> 
    <style type="text/css">
        .style1
        {
            width: 52px;
        }
        
        /*<!-- 表格css-->*/
        .showcell{
        DISPLAY:none;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 

    <div id = "edit" style="border-width: 1px; border-color: #000000; border-bottom-style: double">
    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    <asp:Button ID="btnAdd" runat="server" Text="添加" onclick="btnAdd_Click" 
                       />
                </td>
                <td class="style2">
                    <asp:Button ID="btnDel" runat="server" Text="删除" onclick="btnDel_Click" />
                </td>    
                <td>
                
                 </td>
            </tr>
       
        </table>
    
    </div>
    <div id = "query">
        <asp:Panel ID="Panel1" runat="server" GroupingText="查询">
        
        <table style="width: 100%;">
            <tr>
                <td>
                    工号<asp:TextBox ID="txtID" runat="server" Width="76px"></asp:TextBox></td>
                <td>
                    姓名<asp:TextBox ID="txtName" runat="server" Width="81px"></asp:TextBox></td>
                <td>
                    班别<asp:DropDownList ID="ddlClass" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    岗位<asp:TextBox ID="txtStation" runat="server" Width="89px"></asp:TextBox></td>
                <td>
                    车间<asp:DropDownList ID="ddlWorkShop" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnQUery" runat="server" Text="查询" onclick="btnQUery_Click" />
                </td>
            </tr>
            </table>
            </asp:Panel>
    </div>
    <div id ="content" 
        style="text-align: center; padding-top: 5px;">
        <asp:GridView ID="UserGrd" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" CellSpacing="1" AutoGenerateColumns="False" Width="100%" 
            AllowPaging="True" onpageindexchanging="UserGrd_PageIndexChanging" 
            PageSize="16" onrowcommand="UserGrd_RowCommand" 
            onrowdatabound="UserGrd_RowDataBound" >
            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="首页" 
                LastPageText="末页" NextPageText="下一页" PreviousPageText="上一页" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbx" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="工号" />
                <asp:BoundField DataField="name" HeaderText="姓名" />
                <asp:BoundField DataField="class" HeaderText="班别" />
                <asp:BoundField DataField="station" HeaderText="岗位" />
                <asp:BoundField DataField="createtime" HeaderText="创建时间" />
                <asp:BoundField DataField="workshop" HeaderText="车间" />
                <asp:TemplateField ItemStyle-CssClass="showcell" HeaderStyle-CssClass="showcell">
                    <ItemTemplate>
                    <asp:LinkButton runat="server" ID="btnDetail" CommandName="Detail"  CommandArgument='<%# Eval("id").ToString() %>'>辅助列</asp:LinkButton>
                    </ItemTemplate>

<HeaderStyle CssClass="showcell"></HeaderStyle>

<ItemStyle CssClass="showcell"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle  BackColor="#CDDAF3" ForeColor="#0000FF" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>

 
</asp:Content>

