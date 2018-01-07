<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="OnhandInventory.aspx.cs" Inherits="Warehouse_OnhandInventory" %>

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
            width: 135px;
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
            width: 180px;
            /*border-width: 2px;
    border-style: inset;
    border-color: initial;*/
        }

        .tb tr td {
            /*width: 350px;*/
            /*width: 380px;*/
            width: 380px;
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


        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />仓管模块-库存管理
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
                        <label class="labelinfo">库位：</label>
                        <asp:DropDownList ID="ddlWarehousecode" runat="server"  CssClass="txtinfo"></asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelinfo">型号：</label>
                        <asp:TextBox ID="txtType" runat="server" CssClass="txtinfo" ></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelinfo">批号：</label>
                        <asp:TextBox ID="txtLotID" runat="server" CssClass="txtinfo" ></asp:TextBox>

                    </td>
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
                        <asp:BoundField DataField="warehousecode" HeaderText="库位" />
                        <asp:BoundField DataField="lotid" HeaderText="批次号" />
                        <asp:BoundField DataField="pinmin" HeaderText="品名" />
                        <asp:BoundField DataField="type" HeaderText="型号" />
                        <asp:BoundField DataField="validlength" HeaderText="有效长度" />
                        <asp:BoundField DataField="validwidth" HeaderText="有效宽幅" />
                        <asp:BoundField DataField="area" HeaderText="面积" />
                        <asp:BoundField DataField="warehousetime" HeaderText="入库时间" />
                    </Columns>
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>


        </fieldset>

    </div>

</asp:Content>

