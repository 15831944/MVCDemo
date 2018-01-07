using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_MouldLotStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonClass.isAllow(User.Identity.Name, this, "模具查询");
            MouldLotStatus.setWorksiteDDL(ddlWorksite);
            MouldLotStatus.Setdll(DDLMouldStructure, "MouldStructure");
            MouldLotStatus.Setdll(ddlPitch, "MouldPitch");
        }
    }




    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        DataTable dt = MouldLotStatus.QueryData(ddlWorksite.SelectedValue
                                               , txtWidth.Text
                                               , txtHaze.Text
                                               , ddlPitch.SelectedValue
                                               , DDLMouldStructure.SelectedValue);

        grd.DataSource = dt;
        grd.DataBind();
    }
}