using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;

public partial class Warehouse_ShipmentQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "出库查询");
            setddl();
            //Databind();
        }
    }
    private void setddl()
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        //CRUD.Setdll(ddlWorksiteID, "worksite");

        ddlWorkshop.SelectedIndex = 0;
        
        //ddlWorksiteID.SelectedIndex = 0;
        //CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, ddlWorksiteID.SelectedValue);

    }
   
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        Databind();
    }
    private void Databind()
    {
        
        DataTable dt = ShipmentManage.FinalShipmentQuery(ddlWorkshop.SelectedValue,
                                                txtShipmentID.Text,
                                                txtBegintime.Text,
                                                txtEndtime.Text,
                                                txtLotid.Text,
                                                txtPinmin.Text,
                                                txtType.Text
                                                );
        grd.DataSource = dt;
        grd.DataBind();
        //Nmtree.MergeGridViewCell.MergeRow(grd,0,7);
    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}