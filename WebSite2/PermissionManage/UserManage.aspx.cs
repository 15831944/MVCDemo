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

public partial class PermissionManage_UserManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "用户维护");
            //PackageParameter.setWorkShopddl_add(ddlWorkShop);  
             CRUD.setWorkShopddl_add(ddlWorkShop);
            setddl();
            databind();
        }
    }
    private void setddl()
    {
        //this.ddlWorkShop.AppendDataBoundItems = true;
        //this.ddlWorkShop.Items.Add(new ListItem("", ""));
        //this.ddlWorkShop.Items.Add(new ListItem("C3", "C3"));
        //this.ddlWorkShop.Items.Add(new ListItem("C4", "C4"));
        //this.ddlWorkShop.Items.Add(new ListItem("C5", "C5"));
        //this.ddlWorkShop.Items.Add(new ListItem("C6", "C6"));
        //this.ddlWorkShop.DataBind();

        this.ddlClass.AppendDataBoundItems = true;
        this.ddlClass.Items.Add(new ListItem("", ""));
        this.ddlClass.Items.Add(new ListItem("A", "A"));
        this.ddlClass.Items.Add(new ListItem("B", "B"));
        this.ddlClass.Items.Add(new ListItem("C", "C"));
        this.ddlClass.Items.Add(new ListItem("长白班", "长白班"));
        this.ddlClass.DataBind();
 
    }
    private void databind()
    {
        string strSql = "select id,name,class,station,createtime,workshop From jh_mes.tuser where 1=1 ";
        if ((txtID.Text.Trim()) != "")
        {
            strSql = strSql + " and id='" + txtID.Text.Trim() + "'";
        }
        if ((txtName.Text .Trim() ) != "")
        {
            strSql = strSql + " and name='" + txtName.Text.Trim() + "'";
        }
        if ((ddlClass.Text.Trim()) != "")
        {
            strSql = strSql + " and class='" + ddlClass.Text.Trim() + "'";
        }
        if ((txtStation.Text.Trim()) != "")
        {
            strSql = strSql + " and station='" + txtStation.Text.Trim() + "'";
        }
        if ((ddlWorkShop.Text.Trim()) != "")
        {
            strSql = strSql + " and workshop='" + ddlWorkShop.Text.Trim() + "'";
        }
        DataTable dt = Userdata.Query(strSql);
        this.UserGrd.DataSource = dt;
        this.UserGrd.DataBind();

    }

    protected void UserGrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UserGrd.PageIndex = e.NewPageIndex;
        databind();
    }
    protected void btnQUery_Click(object sender, EventArgs e)
    {
        databind();
    }
    protected void UserGrd_RowDataBound(object sender, GridViewRowEventArgs e)
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
            e.Row.Cells[1].Attributes.Add("OnClick", "ClickEvent('" + e.Row.Cells[7].FindControl("btnDetail").ClientID + "');selectx(this)");
            //e.Row.Attributes.Add("OnClick", "ClickEvent('" + e.Row.Cells[5].FindControl("btnDetial").ClientID + "');selectx(this)");
            //注：OnClick参数是指明为鼠标单击时间，后个是调用javascript的ClickEvent函数
        }
    }
    protected void UserGrd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            //在这里对你需要的数据信息进行输出
            //我的处理函数
            // Response.Write("<script>alert('"+ e.CommandArgument  +"')</script>");
           string id= e.CommandArgument.ToString();

           JScript.JavaScriptLocationHref("../PermissionManage/EditUser.aspx?id=" + id, this);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        JScript.JavaScriptLocationHref("../PermissionManage/AddUser.aspx", this);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int result = 0;
        for (int i = 0; i <= UserGrd.Rows.Count - 1; i++)
        {
            CheckBox cbx = (CheckBox)UserGrd.Rows[i].FindControl("cbx");
            if (cbx.Checked == true)
            {
                //result = ManageColor.DeleteColor(UserGrd.Rows[i].Cells[1].Text, UserGrd.Rows[i].Cells[2].Text);
                result = Userdata.DelUser(UserGrd.Rows[i].Cells[1].Text);
                if (result <1 )
                {
                    JScript.Alert("删除用户失败！", this);
                }
            }
        }
        if (result > 0)
        {
            JScript.Alert("用户已成功删除！", this);
            databind();
        }
    }
}
