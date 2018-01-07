using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;
using System.Data;
using System.Data.Common;
public partial class Mould_Electroplate : System.Web.UI.Page
{
    log4net.ILog log = log4net.LogManager.GetLogger(typeof(Mould_Electroplate));
    //string  lblWorksiteID.Text ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "电镀出站");
            //lblWorksiteID.Text = "M05";
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
            CRUD.SetCBL(cblDCMaterial, "DCMaterial");
            //setddl();

            //btnSaveClose.Attributes.Add("onclick", "this.value='正在提交中,請稍等……';this.disabled=true;" + this.GetPostBackEventReference(btnSaveClose) + ";");

            
        }
    }
    private void setddl(string workshop,string eqp)
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        //ddlWorkshop.SelectedIndex = 0;
        ddlWorkshop.ClearSelection();
        ddlWorkshop.Items.FindByValue(workshop).Selected = true;
        ddlEqp.ClearSelection();
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);
        ddlEqp.Items.FindByValue(eqp).Selected = true;
        
    }

    //protected void ddlWorkshop_TextChanged(object sender, EventArgs e)
    //{
    //    CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);
    //}
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
        //是否进站
        //result = CRUD.CheckInIsOK(txtLot.Text, lblWorksiteID.Text);
        //if (result != "success")
        //{
        //    JScript.Alert("批次尚未进站！", this);
        //    txtLot.Text = "";
        //    return;
        //}       
        string MouldLot = txtLot.Text;
        string workshop="";
        string eqp="";
        DataTable ResDt = CRUD.GetCheckInInfo(MouldLot, lblWorksiteID.Text);
        if (ResDt.Rows.Count > 0)
        {
            //返工后重复过站
            if (ResDt.Rows[0]["rework"].ToString() == "Y")
            {
                DataTable dtCheckInIsOK = CRUD.CheckInIsOK(MouldLot, lblWorksiteID.Text);
                if (dtCheckInIsOK.Rows.Count > 0)
                {
                    workshop = dtCheckInIsOK.Rows[0]["workshopid"].ToString();
                    eqp = dtCheckInIsOK.Rows[0]["eqpid"].ToString();
                }
                else
                {
                    JScript.Alert("该批次尚未进站！", this);
                    return;
                }
            }
            else
            {
                eqp = ResDt.Rows[0]["eqpid"].ToString();
                workshop = ResDt.Rows[0]["workshopid"].ToString();
            }
        }
        else
        {
            JScript.Alert("批次尚未进站", this);
            return;
        }
        setddl(workshop, eqp);
        //查询批次流程
        CRUD.setLabelProcess(lblLotprocess, lblCurrnentWorksite, lblEndProcess, txtLot.Text, lblWorksiteID.Text);
    }

    protected void btnSaveClose_Click(object sender, EventArgs e)
    {

        //btnSaveClose.Attributes.Add("disabled", "true");
        //string a = ddlWorkshop.SelectedValue;
        log.Info(txtLot.Text+"电镀CheckOut");
        if (txtLot.Text == "")
        {
            JScript.Alert("请刷入批次号", this);
            btnSaveClose.Enabled = true;
            return;
        }

        //========防止重复出站 add by lei.xue on 2017-8-29=======================
        //查询是否可以过站
        string result1 = CRUD.QueryStationOfLot(lblWorksiteID.Text, txtLot.Text);
        if (result1 != "success")
        {
            JScript.Alert(result1, this);
            txtLot.Text = "";
            return;
        }
        string result = Electroplate.ElectroplateCheckOut(txtLot.Text,
                                                           ddlEqp.SelectedValue,
                                                           ddlWorkshop.SelectedValue,
                                                           lblWorksiteID.Text,
                                                           System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
                                                           txtDCMaterial.Text,
                                                           txtDCThinkness.Text);
        if (result == "success")
        {
            JScript.Alert("电镀出站成功！", this);
            btnSaveClose.Enabled = true;
            ClearInfo();
            return;
        }
        else
        {
            JScript.Alert("电镀出站失败！", this);
            btnSaveClose.Enabled = true;
            return;
        }
        btnSaveClose.Enabled = true;
    }

    /// <summary>
    /// 清除页面信息
    /// </summary>
    private void ClearInfo()
    {
        txtLot.Text = "";
        txtDCThinkness.Text = "";
        txtDCMaterial.Text = "";
        lblLotprocess.Text = "";
        lblCurrnentWorksite.Text = "";
        lblEndProcess.Text = "";
    }

}