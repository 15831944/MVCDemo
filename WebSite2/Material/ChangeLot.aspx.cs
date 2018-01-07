using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;
using System.Data;
public partial class Material_ChangeLot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonClass.isAllow(User.Identity.Name, this, "批次变更");
            //lblWorksiteID.Text = "M05";
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");




            //CRUD.SetCBL(cblDCMaterial, "DCMaterial");
            //setddl();

        }
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        if (ddlLabelType.SelectedValue == "模具条码")
        {
            if (CheckMould() == "fail")
            {
                return;
            }
            CRUD.setWorkFlowDDL(ddlWorkflow, "Mould");
        }
        else if (ddlLabelType.SelectedValue == "制造条码")
        {
            if (CheckProduct() == "fail")
            {
                return;
            }
            CRUD.setWorkFlowDDL(ddlWorkflow, "Film");
        }
        //显示批次流程ID
        ddlWorkflow.ClearSelection();
        ddlWorkflow.Items.FindByValue(ViewState["FlowID"].ToString()).Selected = true;
        //加载流程站点
        ChangeLot.QueryWorkSite(ddlStation, ddlWorkflow.SelectedValue);

    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        if (ddlChangeType.SelectedValue == "跳站")
        {
 
        }
    }

    private void ClearInfo()
    {
        txtLot.Text = "";
    }
    private string CheckProduct()
    {
        string originalLot = "";
        //UV成型进行分批取消判断是否是UV成型条码判断modify by lei.xue on 2017-3-28
        //判断是否是UV成型的条码
        //string check = CRUD.CheckFilmLabel("UV成型", txtLot.Text);
        //if (check != "fail")
        //{
        //    originalLot = check;
        //}
        //else
        //{
        //    originalLot = txtLot.Text;
        //}
        ViewState["originalLot"] = originalLot;

        DataTable lotDt = CRUD.GetLotBasisInfo(originalLot);
        if (lotDt.Rows.Count == 0 || lotDt.Rows[0]["lottype"].ToString() != "Film")
        {
            JScript.Alert("未找到条码信息", this);
            return "fail";
        }

        //读取批次flowid 
        ViewState["FlowID"] = lotDt.Rows[0]["flowid"].ToString();

        //批次已过站点
        string WorksiteIDOfLot = CRUD.GetWorksite(originalLot);
        //查询批次流程
        string strFlow = "";
        DataTable dt = CRUD.GetWorkflow(originalLot);
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
        return "success";

    }

    private string CheckMould()
    {
        //模具编号
        string MouldLot = "";
        #region 判断条码是否有效
        if (txtLot.Text.Length > 3)
        {
            //外发或资产条码是否打印 条码第四位判断：W或Z
            if (txtLot.Text.Substring(3, 1).ToString() == "W")
            {
                if (CRUD.CheckMouldLabel("W", txtLot.Text) == "fail")
                {
                    JScript.Alert("该条码为打印！", this);
                    return "fail";
                }
            }
            else if (txtLot.Text.Substring(3, 1).ToString() == "Z")
            {
                if (CRUD.CheckMouldLabel("Z", txtLot.Text) == "fail")
                {
                    JScript.Alert("该条码未打印！", this);
                    return "fail";
                }
            }
            else
            {
                JScript.Alert("条码未打印", this);
                return "fail";
            }
        }
        else
        {
            JScript.Alert("条码未打印", this);
            return "fail";
        }
        #endregion
        //模具编号
        MouldLot = txtLot.Text.Substring(0, 3).ToString();

        DataTable lotDt = CRUD.GetLotBasisInfo(MouldLot);
        if (lotDt.Rows.Count > 0)
        {
            //读取批次flowid 
            ViewState["FlowID"] = lotDt.Rows[0]["flowid"].ToString();
        }

        //批次已过站点
        string WorksiteIDOfLot = CRUD.GetWorksite(MouldLot);
        //查询批次流程
        string strFlow = "";
        DataTable dt = CRUD.GetWorkflow(MouldLot);
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
        return "success";
    }


    protected void ddlWorkflow_TextChanged(object sender, EventArgs e)
    {
        ChangeLot.QueryWorkSite(ddlStation, ddlWorkflow.SelectedValue);
    }
    protected void ddlChangeType_TextChanged(object sender, EventArgs e)
    {
        if (ddlChangeType.SelectedValue == "跳站")
        {
            if (lblLotprocess.Text != "")
            {
                //显示批次流程ID
                ddlWorkflow.ClearSelection();
                ddlWorkflow.Items.FindByValue(ViewState["FlowID"].ToString()).Selected = true;
                ddlWorkflow.Enabled = false;
            }

        }
        else if (ddlChangeType.SelectedValue == "跳流程")
        {
            ddlWorkflow.Enabled = true;
        }

    }
}