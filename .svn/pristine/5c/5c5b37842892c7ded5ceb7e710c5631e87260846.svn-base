using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;

public partial class Mould_CarveCheckOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "精雕出站");
            //lblWorksiteID.Text = "M05";
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
            //CRUD.SetCBL(cblDCMaterial, "DCMaterial");
            //setddl();
            ChangeStationByFlow();

        }

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
        //绑定checkin时的信息
        //ddlWorkshop.ClearSelection();
        //ddlWorkshop.Items.FindByValue(workshop).Selected = true;
        //ddlEqp.ClearSelection();
        //ddlEqp.Items.FindByValue(eqp).Selected = true;
        //txtWorkshop.Text = workshop;
        //txtEqp.Text = eqp;
        //锁定机台和车间选项
        //ddlEqp
        setddl(workshop, eqp);

       
        CRUD.setLabelProcess(lblLotprocess, lblCurrnentWorksite, lblEndProcess, txtLot.Text, lblWorksiteID.Text);
        //查询车间 、checkin的机台
        //生成模具编号：规则：模具编号+类型[Z]+年月日—001Z170118
        DataTable dt = CRUD.GetWorkflow(txtLot.Text);
        string type = dt.Rows[0]["flowid"].ToString();
        if (type == "flow001" || type == "flow002")
        {
            txtLabelInfo.Text = txtLot.Text + "Z" + System.DateTime.Now.ToString("yyMMdd");
        }
        else if (type == "flow003")
        {
            txtLabelInfo.Text = txtLot.Text + "W" + System.DateTime.Now.ToString("yyMMdd");
        }
    }

    private void setddl(string workshop, string eqp)
    {
        ddlMouldPitch.Items.Clear();
        ddlMouldPitch.Items.Add(new ListItem("", ""));
        ddlMouldStructure.Items.Clear();
        ddlMouldStructure.Items.Add(new ListItem("", ""));

        CRUD.Setdll(ddlMouldPitch, "MouldPitch");
        CRUD.Setdll(ddlMouldStructure, "MouldStructure");

        CRUD.Setdll(ddlWorkshop, "workshop");
        //ddlWorkshop.SelectedIndex = 0;
        ddlWorkshop.ClearSelection();
        ddlWorkshop.Items.FindByValue(workshop).Selected = true;
        ddlEqp.ClearSelection();
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);
        ddlEqp.Items.FindByValue(eqp).Selected = true;

    }

    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        
        //string a = ddlWorkshop.SelectedValue;
        if (txtLot.Text == "")
        {
            JScript.Alert("请刷入批次号", this);
            return;
        }
        #region//========防止重复出站 add by lei.xue on 2017-8-29=======================
        //查询是否可以过站
        string result1 = CRUD.QueryStationOfLot(lblWorksiteID.Text, txtLot.Text);
        if (result1 != "success")
        {
            JScript.Alert(result1, this);
            txtLot.Text = "";
            return;
        }
        #endregion
        //检查是否是标签条码
        string strLabel = "";
        if (txtLot.Text.Length > 3)
        {
            strLabel = txtLot.Text;
        }

        string result = "";
        if (cbxReworkID.Checked ==false)
        {
            //增加剩余厚度、钻石刀号、雕刻次数 modify by lei.xue on 2017-4-13=========================
            result = Carve.CarveCheckOut(txtLot.Text, txtLabelInfo.Text, ddlEqp.SelectedValue, ddlWorkshop.Text, lblWorksiteID.Text
                                    , System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),txtDKWidth.Text,ddlMouldStructure.SelectedValue,ddlMouldPitch.SelectedValue,
                                    txtRestThinkness.Text,
                                    txtDiamondCutterNo.Text,
                                    txtDKQty.Text);
            if (result == "success")
            {
                //打印标签调用前台方法
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>PrintLabel();</script>");
                //JScript.Alert("精雕出站成功！", this);
                //ClearInfo();
                return;
            }
            else
            {
                JScript.Alert("精雕出站失败！", this);
                return;
            }
        }
        else
        {
            #region 变更返工流程 M10是外发flow
            //string strFlow = "";
            //if (ddlWorksite.SelectedValue == "M10")
            //{
            //    strFlow = "flow003";
            //}
            //else
            //{
            //    strFlow = "flow001";
            //}
            string resultFlow = CRUD.ChangLotWorkflow(ddlWorkflow.SelectedValue, txtLot.Text.Substring(0, 3).ToString());
            if (resultFlow != "success")
            {
                JScript.Alert("变更产品流程出错！", this);
                return;
            }
            #endregion
            

            //返工站点的流程编号
            //string Flowidno="";
            //Flowidno = CRUD.GetFlowidno(txtLot.Text,ddlWorksite.SelectedValue);
            //增加剩余厚度、钻石刀号、雕刻次数 modify by lei.xue on 2017-4-13=========================
            result = Carve.CarveCheckOut(txtLot.Text, "", ddlEqp.SelectedValue, ddlWorkshop.Text, lblWorksiteID.Text
                        , System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(), txtDKWidth.Text, ddlMouldStructure.SelectedValue, ddlMouldPitch.SelectedValue,
                                    txtRestThinkness.Text,
                                    txtDiamondCutterNo.Text,
                                    txtDKQty.Text);
            #region 返工记录
            //返工站点的流程编号
            string Flowidno = "";
            Flowidno = CRUD.GetReworkFlowidno(ddlWorkflow.SelectedValue, ddlWorksite.SelectedValue); //CRUD.GetFlowidno(txtLot.Text.Substring(0, 3).ToString(), ddlWorksite.SelectedValue);
            //记录返工记录
            CRUD.rework(lblWorksiteID.Text, ddlWorksite.SelectedValue, txtLot.Text.Substring(0, 3).ToString(),
                         System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(), Flowidno);
            #endregion
            //记录返工记录
            //CRUD.rework(lblWorksiteID.Text, ddlWorksite.SelectedValue, txtLot.Text,
            //             System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(), Flowidno);
            //变更返工流程 M10是外发flow
            //if (ddlWorksite.SelectedValue == "M10")
            //{
            //  string resultFlow=  CRUD.ChangLotWorkflow("flow003", txtLot.Text);

            //  if (result != "success")
            //  {
            //      JScript.Alert("变更产品流程出错！", this);
            //      return;
            //  }
            //}


            if (result == "success")
            {
                JScript.Alert("精雕出站成功！", this);
                ClearInfo();
                return;
            }
            else
            {
                JScript.Alert("精雕出站失败！", this);
                return;
            }
        }

    }
    /// <summary>
    /// 清除页面信息
    /// </summary>
    private void ClearInfo()
    {
        txtLot.Text = "";
        txtLabelInfo.Text = "";
        lblLotprocess.Text = "";
        lblLotprocess.Text = "";
        lblCurrnentWorksite.Text = "";
        lblEndProcess.Text = "";
    }
    protected void ddlWorkflow_TextChanged(object sender, EventArgs e)
    {
        ChangeStationByFlow();
    }

    private void ChangeStationByFlow()
    {
        if (ddlWorkflow.SelectedValue == "flow003")
        {
            ddlWorksite.SelectedValue = "M10";
        }
        lblReworkFlow.Text =  CRUD.GetWorkFlowByFlowID(ddlWorkflow.SelectedValue);
    }
}