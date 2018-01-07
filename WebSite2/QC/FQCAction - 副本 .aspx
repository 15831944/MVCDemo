<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FQCAction - 副本 .aspx.cs" Inherits="FQC_FQCAction" Title="HLMES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
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
            border:#999 1px solid;
            
            background: #f1fcff ;
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
    <script type="text/javascript">
        <%--        function EnterTextBox(button) {
            if (event.keyCode == 13 && document.getElementById("<%=txtBoxID.ClientID%>").value != "") {
                event.keyCode = 9;
                event.returnValue = false;
                document.getElementById("<%=btnBoxEnter.ClientID %>").click();


            }

        }--%>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />质量模块-质量检验
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
    <div id="menu1" style="margin: 5px; border-bottom-style: hidden; border-bottom-width: 1px; border-bottom-color: #000000; ">
        <asp:Button ID="cmdHold" runat="server" Text="扣留" CssClass="button" />
        <asp:Button ID="cmdJudge" runat="server" Text="评审" CssClass="button" />
        <asp:Button ID="cmdRelease" runat="server" Text="判定" CssClass="button" />
        <asp:Button ID="Redo" runat="server" Text="返工" CssClass="button" />


    </div>
    <!--    gsbFormatGrid grdData, "^24,选择^30,箱号^180,QA^80,QA判定^80,FQC结果^80,封箱情况^60,备注说明^50"

-->
    <div id="content">
        <table>
            <tr>
                <td>
                    <label class="labelinfo">箱号：</label><asp:TextBox ID="txtBoxID" CssClass="txtinfo" runat="server" onkeypress="EnterTextBox();"></asp:TextBox>
                </td>
                <td>
                    <label class="labelinfo">原因：</label><asp:TextBox ID="txtReason" CssClass="txtinfo" runat="server"></asp:TextBox>
                </td>
                <td>
                    <label class="labelinfo">状态：</label><asp:TextBox ID="txtStatus" CssClass="txtinfo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label class="labelinfo">当前站点：</label><asp:TextBox ID="txtCurrentworksite" CssClass="txtinfo" runat="server"></asp:TextBox></td>
                <td>
                    <label class="labelinfo">返工站点：</label><asp:DropDownList ID="txtReworkworksite" CssClass="txtinfo" runat="server"></asp:DropDownList></td>
                <td></td>
            </tr>
        </table>
        <!--<asp:Panel ID="Panel2" runat="server" GroupingText="包装信息">-->
        <fieldset>
            <legend>包装信息</legend>
            <asp:GridView ID="grd" runat="server" CellPadding="4" CellSpacing="1"
                ForeColor="#333333" Width="100%"
                GridLines="None" AutoGenerateColumns="False">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbx" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="boxid" HeaderText="箱号" />
                    <asp:BoundField DataField="action" HeaderText="QA" />
                    <asp:BoundField DataField="qajudge" HeaderText="QA判定" />
                    <asp:BoundField DataField="fqc" HeaderText="FQC结果" />
                    <asp:BoundField DataField="package" HeaderText="封箱情况" />
                    <asp:BoundField DataField="remark" HeaderText="备注说明" />

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

