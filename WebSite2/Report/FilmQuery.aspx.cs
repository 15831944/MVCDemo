using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_FilmQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonClass.isAllow(User.Identity.Name, this, "模具查询");
      
        }
    }


    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        Databind();
    }
    private void Databind()
    {
        DataTable dt = FilmQuery.QueryData(txtLot.Text);
        grd.DataSource = dt;
        grd.DataBind();
    }
}