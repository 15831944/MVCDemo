using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;
using System.Data;

public partial class Mould_GritCheckIn : System.Web.UI.Page
{
    string CurrentWorksiteID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "喷砂进站");
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
            //CurrentWorksiteID = "M05";
            lblWorksiteID.Text = "M20";
            setddl();
        }
    }
    private void setddl()
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        //CRUD.Setdll(ddlMouldPitch,"MouldPitch");
        //CRUD.Setdll(ddlMouldStructure, "MouldStructure");

        ddlWorkshop.SelectedIndex = 0;
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);

    }

    protected void ddlWorkshop_TextChanged(object sender, EventArgs e)
    {
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

        //是否已经checkin
        DataTable ResDt = CRUD.GetCheckInInfo(txtLot.Text, lblWorksiteID.Text);
        if (ResDt.Rows.Count > 0)
        {
            //返工后重复过站
            if (ResDt.Rows[0]["rework"].ToString() == "Y")
            {
                DataTable dtCheckInIsOK = CRUD.CheckInIsOK(txtLot.Text, lblWorksiteID.Text);
                if (dtCheckInIsOK.Rows.Count > 0)
                {
                    JScript.Alert("该批次已经进站", this);
                    return;
                }
            }
            else
            {
                JScript.Alert("该批次已经进站", this);
                return;
            }
        }





        //查询批次流程
        CRUD.setLabelProcess(lblLotprocess, lblCurrnentWorksite, lblEndProcess, txtLot.Text, lblWorksiteID.Text);
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        if (txtLot.Text == "")
        {
            JScript.Alert("请刷入批次号", this);
            return;
        }

        //string result = Electroplate.EletroplateCheckIn(txtLot.Text,
        //                                ddlEqp.SelectedValue,
        //                                ddlWorkshop.SelectedValue,
        //                                lblWorksiteID.Text,
        //                                System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString()
        //                                );
        string result = CRUD.CheckIn(txtLot.Text,
                                           ddlEqp.SelectedValue,
                                           ddlWorkshop.SelectedValue,
                                           lblWorksiteID.Text,
                                           System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString()                                  
                                           );

                                            
        
        if (result == "success")
        {
            JScript.Alert("喷砂进站成功！", this);
            txtLot.Text = "";
            return;
        }
        else
        {
            JScript.Alert("喷砂进站失败！", this);
            return;
        }
    }

    private void ClearInfo()
    {
        txtLot.Text = "";
        
        lblLotprocess.Text = "";
        lblCurrnentWorksite.Text = "";
        lblEndProcess.Text = "";
        
    }
    protected void btnSaveClose_Click1(object sender, EventArgs e)
    {
        //string result = Electroplate.ElectroplateCheckOut(txtLot.Text,
        //                                           ddlEqp.SelectedValue,
        //                                           ddlWorkshop.SelectedValue,
        //                                           lblWorksiteID.Text,
        //                                           System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
        //                                           txtDCMaterial.Text,
        //                                           txtDCThinkness.Text);
        string result = Grit.GritCheckIn(txtLot.Text,
                                         ddlEqp.SelectedValue,
                                         ddlWorkshop.SelectedValue,
                                         lblWorksiteID.Text,
                                         System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString()
                                         );
        if (result == "success")
        {
            JScript.Alert("喷砂进站成功！", this);
            ClearInfo();
            return;
        }
        else
        {
            JScript.Alert("喷砂进站失败！", this);
            return;
        }
     
        
    }
}