﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using Pub;

public partial class Warehouse_Warehouse : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonClass.isAllow(User.Identity.Name, this, "成品入库");
            txtLot.Attributes.Add("onkeypress", "EnterTextBox()");
            Warehouse.SetWarehouseCodedll(ddlWarehouseCode);
            CreateTable();

        }
    }

    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        //JScript.Alert("test！", this);
        //入库单号是否存在
        if (Warehouse.ExistWarehouseID(txtInventoryNo.Text.Trim().ToString()) == "success")
        {
            JScript.Alert("输入的入库单号已经存在", this);
            return;
        }

        //for (int i = 0; i < grd.Rows.Count; i++)
        //{
        //    DropDownList ddltype = (DropDownList)grd.Rows[i].FindControl("ddlType");
        //    string type = ddltype.SelectedValue;
        //}
        DropDownList ddlType;
        string result = "";
        DataTable dt = (DataTable)ViewState["dt"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //判断批次是否已入库 modify by lei.xue on 2017-8-22
                using (DbDataReader reader = Warehouse.QueryLotInfo(dt.Rows[i]["lotid"].ToString()))
                {
                    if (reader.Read())
                    {
                        //是否入库
                        if (reader["warehouse"].ToString() == "Y")
                        {
                            JScript.Alert("批次已经入库", this);
                            return;
                        }
                    }
                }
                //modify by lei.xue on 2017-9-20 型号取下拉选项 
                ddlType = (DropDownList)grd.Rows[i].FindControl("ddlType");
                result = Warehouse.InsertWarehouseInfo(txtInventoryNo.Text,
                                                       dt.Rows[i]["lotid"].ToString(),
                                                       dt.Rows[i]["warehousecode"].ToString(),
                                                       dt.Rows[i]["warehousetype"].ToString(),
                                                       dt.Rows[i]["workorderid"].ToString(),
                                                       dt.Rows[i]["workordertype"].ToString(),
                                                       dt.Rows[i]["workshopid"].ToString(),
                                                       System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(),
                                                       dt.Rows[i]["pinmin"].ToString(),
                                                       dt.Rows[i]["thinkness"].ToString(),
                                                       dt.Rows[i]["length"].ToString(),
                                                       dt.Rows[i]["width"].ToString(),
                                                       ddlType.SelectedItem.Text, //dt.Rows[i]["type"].ToString(),
                                                       dt.Rows[i]["pettype"].ToString()
                                                       );
                if (result == "fail")
                {
                    JScript.Alert("入库出错！", this);
                    return;
                }
            }
            //erp接口 add by lei.xue on 2017-9-21
            result = Warehouse.InsertDataToERP((DataTable)ViewState["dt"], grd, System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString(), txtInventoryNo.Text);
            if (result == "fail")
            {
                JScript.AlertAndRedirect("ERP入库接口出错！", "../Warehouse/Warehouse.aspx", this);
            }

            JScript.AlertAndRedirect("MES入库成功！","../Warehouse/Warehouse.aspx", this);
            
        }
        else
        {
            JScript.Alert("请刷入条码！", this);
        }

    }


    private void CreateTable()
    {
        //创建列
        dt.Columns.Clear();
        dt.Rows.Clear();
        DataColumn dtCol = new DataColumn("lotid", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("workorderid", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("workordertype", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("warehousecode", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("warehousetype", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("workshopid", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("pinmin", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("thinkness", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("length", typeof(int));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("width", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("type", typeof(string));
        dt.Columns.Add(dtCol);
        dtCol = new DataColumn("pettype", typeof(string));
        dt.Columns.Add(dtCol);
        ViewState["dt"] = dt;
    }


    private void databind()
    {
        this.grd.DataSource = (DataTable)ViewState["dt"];
        this.grd.DataBind();
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        //JScript.Alert("未找到条码信息", this);
        using (DbDataReader reader = Warehouse.QueryLotInfo(txtLot.Text))
        {
            if (reader.Read())
            {
                dt =(DataTable)ViewState["dt"];
                //add by lei.xue on 2017-7-18 批次是否已经在列表中
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["lotid"].ToString() == txtLot.Text)
                    {
                        JScript.Alert("批次已存在于列表中", this);
                        return;
                    }
                }

                //是否入库
                if (reader["warehouse"].ToString() == "Y")
                {
                    JScript.Alert("批次已经入库", this);
                    return;
                }
                //是否过包装站
                if (reader["worksiteid"].ToString() != "M60")
                {
                    JScript.Alert("批次未包装", this);
                    return;
                }
                DataRow dtRow = dt.NewRow();
                dtRow["lotid"] = reader["lotid"].ToString();
                dtRow["workorderid"] = reader["workorderid"].ToString();
                dtRow["workordertype"] = reader["workordertype"].ToString();
                dtRow["warehousecode"] = ddlWarehouseCode.SelectedValue;
                //dtRow["warehousetype"] = reader["warehousetype"].ToString();
                dtRow["workshopid"] = reader["workshopid"].ToString();
                dtRow["pinmin"] = reader["pinmin"].ToString();
                dtRow["thinkness"] = reader["thinkness"].ToString();
                dtRow["length"] = Convert.ToInt32(reader["length"]);
                dtRow["width"] = reader["width"].ToString();
                dtRow["type"] = reader["type"].ToString();
                dtRow["pettype"] = reader["pettype"].ToString();
                dt.Rows.Add(dtRow);
                ViewState["dt"] = dt;
                databind();
                txtQty.Text = (Convert.ToInt32(txtQty.Text) + 1).ToString();
                txtLot.Text = "";
                txtLot.Focus();
            }
            else
            {
                JScript.Alert("未找到条码信息", this);
                return;
            }
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        for (int i = grd.Rows.Count - 1; i >= 0; i--)
        {
            CheckBox cbx = (CheckBox)grd.Rows[i].FindControl("cbx");
            if (cbx.Checked)
            {
                ((DataTable)ViewState["dt"]).Rows.RemoveAt(i);
                if (Convert.ToInt32(txtQty.Text) > 0)
                {
                    txtQty.Text = (Convert.ToInt32(txtQty.Text) - 1).ToString();
                }
            }
        }
        databind();
    }

    //查询erp中工单的所有型号
    private void setTypeData(string wotype,string wo,string type,DropDownList ddl)
    {
        //从ERP中查询型号的品号
        string ERPPinHao = "";
        ERPPinHao = Warehouse.QueryPinHaoOfTypeInERP(type).Trim();

        ddl.AppendDataBoundItems = true;
        ddl.Items.Add(new ListItem(type, ERPPinHao));
        DataTable dt;
        
        if (ViewState[type] != null)
        {
            dt = (DataTable)ViewState[type];
        }
        else
        {
            dt = Warehouse.QueryWOType(wotype,wo,type);
            ViewState[type] = dt;
        }

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(dt.Rows[i]["type"].ToString().Trim(),dt.Rows[i]["TQ004"].ToString().Trim()));
            }
        }
            //while (reader.Read())
            //{           
            //    ddl.Items.Add(new ListItem(reader["type"].ToString(), reader["type"].ToString()));
            //}
            ddl.DataBind();
        
    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            DropDownList ddl =(DropDownList) e.Row.FindControl("ddlType");
            setTypeData(e.Row.Cells[3].Text.ToString(), e.Row.Cells[2].Text.ToString(), e.Row.Cells[11].Text.ToString(), ddl);

        }
    }
}