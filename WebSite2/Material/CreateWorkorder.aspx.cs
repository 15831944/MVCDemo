using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;
using System.Data;

public partial class Mould_CreateWorkorder : System.Web.UI.Page
{
    string CurrentWorksiteID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "创建工单");
            setddl();
            Showflowid(ddlWorkflow.SelectedValue);
        }
    }



    private void setddl()
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        CRUD.Setdll(ddlBOM, "BOM");
        CRUD.setWorkFlowDDL(ddlWorkflow,"Film");

    }
    /// <summary>
    /// 生成工单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        //J171AN001
        //i.	第 一 码 ：系统默认‘J’
        //ii.	第二三码 ：年
        //iii.	第 四 码 ：月（10月后用ABC代替）
        //iv.	第 五 码 ：工艺路线（用ABC代替）
        //v.	第 六 码 ：工单类型（N正常、R返工、E实验、W委外）
        //vi.	七至九码 ：流水号（按年月递增计数了，跨月后从001开始）
        //修改工单规则 N201703001 modify by lei.xue on 2017-3-27====================================================
        string lotNo="";
        
        string Month = System.DateTime.Now.ToString("MM");
        if (Month == "10") { Month = "A"; }
        if (Month == "11") { Month = "B"; }
        if (Month == "12") { Month = "C"; }
        Month = Month.Replace("0","");//月份取一位
        //string WO = "J" + System.DateTime.Now.ToString("yy") + Month + ddlWorkflow.SelectedItem.Text + ddlWorkorderType.SelectedValue;
        string WO = ddlWorkorderType.SelectedValue + System.DateTime.Now.ToString("yyyyMM");
        lotNo = CreateWorkorder.getWorkOrderQty(WO);
        WO = WO + (Convert.ToInt32(lotNo) + 1).ToString("000");
        txtWorkorder.Text = WO;
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (txtWorkorder.Text == "")
        {
            JScript.Alert("请先生成工单！", this);
            return;
        }

        if (CreateWorkorder.ExistWO(txtWorkorder.Text) == "success")
        {
            JScript.Alert("工单已存在！", this);
            return;
        }

        string result=CreateWorkorder.CreateWO(txtWorkorder.Text,
                                        ddlBOM.SelectedValue,
                                        ddlWorkflow.SelectedValue,
                                        ddlWorkshop.SelectedValue,
                                        System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
                                        txtMouldPinMin.Text,
                                        txtlMouldLength.Text,
                                        txtMouldThinkness.Text,
                                        txtMouldWidth.Text,
                                        txtMouldType.Text,
                                        txtMouldPETType.Text,
                                        ddlWorkorderType.SelectedValue
                                        );
        if (result == "success")
        {
            JScript.Alert("创建工单成功！", this);
            
            //JScript.AlertAndRedirect("创建工单成功！", "../Material/CreateWorkorder.aspx", this);
            //显示创建工单记录信息
            lblHistory.Text = System.DateTime.Now.ToString() + " 创建工单：" + txtWorkorder.Text + "<br>" + lblHistory.Text;
            Clearinfo();
        }
    }

    private void Clearinfo()
    {
        txtMouldPinMin.Text = "";
        txtMouldThinkness.Text = "";
        txtlMouldLength.Text = "";
        txtMouldWidth.Text = "";
        txtMouldType.Text = "";
        txtMouldPETType.Text = "";
        txtWorkorder.Text = "";
    }
    protected void ddlWorkflow_TextChanged(object sender, EventArgs e)
    {
        Showflowid(ddlWorkflow.SelectedValue);
    }

    private void Showflowid(string flowid)
    {
        //查询批次流程
        string strFlow = "";
        DataTable dt = CRUD.GetWorkflowByFlowid(flowid);
        for (int i = 0; i < dt.Rows.Count; i++)
        {


            strFlow = strFlow + dt.Rows[i]["worksitename"].ToString() + "->";

        }
        if (strFlow != "")
        {
            strFlow = strFlow.Remove((strFlow).Length - 2, 2);
        }
        lblProcess.Text = strFlow;
    }
}