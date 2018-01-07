using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Product_FilmQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "模具查询");
            setddl();
            Databind();
        }
    }
    private void setddl()
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        //CRUD.Setdll(ddlWorksiteID, "worksite");

        ddlWorkshop.SelectedIndex = 0;
        ddlWorksiteID.SelectedIndex = 0;
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, ddlWorksiteID.SelectedValue);

    }
    protected void ddlWorksiteID_TextChanged(object sender, EventArgs e)
    {
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, ddlWorksiteID.SelectedValue);
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        Databind();
    }
    private void Databind()
    {
        DataTable dt = MouldQuery.MouldDataHistory(txtBegintime.Text,
                                                   txtEndtime.Text,
                                                   ddlEqp.SelectedValue,
                                                   ddlWorkshop.SelectedValue,
                                                   "",
                                                   "",
                                                   "",
                                                   ddlWorksiteID.SelectedValue);
        grd.DataSource = dt;
        grd.DataBind();
    }
}