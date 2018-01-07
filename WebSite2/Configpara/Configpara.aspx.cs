using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;

public partial class Configpara_Configpara : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "参数配置");
            Configpara.Setdll(ddlParatype);
            databind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        JScript.JavaScriptLocationHref("Addpara.aspx", this);
    }

    private void databind()
    {
        grd.DataSource = Configpara.Query(ddlParatype.SelectedValue);
        grd.DataBind();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string result = string.Empty;
        for (int i = 0; i <= grd.Rows.Count - 1; i++)
        {
            CheckBox cbx = (CheckBox)grd.Rows[i].FindControl("cbx");
            if (cbx.Checked == true)
            {
                result = Configpara.Delete(grd.Rows[i].Cells[1].Text, grd.Rows[i].Cells[2].Text);
                if (result != "success")
                {
                    JScript.Alert("删除参数失败！", this);
                }
            }
        }
        if (result == "success")
        {
            JScript.Alert("参数已成功删除！", this);
            databind();
        }
    }
    protected void btnQuery_Click(object sender, ImageClickEventArgs e)
    {
        databind();
    }

    protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd.PageIndex = e.NewPageIndex;
        databind();
    }
}