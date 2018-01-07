using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Warehouse_OnhandInventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonClass.isAllow(User.Identity.Name, this, "入库查询");
            setddl();
            //Databind();
        }
    }
    private void setddl()
    {
        OnhandInventory.SetWarehouseCodedll(ddlWarehousecode);

    }

    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        Databind();
    }
    private void Databind()
    {
        DataTable dt = OnhandInventory.QueryData(ddlWarehousecode.SelectedValue, txtType.Text, txtLotID.Text);
        grd.DataSource = dt;
        grd.DataBind();
    }
}