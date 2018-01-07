using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Pub;

public partial class PermissionManage_GroupManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "群组维护");

            //setddl();
            databind();
        }
    }
    
    private void databind()
    {
        string sql = "select * from tgroup where 1=1 ";
        if (txtGroup.Text != string.Empty)
        {
            sql = sql + "and name = '" + txtGroup.Text + "';";
        }

        DataTable dt = GroupManage.Query( sql);
        this.GroupGrd.DataSource = dt;
        this.GroupGrd.DataBind();

    }

    protected void GroupGrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GroupGrd.PageIndex = e.NewPageIndex;
        databind();
    }
    protected void btnQUery_Click(object sender, EventArgs e)
    {
        databind();
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

            JScript.JavaScriptLocationHref("../PermissionManage/EditGroup.aspx?id=" + id, this);
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
     
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
    }
}
