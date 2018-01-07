using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using Pub;

public partial class Product_AGCoating : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
        }
    }

    private void setddl(string workshop)
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        //ddlWorkshop.SelectedIndex = 0;
        ddlWorkshop.ClearSelection();
        ddlWorkshop.Items.FindByValue(workshop).Selected = true;
        ddlEqp.ClearSelection();
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        //查询是否可以过站
        string result = CRUD.QueryStationOfLot(lblWorksiteID.Text, txtLot.Text);
        if (result != "success")
        {
            JScript.Alert(result, this);
            txtLot.Text = "";
            return;
        }

        DataTable lotDt = CRUD.GetLotBasisInfo(txtLot.Text);
        string workshop = lotDt.Rows[0]["workshopID"].ToString();
        setddl(workshop);

        string WO = lotDt.Rows[0]["workorder"].ToString();

        CRUD.setLabelProcess(lblLotprocess, lblCurrnentWorksite, lblEndProcess, txtLot.Text, lblWorksiteID.Text);


        FilmCRUD.GetPreLengthAndWidth(txtPreLength, txtPreWidth, txtLot.Text, lblWorksiteID.Text, WO, "");



    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        string result = CRUD.FilmCheckOut(txtLot.Text,
                              "",
                              ddlEqp.SelectedValue,
                              ddlWorkshop.SelectedValue,
                              ddlWorkshop.SelectedValue,
                              System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
                              txtPreLength.Text,
                              txtPreWidth.Text,
                              txtLength.Text,
                              txtWidth.Text);
        
        if (result == "success")
        {
            JScript.Alert("AG涂布过站成功！", this);
            ClearInfo();
            return;
        }
        else
        {
            JScript.Alert("AG涂布过站失败！", this);
            return;
        }
    }
    private void ClearInfo()
    {
        txtWidth.Text = "";
        txtLength.Text = "";
        txtPreWidth.Text = "";
        txtPreLength.Text = "";

    }
}