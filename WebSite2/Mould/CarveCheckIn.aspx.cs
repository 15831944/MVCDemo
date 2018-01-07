using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;
using System.Data;

public partial class Mould_CarveCheckIn : System.Web.UI.Page
{
    //string CurrentWorksiteID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "精雕进站");

            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
            //CurrentWorksiteID = "M05";
            lblWorksiteID.Text = "M15";
            setddl();
            //当前站点显示颜色 modify by lei.xue on 2017-2-12
            //lblCurrnentWorksite.ForeColor = System.Drawing.Color.FromName("#FFFFFF");
            //lblCurrnentWorksite.BackColor = System.Drawing.Color.FromName("#0080FF");
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
            //批次查询出当前站点是否有Checkin信息，但是返工的批次不检查返工前的checkin信息
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

        //批次已过站点
        string WorksiteIDOfLot = CRUD.GetWorksite(txtLot.Text);

        //查询批次流程
        string CurrentSite = "N";
        string EndSite = "N";
        string BeginFlow = "";
        string EndFlow = "";
        string strFlow = "";
        DataTable dt = CRUD.GetWorkflow(txtLot.Text);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //if (WorksiteIDOfLot == dt.Rows[i]["worksiteID"].ToString())
            //{
            //    strFlow = strFlow + "[" + dt.Rows[i]["worksitename"].ToString() + "]" + "->";
            //    lblCurrnentWorksite.Text = dt.Rows[i]["worksitename"].ToString();
            //}
            //else
            //{
            //    strFlow = strFlow + dt.Rows[i]["worksitename"].ToString() + "->";
            //}

            if (EndSite == "Y")
            {
                EndFlow = EndFlow + dt.Rows[i]["worksitename"].ToString() + "->";
            }
            if (WorksiteIDOfLot == dt.Rows[i]["worksiteID"].ToString())
            {
                strFlow = strFlow + "[" + dt.Rows[i]["worksitename"].ToString() + "]" + "->";
                lblCurrnentWorksite.Text = "[" + dt.Rows[i]["worksitename"].ToString() + "]" + "->";
                CurrentSite = "Y";
                EndSite = "Y";
            }
            if (CurrentSite=="N")
            {
                BeginFlow = BeginFlow + dt.Rows[i]["worksitename"].ToString() + "->";
            }


        }
        if (EndFlow != "" && BeginFlow=="" && lblCurrnentWorksite.Text !="")
        {
            EndFlow = EndFlow.Remove((EndFlow).Length - 2, 2);
        }
        if (EndFlow == "" && BeginFlow != "" && lblCurrnentWorksite.Text != "")
        {
            lblCurrnentWorksite.Text = lblCurrnentWorksite.Text.Remove((lblCurrnentWorksite.Text).Length - 2, 2);
        }
        //string strFlow = "";

        lblLotprocess.Text = BeginFlow;

        //当前站点显示颜色 modify by lei.xue on 2017-2-12
        //lblCurrnentWorksite.ForeColor = System.Drawing.Color.FromName("#FFFFFF");
        //lblCurrnentWorksite.BackColor = System.Drawing.Color.FromName("#0080FF");

        lblEndProcess.Text = EndFlow;

    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        btnSaveClose.Enabled = false;
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
        string result = Carve.CarveCheckIn(txtLot.Text,
                                           ddlEqp.SelectedValue,
                                           ddlWorkshop.SelectedValue,
                                           lblWorksiteID.Text,
                                           System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString()
                                           );


        btnSaveClose.Enabled =true;
        if (result == "success")
        {
            JScript.Alert("精雕进站成功！", this);
            ClearInfo();

            return;
        }
        else
        {
            JScript.Alert("精雕进站失败！", this);
            return;
        }
    }

    private void ClearInfo()
    {
        txtLot.Text = "";
        txtDKWidth.Text = "";
        lblLotprocess.Text = "";
        lblCurrnentWorksite.Text = "";
        lblEndProcess.Text = "";

    }
}