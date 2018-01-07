using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;

public partial class Mould_MouldCompleteCheckIn : System.Web.UI.Page
{
    string CurrentWorksiteID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "成型进站");
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
            //CurrentWorksiteID = "M05";
            lblWorksiteID.Text = "M30";
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
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        //模具编号
        string MouldLot = "";
        #region 判断条码是否有效================================================
        if (txtLot.Text.Length == 10)
        {
            //外发或资产条码是否打印 条码第四位判断：W或Z
            if (txtLot.Text.Substring(3, 1).ToString() == "W")
            {
                if (CRUD.CheckMouldLabel("W", txtLot.Text) == "fail")
                {
                    JScript.Alert("该条码未打印！", this);
                    return;
                }
            }
            else if (txtLot.Text.Substring(3, 1).ToString() == "Z")
            {
                if (CRUD.CheckMouldLabel("Z", txtLot.Text) == "fail")
                {
                    JScript.Alert("该条码未打印！", this);
                    return;
                }
            }

            MouldLot = txtLot.Text.Substring(0, 3).ToString();
        }
        else
        {
            MouldLot = txtLot.Text;
        }
        #endregion
        //查询是否可以过站
        string result = CRUD.QueryStationOfLot(lblWorksiteID.Text, MouldLot);
        if (result != "success")
        {
            JScript.Alert(result, this);
            txtLot.Text = "";
            return;
        }

        //是否已经checkin
        DataTable ResDt = CRUD.GetCheckInInfo(MouldLot, lblWorksiteID.Text);
        if (ResDt.Rows.Count > 0)
        {
            //返工后重复过站
            if (ResDt.Rows[0]["rework"].ToString() == "Y")
            {
                DataTable dtCheckInIsOK = CRUD.CheckInIsOK(MouldLot, lblWorksiteID.Text);
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

        //批次已过站点
        string WorksiteIDOfLot = CRUD.GetWorksite(MouldLot);

        //查询批次流程
        CRUD.setLabelProcess(lblLotprocess, lblCurrnentWorksite, lblEndProcess, MouldLot, lblWorksiteID.Text);

        #region 显示精雕 喷砂或外发的模具参数add by lei.xue on 2017-3-16===============================================
        string FlowID = "";
        DataTable dt = CRUD.GetLotBasisInfo(MouldLot);
        if (dt.Rows.Count > 0)
        {
            FlowID = dt.Rows[0]["flowid"].ToString();
            dt = null;
            if (FlowID == "flow001")//查询精雕M15
            {
                dt = CRUD.getStationInfoOfMould(MouldLot, "M15");
            }
            else if (FlowID == "flow002")//喷砂
            {
                dt = CRUD.getStationInfoOfMould(MouldLot, "M20");
            }
            else if (FlowID == "flow003")//外发
            {
                dt = CRUD.getStationInfoOfMould(MouldLot, "M20");
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["paratype"].ToString() == "DKWidth")
                    {
                        txtDKWidth.Text = dt.Rows[i]["paraid"].ToString();
                    }
                    if (dt.Rows[i]["paratype"].ToString() == "MouldStructure")
                    {
                        txtMouldStructure.Text = dt.Rows[i]["paraid"].ToString();
                    }
                    if (dt.Rows[i]["paratype"].ToString() == "MouldPitch")
                    {
                        txtMouldPitch.Text = dt.Rows[i]["paraid"].ToString();
                    }
                    if (dt.Rows[i]["paratype"].ToString() == "Haze")
                    {
                        txtHaze.Text = dt.Rows[i]["paraid"].ToString();
                    }
                }
            }
        }        
        #endregion

    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {

        if (txtLot.Text == "" || lblLotprocess.Text == "")
        {
            JScript.Alert("请刷入批次号", this);
            return;
        }

        //模具编号
        string MouldLot = txtLot.Text.Substring(0, 3).ToString();

        //string result = Electroplate.EletroplateCheckIn(txtLot.Text,
        //                                ddlEqp.SelectedValue,
        //                                ddlWorkshop.SelectedValue,
        //                                lblWorksiteID.Text,
        //                                System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString()
        //                                );
        string result = MouldComplete.MouldCompleteCheckIn(MouldLot,
                                                           txtLot.Text,
                                                           ddlEqp.SelectedValue,
                                                           ddlWorkshop.SelectedValue,
                                                           lblWorksiteID.Text,
                                                           System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString()
                                                           );
        if (result == "success")
        {
            JScript.Alert("成型进站成功！", this);
            txtLot.Text = "";
            return;
        }
        else
        {
            JScript.Alert("成型进站失败！", this);
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
}