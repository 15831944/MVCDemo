﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;
public partial class Product_PasteFilm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "分条");
            txtLot.Attributes.Add("onkeypress", "EnterTextBox('btnEnter')");
            txtSplitLocation.Attributes.Add("onkeypress", "EnterTextBoxSplit('btnSplitEnter')");
            txtPreWidth.Attributes.Add("readonly", "true");
            txtPreLength.Attributes.Add("readonly", "true");
            txtRestWidth.Attributes.Add("readonly", "true");
            txtLabelInfo.Attributes.Add("readonly", "true");
        }
    }

    private void setddl(string workshop)
    {
        CRUD.Setdll(ddlWorkshop, "workshop");
        //ddlWorkshop.SelectedIndex = 0;
        ddlWorkshop.ClearSelection();
        ddlWorkshop.Items.FindByValue(workshop).Selected = true;
        ddlEqp.ClearSelection();
        CRUD.SetEqpDDL(ddlEqp, ddlWorkshop.SelectedValue, lblWorksiteID.Text);
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        string originalLot = "";
        //UV成型改为分批 注释检查是否打印代码 modify by lei.xue on 2017-3-27======================================
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

        ViewState["originalLot"] = txtLot.Text;//originalLot
        originalLot = txtLot.Text;
        //查询是否可以过站
        string result = CRUD.QueryStationOfLot(lblWorksiteID.Text, originalLot);
        if (result != "success")
        {
            JScript.Alert(result, this);
            txtLot.Text = "";
            return;
        }

        DataTable lotDt = CRUD.GetLotBasisInfo(originalLot);
        string workshop = lotDt.Rows[0]["workshopID"].ToString();
        //保存批次号lotbasis信息 modify by lei.xue on 2017-2-20
        ViewState["lotDt"] = lotDt;

        setddl(workshop);

        string WO = lotDt.Rows[0]["workorder"].ToString();
        ViewState["WO"] = WO;
        #region 批次流程

        //查询批次流程
        CRUD.setLabelProcess(lblLotprocess, lblCurrnentWorksite, lblEndProcess, originalLot, lblWorksiteID.Text);

        #endregion

        ////查询工单中的长、宽
        //dt.Clear();
        //dt = CreateLot.QueryWorkorderIno(WO);
        //txtPreLength.Text = dt.Rows[0]["mouldlength"].ToString();
        //txtPreWidth.Text = dt.Rows[0]["mouldwidth"].ToString();
        //查询前站的长宽
        //批次已过站点

        //UV成型分批,注释获取母批为UV成型条码的逻辑 modify by lei.xue on 2017-3-28====================================================
        //查询母批的长度宽度及其剩余量
        //if (check != "fail")// 母批为UV成型的条码 
        //{
        //    FilmCRUD.GetPreLengthAndWidth(txtPreLength, txtPreWidth, originalLot, lblWorksiteID.Text, WO, "");
        //}
        //else
        //{
        //    //母批为贴膜的条码
        //    txtPreLength.Text = lotDt.Rows[0]["mouldlength"].ToString();
        //    txtPreWidth.Text = lotDt.Rows[0]["mouldwidth"].ToString();
        //}
        txtPreLength.Text = lotDt.Rows[0]["mouldlength"].ToString();
        txtPreWidth.Text = lotDt.Rows[0]["mouldwidth"].ToString();
        txtRestWidth.Text = lotDt.Rows[0]["restwidth"].ToString();

        //生成条码
        //LabelInfo(ddlEqp.SelectedValue.ToString().Substring(0, 3));
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        //插入basis表 ， 更新母批剩余数量 ，子批flowidno为当点站
        LotBasisDatalist dl = new LotBasisDatalist();
        DataTable dt = (DataTable)ViewState["lotDt"];
        dl.flowid = dt.Rows[0]["flowid"].ToString();
        dl.workshopid = ddlWorkshop.SelectedValue;
        dl.lottype = "Film";
        dl.status = "Active";
        dl.createuser = System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString();
        dl.currentflowidno = (Convert.ToInt32(dt.Rows[0]["flowidno"].ToString()) + 1).ToString(); //流程编号加1
        dl.factoryid = "";
        dl.workorder = ViewState["WO"].ToString();
        dl.reworkorder = "";
        dl.lotid = txtLabelInfo.Text;
        dl.lotcount = dt.Rows[0]["lotcount"].ToString();
        dl.ProcessComplete = "N";
        //dl.UVCompleteLotid = txtLot.Text;
        dl.length = txtPreLength.Text;
        dl.restlength = txtPreLength.Text;
        dl.width = txtSplitWidth.Text;
        dl.restwidth = txtSplitWidth.Text;
        dl.Filmlevel = "A";
        dl.eqpid = ddlEqp.SelectedValue;
        //=====================增加有效幅宽 add by lei.xue on 2017-5-24=================================
        dl.validwidth = txtSplitWidth.Text;
        string result = CreateMouldLot.InsertLot(dl);
        if (result != "success")
        {
            JScript.Alert(result, this);
            return;
        }
        //插入分批记录到分批表
        dl.sublotid = txtLabelInfo.Text;
        dl.lotid = txtLot.Text;
        string resultsplit = PasteFilm.InsertSplitLot(dl);

        //更新母批剩余数量
        Decimal rest = Convert.ToDecimal(txtRestWidth.Text) - Convert.ToDecimal(txtSplitWidth.Text);
        string strRest = PasteFilm.UpdateParentQty(ViewState["originalLot"].ToString(), rest.ToString(), "Width");
        if (strRest != "success")
        {
            JScript.Alert("更新母批剩余数量失败！", this);
            return;
        }

        if (result != "success" || resultsplit != "success")
        {
            JScript.Alert("创建分批条码失败！", this);
            return;
        }
        //子批过站记录 add by lei.xue on 2017-4-26=========================================
        string strWipinfo = Subsection.FilmCheckOut(txtLabelInfo.Text, ddlEqp.SelectedValue, ddlWorkshop.SelectedValue, lblWorksiteID.Text, System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString());
        if (strWipinfo == "fail")
        {
            JScript.Alert("子批过站记录失败！", this);
            return;
        }

        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>PrintLabel('" + txtLabelInfo.Text + "','../Product/Subsection.aspx');</script>");
        //JScript.Alert("创建贴膜条码成功！", this);
    }
    protected void btnSplitEnter_Click(object sender, EventArgs e)
    {
        string sublot = "";


        if (txtLot.Text.Contains("-"))
        {
            sublot = txtLot.Text + "-" + txtSplitLocation.Text;
        }
        else
        {
            sublot = txtLot.Text + "-" + "00" + "-" + txtSplitLocation.Text;
        }

        if (Subsection.ExistSubsectionLotid(sublot) == "fail")
        {
            txtLabelInfo.Text = sublot;
        }
        else
        {
            JScript.Alert("子批已经存在，请重新输入", this);
        }

    }
}