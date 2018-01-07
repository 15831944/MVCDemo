<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EditGroup.aspx.cs" Inherits="PermissionManage_EditGroup" Title="HLMES" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #left {
            float: left;
        }

        #right {
            float: right;
        }

        .userinfo {
            height: 30px;
            padding-top: 30px;
        }

        /*#right {
            padding-top: 30px;
        }*/
        .cbl td {
           
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="edit" style="">
        <asp:Button ID="btnConfirm" runat="server" Text="确认" OnClick="btnConfirm_Click" />
    </div>
    <div id="title" style="border-width: 1px; border-color: #000000; border-bottom-style: double">
        <p>修改群组</p>
    </div>
    <div id="content" align="center">
        <div style="width: 800px">
            <div id="left" align="center" style="border-width: 1px; border-color: #C0C0C0; width: 320px; height: 395px; border-right-style: solid;">
                <div class="userinfo">群组<asp:TextBox ID="txtGroup" runat="server"></asp:TextBox></div>

                <div style="overflow: auto;">
                    <asp:GridView ID="Usergrd" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None" AutoGenerateColumns="False">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="工号" />
                            <asp:BoundField DataField="name" HeaderText="姓名" />
                            <asp:BoundField DataField="workshop" HeaderText="车间" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </div>
            </div>
            <div id="right" style="">
                <div style="overflow: auto; height: 450px; padding-top: 30px">
                    <asp:CheckBoxList ID="cblPermission" CssClass="cbl" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                        Width="465px" >
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

