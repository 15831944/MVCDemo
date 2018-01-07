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

public partial class FQC_FQCAction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "质量评审");
            setddl();
            
        }
    }
    private void setddl()
    {
                //膜的等级
        CRUD.Setdll(ddlFilmLevel, "FilmLevel");
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        DataTable lotDt = CRUD.GetLotBasisInfo(txtLotID.Text);
        //string workshop = lotDt.Rows[0]["workshopID"].ToString();
        //膜等级
        txtFilmLevel.Text = lotDt.Rows[0]["filmlevel"].ToString();
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        string res= CRUD.updateFilmLevel(txtFilmLevel.Text, ddlFilmLevel.SelectedValue, txtLotID.Text, System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(), "质量评审");
        if (res == "success")
        {
            JScript.AlertAndRedirect("更改成功！", "../QC/FQCAction.aspx", this);
        }
    }
}
