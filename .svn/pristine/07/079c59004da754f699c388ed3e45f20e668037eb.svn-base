using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using Pub;
public partial class Product_AGCheck : System.Web.UI.Page
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
        //膜的等级
        CRUD.Setdll(ddlFilmLevel, "FilmLevel");
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
        //膜等级
        txtFilmLevel.Text = lotDt.Rows[0]["mouldlevel"].ToString();
        setddl(workshop);

        string WO = lotDt.Rows[0]["workorder"].ToString();
        #region 批次流程
        //批次已过站点
        string WorksiteIDOfLot = CRUD.GetWorksite(txtLot.Text);
        //查询批次流程
        string strFlow = "";
        DataTable dt = CRUD.GetWorkflow(txtLot.Text);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (WorksiteIDOfLot == dt.Rows[i]["worksiteID"].ToString())
            {
                strFlow = strFlow + "[" + dt.Rows[i]["worksitename"].ToString() + "]" + "->";
            }
            else
            {
                strFlow = strFlow + dt.Rows[i]["worksitename"].ToString() + "->";
            }
        }
        if (strFlow != "")
        {
            strFlow = strFlow.Remove((strFlow).Length - 2, 2);
        }
        lblLotprocess.Text = strFlow;
        #endregion
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        string result=CRUD.FilmCheckOut(txtLot.Text, "", ddlEqp.SelectedValue, ddlWorkshop.SelectedValue,
                            lblWorksiteID.Text,
                            System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
                            ddlFilmLevel.SelectedValue);
        string resultLevel = "";
        if (cbxUpdateLevel.Checked == true)
        {
            resultLevel = CRUD.updateFilmLevel(txtFilmLevel.Text,
                                                      ddlFilmLevel.SelectedValue,
                                                      txtLot.Text,
                                                      System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
                                                      lblWorksiteID.Text
                                                      );
        }

        if (result == "success" && resultLevel!= "fail")
        {
            JScript.Alert("AG涂布检验过站成功！", this);
            ClearInfo();
            return;
        }
        else
        {
            JScript.Alert("AG涂布检验过站失败！", this);
            return;
        }
    }

    private void ClearInfo()
    {
        txtLot.Text = "";
        txtReason.Text = "";

    }
}