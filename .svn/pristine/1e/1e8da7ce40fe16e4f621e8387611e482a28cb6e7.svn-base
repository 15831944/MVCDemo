using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;
public partial class Product_FilmQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "工单管理");
            setddl();
            Databind();
        }
    }
    private void setddl()
    {
        //设置默认时间，当月
        txtBegintime.Text = System.DateTime.Now.ToString("yyyy-MM-01 00:00:00");
        txtEndtime.Text = System.DateTime.Now.AddMonths(1).ToString("yyyy-MM-01 00:00:00");

    }

    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        Databind();
    }
    private void Databind()
    {
        DataTable dt = WOManage.Retrieve(txtBegintime.Text, txtEndtime.Text);
        if (dt.Rows.Count > 0)
        {
            GroupGrd.DataSource = dt;
            GroupGrd.DataBind();
        }
    }
    protected void GroupGrd_RowDataBound(object sender, GridViewRowEventArgs e)
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
        }
    }
    protected void GroupGrd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            //在这里对你需要的数据信息进行输出
            //我的处理函数
            // Response.Write("<script>alert('"+ e.CommandArgument  +"')</script>");
            string id = e.CommandArgument.ToString();

            JScript.JavaScriptLocationHref("../Material/EditWO.aspx?workorderid=" + id, this);
        }
    }
    protected void GroupGrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GroupGrd.PageIndex = e.NewPageIndex;
        Databind();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string result = "";
        for (int i = 0; i <= GroupGrd.Rows.Count - 1; i++)
        {
            CheckBox cbx = (CheckBox)GroupGrd.Rows[i].FindControl("cbx");
            if (cbx.Checked == true)
            {
                //result = ManageColor.DeleteColor(UserGrd.Rows[i].Cells[1].Text, UserGrd.Rows[i].Cells[2].Text);
                result = WOManage.Delete(GroupGrd.Rows[i].Cells[1].Text);
                if (result != "success")
                {
                    JScript.Alert("删除工单失败！", this);
                }
            }
        }
        if (result == "success")
        {
            JScript.Alert("工单已成功删除！", this);
            Databind();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string result = "";
        for (int i = 0; i <= GroupGrd.Rows.Count - 1; i++)
        {
            CheckBox cbx = (CheckBox)GroupGrd.Rows[i].FindControl("cbx");
            if (cbx.Checked == true)
            {
                //result = ManageColor.DeleteColor(UserGrd.Rows[i].Cells[1].Text, UserGrd.Rows[i].Cells[2].Text);
                result = WOManage.ChangeWOStatus(GroupGrd.Rows[i].Cells[1].Text,"open");
                if (result != "success")
                {
                    JScript.Alert("工单开启失败！", this);
                }
            }
        }
        if (result == "success")
        {
            JScript.Alert("工单已成功开启！", this);
            Databind();
        }
    }
    protected void btnCloseWO_Click(object sender, EventArgs e)
    {
        string result = "";
        for (int i = 0; i <= GroupGrd.Rows.Count - 1; i++)
        {
            CheckBox cbx = (CheckBox)GroupGrd.Rows[i].FindControl("cbx");
            if (cbx.Checked == true)
            {
                //result = ManageColor.DeleteColor(UserGrd.Rows[i].Cells[1].Text, UserGrd.Rows[i].Cells[2].Text);
                result = WOManage.ChangeWOStatus(GroupGrd.Rows[i].Cells[1].Text, "close");
                if (result != "success")
                {
                    JScript.Alert("工单关闭失败！", this);
                }
            }
        }
        if (result == "success")
        {
            JScript.Alert("工单已成功关闭！", this);
            Databind();
        }
    }
}