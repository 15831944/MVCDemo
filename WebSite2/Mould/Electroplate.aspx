<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Electroplate.aspx.cs" Inherits="Mould_Electroplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/submenu.css" rel="stylesheet" />
    <style type="text/css">
        .hide {
            display: none;
        }

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
            width: 75px;
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
    </style>
    <script src="../JS/jquery-1.8.3.min.js"></script>
    <script src="../JS/JH2017-5-31-1.js"></script>
    <script type="text/javascript">
        $(function () {
            //镀层材料
            //=========1===============
            $("#ContentPlaceHolder1_txtDCMaterial").mouseenter(function () {
                $("#divChkListDCMaterial").slideDown("fast");
            });

            $("#divMultiDCMaterial").mouseleave(function () {
                $("#divChkListDCMaterial").slideUp("fast");
            });
            //========2=================
            //$("#cblDCMaterial_0").click(function () {
            //    $("#divChkListDCMaterial :checkbox").attr("checked", this.checked);
            //    if (this.checked == false) {
            //        $("#txtDCMaterial").val("");
            //    }
            //    if (this.checked == true) {
            //        $("#divChkListDCMaterial :checkbox").each(function () {
            //            $("#txtDCMaterial").val($("#txtDCMaterial").val() + $(this).next().text() + ",");
            //        })
            //    };
            //});
            //=================3===========
            $("#divChkListDCMaterial :checkbox").each(function () {
                $(this).click(function () {
                    var $txtList = $("#ContentPlaceHolder1_txtDCMaterial");
                    if (this.checked && $(this).attr("value") != "全选") {
                        //$txtList.val($txtList.val() + $(this).next().text() + ",");
                        $txtList.val($(this).next().text());
                    } else {
                        //$txtList.val($txtList[0].value.replace($(this).next().text() + ',', ''));
                        $txtList.val("");
                    }
                });
            });

        })

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
            if (document.getElementById("<%=lblLotprocess.ClientID%>").innerText == "" &&
                document.getElementById("<%=lblCurrnentWorksite.ClientID%>").innerText == "" &&
                document.getElementById("<%=lblEndProcess.ClientID%>").innerText == "") {
                alert("请先输入批次号！");
                return false;
            }
            if (document.getElementById("<%=txtDCMaterial.ClientID%>").value == "") {
                alert("请输入镀层材料！");
                return false;
            }
            if (document.getElementById("<%=txtDCThinkness.ClientID%>").value == "") {
                alert("请输入镀层厚度！");
                return false;
            }
            //this.disabled = true;
            document.getElementById("Button1").disabled = true;
            //__doPostBack('btnSaveClose', '');
            //__doPostBack("btnSaveClose", "");
            document.getElementById("<%=btnSaveClose.ClientID %>").click();
            //return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="submenu">
        <div id="right_menu">
            <div id="daohang">
                <img src="../image/home.png" />模具模块-电镀出站<asp:Label ID="lblWorksiteID" runat="server" CssClass="hide">M05</asp:Label>
            </div>
            <!--end daohang-->
            <div id="button">
                <ul>
                    <li>
                        <asp:Button ID="btnSaveClose" runat="server" Text="确定"
                            CssClass="hide" OnClick="btnSaveClose_Click"   />
                        <input id="Button1" type="button" value="确定" class="daohang_btn_saveclose" onclick="CheckData();" />
                    </li>
<%--                    <li>
                        <asp:Button ID="btnEdit" runat="server" Text="修改"
                            CssClass="daohang_btn_edit" OnClientClick="return CheckActiveX('../Mould/Electroplate.aspx');" /></li>--%>
                    <%--<li>
                        <asp:Button ID="btnReset" runat="server" OnClientClick="ClearAllTextBox()" Text="重置"
                            CssClass="daohang_btn_reset" /></li>
                    <li>
                        <input type="button" class="daohang_btn_return" value="返回" onclick="window.location.reload('SpcWriter_Index.aspx');" /></li>--%>
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
                        <asp:DropDownList ID="ddlWorkshop" runat="server" disabled="disabled" CssClass="txtinfo"></asp:DropDownList>
                        <%--<asp:TextBox ID="txtWorkshop" runat="server" disabled ="disabled" CssClass="txtinfo"></asp:TextBox>--%>
                    </td>
                    <td>
                        <label class="labelinfo">设备机台：</label>
                        <asp:DropDownList ID="ddlEqp" runat="server" disabled="disabled" CssClass="txtinfo"></asp:DropDownList>

                        <%--<asp:TextBox ID="txtEqp" runat="server" disabled="disabled" CssClass="txtinfo"></asp:TextBox>--%>
                    </td>
                </tr>
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
            <legend>模具参数</legend>
            <table class="tb">
                <tr>
                    <td>
                        <table class="sss">
                            <tr>
                                <td style="width: auto">
                                    <label class="labelinfo">镀层材料：</label>
                                </td>
                                <td>
                                    <div id="divMultiDCMaterial">
                                        <asp:TextBox ID="txtDCMaterial" runat="server" CssClass="txtinfo"></asp:TextBox>
                                        <div id="divChkListDCMaterial" style="display: none; border: solid 1px #e8e8e8; position: fixed; z-index: 100; height: 160px; width: 213px; overflow-y: scroll; background-color: White">
                                            <asp:CheckBoxList ID="cblDCMaterial" runat="server" RepeatLayout="Table" RepeatDirection="Vertical">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <label class="labelinfo">镀层厚度：</label>
                        <asp:TextBox ID="txtDCThinkness" runat="server" CssClass="txtinfo"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
            </table>
        </fieldset>
    </div>

</asp:Content>

