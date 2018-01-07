using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;
using System.Data;

public partial class Eqp_EqpManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EqpManage.Setdll(ddlStatus, "eqpstatus");
            ddlStatus.Text = "RUN";
            EqpManage.Setdll(ddlWorkshop, "workshop");
            EqpManage.Setdll(ddlWorksite, "worksite");
            databind();
        }
    }
    protected void cmdQuery_Click(object sender, EventArgs e)
    {
        databind();
    }
    private void databind()
    {
        grd.DataSource = EqpManage.Query(txtEqpID.Text,ddlWorkshop.SelectedValue,ddlWorksite.SelectedValue);
        grd.DataBind();
    }
    protected void cmdAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = EqpManage.Exist(txtEqpID.Text);
        if (dt.Rows.Count > 0)
        {
            JScript.Alert("设备编号已存在", this);
            return;
        }
       string result =  EqpManage.Add(txtEqpID.Text,
                      txtEqpName.Text,
                      ddlWorksite.SelectedValue,
                      ddlWorkshop.SelectedValue,
                      ddlStatus.SelectedValue,
                      System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
                      txtRemark.Text);
       if (result != "success")
       {
           JScript.Alert("设备编号添加失败", this);
           return;
       }
       JScript.Alert("设备编号添加成功", this);
       ClearControl();
       databind();
    }

    protected string CheckBack(string value, GridViewRow row)
    {
        if (value == "RUN")
            row.BackColor =System.Drawing.Color.Green;
        return value;
    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标停留时更改背景色

            e.Row.Cells[1].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#8EC26F'");
            //当鼠标移开时还原背景色
            e.Row.Cells[1].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            //设置悬浮鼠标指针形状为"小手"
            e.Row.Cells[1].Attributes["style"] = "Cursor:hand";

            //单击/双击 事件
            //e.Row.Attributes.Add("OnClick", "ClickEvent('" + e.Row.Cells[2].FindControl("btnDetail").ClientID + "');selectx(this)");
            e.Row.Cells[1].Attributes.Add("OnClick", "ClickEvent('" + e.Row.Cells[2].FindControl("btnDetail").ClientID + "');selectx(this)");

            //e.Row.Attributes.Add("OnClick", "ClickEvent('" + e.Row.Cells[5].FindControl("btnDetial").ClientID + "');selectx(this)");
            //注：OnClick参数是指明为鼠标单击时间，后个是调用javascript的ClickEvent函数

            string status = (e.Row.Cells[4].Text.ToString());//数量1
         
            if (status =="RUN")
            {
                e.Row.Cells[4].BackColor = System.Drawing.Color.Green;//显示背景颜色，可自定义
                e.Row.Cells[4].ForeColor = System.Drawing.Color.White;//显示背景颜色，可自定义
            }
            else if (status == "DOWN")
            {
                e.Row.Cells[4].BackColor = System.Drawing.Color.Red;//显示背景颜色，可自定义
                e.Row.Cells[4].ForeColor = System.Drawing.Color.White;//显示背景颜色，可自定义
            }
            else
            {
                e.Row.Cells[4].BackColor = System.Drawing.Color.Yellow;//显示背景颜色，可自定义
                e.Row.Cells[4].ForeColor = System.Drawing.Color.Black;//显示背景颜色，可自定义
            }
        }
    }
    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            //在这里对你需要的数据信息进行输出
            //我的处理函数
            // Response.Write("<script>alert('"+ e.CommandArgument  +"')</script>");
            string []Ary = e.CommandArgument.ToString().Split(new Char[] { '|' });
            txtEqpID.Text = Ary[0];
            txtEqpName.Text = Ary[1];
            ddlStatus.Text = Ary[2];
            ddlWorksite.Text = Ary[3];
            ddlWorkshop.Text = Ary[4];
            //JScript.JavaScriptLocationHref("../PermissionManage/EditGroup.aspx?id=" + id, this);
        }
    }

    //清空查询文本框
    private void ClearControl()
    {
        txtEqpID.Text = "";
        txtEqpName.Text = "";
    }
    protected void cmdDel_Click(object sender, EventArgs e)
    {
        string result = string.Empty;
        for (int i = 0; i <= grd.Rows.Count - 1; i++)
        {
            CheckBox cbx = (CheckBox)grd.Rows[i].FindControl("cbx");
            if (cbx.Checked == true)
            {
                result = EqpManage.Delete(grd.Rows[i].Cells[1].Text);
                if (result != "success")
                {
                    JScript.Alert("删除设备！", this);
                }
            }
        }
        if (result == "success")
        {
            JScript.Alert("设备已成功删除！", this);
            databind();
        }
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        string result = EqpManage.Update(txtEqpID.Text,ddlStatus.SelectedValue,
                         System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString());
        if (result == "success")
        {
            JScript.Alert("设备状态已经更新！", this);
            databind();
        }
    }
}