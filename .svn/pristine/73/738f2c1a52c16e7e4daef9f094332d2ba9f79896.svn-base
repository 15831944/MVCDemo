using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;

public partial class Material_LotManage : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "创建批次号");
            txtLotCount.Attributes.Add("onkeypress", "EnterTextBox()");
            txtWorkOrder.Attributes.Add("onkeypress", "EnterTextBoxWO()");
            CreateTable();
            databind();
            //CRUD.SetWODDL(ddlWorkorder);
            CRUD.SetWOCbx(cblWorkOrder);

            //setBominfo(ddlWorkorder.SelectedValue);

            //设置文本框只读，变灰 BackColor="#e8e8e8"
            txtWorkshopID.Attributes.Add("readonly", "true");
            //txtWorkshopID.Attributes.Add("BackColor", "#e8e8e8");
            
            txtBOMID.Attributes.Add("readonly", "true");
            //txtBOMID.BackColor = System.Drawing.Color.FromName("#e8e8e8");
            txtWorkflow.Attributes.Add("readonly", "true");
            //txtWorkflow.Attributes.Add("BackColor", "#e8e8e8");
            txtWorkorderType.Attributes.Add("readonly", "true");
            //txtWorkorderType.Attributes.Add("BackColor", "#e8e8e8");
            txtMouldPinMin.Attributes.Add("readonly", "true");
            //txtMouldPinMin.Attributes.Add("BackColor", "#e8e8e8");
            txtMouldThinkness.Attributes.Add("readonly", "true");
            //txtMouldThinkness.Attributes.Add("BackColor", "#e8e8e8");
            txtMouldLength.Attributes.Add("readonly", "true");
            //txtlMouldLength.Attributes.Add("BackColor", "#e8e8e8");
            txtMouldWidth.Attributes.Add("readonly", "true");
            //txtMouldWidth.Attributes.Add("BackColor", "#e8e8e8");
            txtMouldType.Attributes.Add("readonly", "true");
            //txtMouldType.Attributes.Add("BackColor", "#e8e8e8");

        }
    }
    //protected void btnSaveClose_Click(object sender, EventArgs e)
    //{
    //    test();
    //}
    private void setBominfo(string wo)
    {
        DataTable dt = CreateLot.QueryWorkorderIno(wo);
        if (dt.Rows.Count > 0)
        {
            txtBOMID.Text = dt.Rows[0]["bomid"].ToString();
            txtMouldLength.Text = dt.Rows[0]["mouldLength"].ToString();
            txtMouldPETType.Text = dt.Rows[0]["mouldpettype"].ToString();
            txtMouldPinMin.Text = dt.Rows[0]["mouldpinmin"].ToString();
            txtMouldThinkness.Text = dt.Rows[0]["mouldthinkness"].ToString();
            txtMouldType.Text = dt.Rows[0]["mouldtype"].ToString();
            txtMouldWidth.Text = dt.Rows[0]["mouldwidth"].ToString();
            txtWorkflow.Text = dt.Rows[0]["flowidalias"].ToString();
            txtWorkorderType.Text = dt.Rows[0]["workordertype"].ToString();
            txtWorkshopID.Text = dt.Rows[0]["WorkshopID"].ToString();
            txtWorkflowID.Text = dt.Rows[0]["flowid"].ToString();
            Showflowid(dt.Rows[0]["flowid"].ToString());
        }
        else
        {
            JScript.Alert("未查询到工单信息", this);
        }
    }
    private void clearinfo()
    {
        txtBOMID.Text = "";
        txtMouldLength.Text = "";
        txtMouldPETType.Text = "";
        txtMouldPinMin.Text = "";
        txtMouldThinkness.Text = "";
        txtMouldType.Text = "";
        txtMouldWidth.Text = "";
        txtWorkflow.Text = "";
        txtWorkorderType.Text = "";
        txtWorkshopID.Text = "";

        txtWorkflowID.Text = "";
    }
    private void CreateTable()
    {
        //创建列
        dt.Columns.Clear();
        dt.Rows.Clear();
        DataColumn dtCol = new DataColumn("mouldid", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("Length", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("Width", typeof(string));
        dt.Columns.Add(dtCol);
        ViewState["dt"] = dt; 
    }
    private void AddRow(string mouldlot)
    {
        dt = (DataTable)ViewState["dt"];
        DataRow dtRow = dt.NewRow();
        dtRow["mouldid"] = mouldlot;
        dt.Rows.Add(dtRow);
        ViewState["dt"] = dt;
    }
    private void databind()
    {
        DataTable  dt1 = (DataTable)ViewState["dt"];
        this.grd.DataSource = dt1;
        this.grd.DataBind();
      
    }
    //private void test()
    //{
    //   grd.DataSource= EqpManage.Exist("All");
    //    grd.DataBind();
    //}
    protected void txtBtnEnter_Click(object sender, EventArgs e)
    {
        //长度和宽度是否已经输入
        if (txtLotLength.Text == "") 
        {
            JScript.Alert("请输入批次长度", this);
            return;
        }
        if (txtLotWidth.Text == "")
        {
            JScript.Alert("请输入批次宽度", this);
            return;
        }
        int beginValue;
        beginValue = CreateLot.QueryMaxNum(txtWorkOrder.Text);
        if (beginValue >= 999)
        {
            JScript.Alert("工单数量已经用完大于999个序列号", this);
            return;
        }
        beginValue =  beginValue + 1;
        dt = (DataTable)ViewState["dt"];
        dt.Rows.Clear();
        DataRow dtRow;
        for (int i = beginValue; i <= Convert.ToInt32(txtLotCount.Text)+beginValue-1; i++)
        {

            //CreateMouldLot.InsertLot()
            //AddRow((i).ToString("000"));  
            dtRow = dt.NewRow();
            dtRow["mouldid"] = txtWorkOrder.Text + i.ToString("000");
            dtRow["Length"] = txtLotLength.Text;
            dtRow["Width"] = txtLotWidth.Text;
            dt.Rows.Add(dtRow);
        }
        ViewState["dt"] = dt;
        databind();

    }

    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        DataTable viewdt = (DataTable)ViewState["dt"];
        if (viewdt.Rows.Count <= 0)
        {
            JScript.Alert("请先生成PET编号，在文本框输入数量按回车！", this);
            return;
        }
        //循环datatable插入lotbasis
        for (int i = 0; i <= grd.Rows.Count - 1; i++)
        {
            //CheckBox cbx = (CheckBox)grd.Rows[i].FindControl("cbx");
            //if (cbx.Checked == true)
            //{
            //    //result = EqpManage.Delete(grd.Rows[i].Cells[1].Text);
            //    //if (result != "success")
            //    //{
            //    //    JScript.Alert("删除设备！", this);
            //    //}
            //}
            LotBasisDatalist dl = new LotBasisDatalist();
            dl.flowid = txtWorkflowID.Text;
            dl.workshopid = txtWorkshopID.Text;
            dl.lottype = "Film";
            dl.status = "Active";
            dl.createuser = System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString();
            dl.currentflowidno = "0";
            dl.factoryid = "";
            dl.workorder = txtWorkOrder.Text;//ddlWorkorder.SelectedValue;
            dl.reworkorder = "";
            dl.lotid = grd.Rows[i].Cells[0].Text;
            dl.lotcount = "1";
            dl.Filmlevel = "A";
            //创建批次增加宽度和长度记录
            //批次长宽改为手动输入 modify by lei.xue on 2017-4-12================================================
            //dl.length = txtMouldLength.Text;
            //dl.restlength = txtMouldLength.Text;
            //dl.width = txtMouldWidth.Text;
            //dl.restwidth = txtMouldWidth.Text;
            dl.length = txtLotLength.Text;
            dl.restlength = txtLotLength.Text;
            dl.width = txtLotWidth.Text;
            dl.restwidth = txtLotWidth.Text;

            string result = CreateMouldLot.InsertLot(dl);
            if (result != "success")
            {
                JScript.Alert("创建PET膜序列号失败！",this);
                return;
            }
            JScript.Alert("创建PET膜序列号成功！", this);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>PrintLabel();</script>");
            //CreateTable();
            //databind();
            //txtLotCount.Text = "";
        }
    }
    protected void ddlWorkorder_TextChanged(object sender, EventArgs e)
    {
        //setBominfo(ddlWorkorder.SelectedValue);
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
    protected void btnWOEnter_Click(object sender, EventArgs e)
    {
        setBominfo(txtWorkOrder.Text);
    }
}