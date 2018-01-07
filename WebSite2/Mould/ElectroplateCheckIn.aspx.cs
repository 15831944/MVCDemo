using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;

public partial class Mould_ElectroplateCheckIn : System.Web.UI.Page
{
    //string CurrentWorksiteID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "电镀进站");
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
            //CurrentWorksiteID = "M05";
            lblWorksiteID.Text = "M05";
            setddl();
        }
    }
    private void setddl()
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        ddlWorkshop.SelectedIndex = 0;
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);
        
    }

    protected void ddlWorkshop_TextChanged(object sender, EventArgs e)
    {
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text );
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        //查询是否可以过站
        string result = CRUD.QueryStationOfLot(lblWorksiteID.Text ,txtLot.Text);
        if(result !="success")
        {
            if (result == "该批次已经结束流程！")
            {
                JScript.Alert("批次流程已经结束，请复位后重新过站！", this);
                return;
            }
            else
            {
                JScript.Alert(result, this);
                txtLot.Text = "";
                return;
            }
        }

        //是否已经checkin
        DataTable ResDt = CRUD.GetCheckInInfo(txtLot.Text, lblWorksiteID.Text);
        if (ResDt.Rows.Count > 0)
        {
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

        CRUD.setLabelProcess(lblLotprocess, lblCurrnentWorksite, lblEndProcess, txtLot.Text, lblWorksiteID.Text);
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        if (txtLot.Text == "")
            if (txtLot.Text == "")
        {
            JScript.Alert("请刷入批次号", this);
            return;
        }

        string result = Electroplate.EletroplateCheckIn(txtLot.Text,
                                        ddlEqp.SelectedValue,
                                        ddlWorkshop.SelectedValue,
                                        lblWorksiteID.Text,
                                        System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString()
                                        );
        if (result == "success")
        {
            JScript.Alert("电镀进站成功！", this);
            ClearInfo();
            return;
        }
        else
        {
            JScript.Alert("电镀进站失败！", this);
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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string result = CRUD.RestartMouldLotProcess(txtLot.Text);
        if (result == "success")
        {
            JScript.Alert("复位成功，模具可以继续过站", this);
            return;
        }
        else
        {
            JScript.Alert("复位失败！", this);
            return;
        }
    }
}