﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;

public partial class Mould_CreateMouldLot : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "模具编号");
            txtLotCount.Attributes.Add("onkeypress", "EnterTextBox()");
            CreateTable();
            databind();
            CRUD.Setdll(ddlWorkshop, "workshop");
            CRUD.setWorkFlowDDL(ddlWorkFlow,"Mould");
            Showflowid(ddlWorkFlow.SelectedValue);

        }
    }
    //protected void btnSaveClose_Click(object sender, EventArgs e)
    //{
    //    test();
    //}

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
        lblLotprocess.Text = strFlow;
    }

    private void CreateTable()
    {
        //创建列
        dt.Columns.Clear();
        dt.Rows.Clear();
        DataColumn dtCol = new DataColumn("mouldid", typeof(string));
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
        int beginValue;
        
        
        beginValue = CreateMouldLot.QueryMaxNum();
        beginValue =  beginValue + 1;
        dt = (DataTable)ViewState["dt"];
        dt.Rows.Clear();
        DataRow dtRow;
        for (int i = beginValue; i <= Convert.ToInt32(txtLotCount.Text)+beginValue-1; i++)
        {

            //CreateMouldLot.InsertLot()
            //AddRow((i).ToString("000"));  
            dtRow = dt.NewRow();
            dtRow["mouldid"] = i.ToString("000");
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
            JScript.Alert("请先生成模具编号，在文本框输入数量按回车！", this);
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
            dl.flowid = ddlWorkFlow.SelectedValue;
            dl.workshopid = ddlWorkshop.SelectedValue;
            dl.lottype = "Mould";
            dl.status = "Active";
            dl.createuser = System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString();
            dl.currentflowidno = "0";
            dl.factoryid = "";
            dl.reworkorder = "";
            dl.lotid = grd.Rows[i].Cells[0].Text;
            dl.lotcount = "1";
            dl.ProcessComplete = "N";
            string result = CreateMouldLot.InsertLot(dl);
            if (result != "success")
            {
                JScript.Alert(result,this);
                return;
            }
            JScript.Alert("创建模具编号成功！", this);
            CreateTable();
            databind();
            txtLotCount.Text = "";
        }
    }
    protected void ddlWorkFlow_TextChanged(object sender, EventArgs e)
    {
        Showflowid(ddlWorkFlow.SelectedValue);
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        DataTable dt = CRUD.GetLotBasisInfo(txtLot.Text);

        if (dt.Rows.Count > 0 && dt.Rows[0]["processcomplete"].ToString() == "Y" && dt.Rows[0]["lottype"].ToString() == "Mould")
        {
            string result = CRUD.RestartMouldLotProcess(txtLot.Text, ddlWorkFlow.SelectedValue);
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
        else
        {
            JScript.Alert("批次无法复位", this);

        }
    }
}