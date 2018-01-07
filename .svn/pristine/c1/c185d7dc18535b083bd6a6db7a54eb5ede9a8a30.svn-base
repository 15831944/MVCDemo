using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pub;
using System.Data.Common;

public partial class Warehouse_EditShipment : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = null;
            //CommonClass.isAllow(User.Identity.Name, this, "库存管理");
            ViewState["dt"] = dt; 
            //Databind();
            string ShipmentID = Request.QueryString["id"].ToString();
            ViewState["shipmentid"] = ShipmentID;
            Databind(ShipmentID);
        }
    }
   /// <summary>
   /// 添加批次号在出库单中
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        string result = "";
        if (txtLotid.Text == "")
        {
            JScript.Alert("请输入批次号", this);
            return;
        }
        DataTable dt = (DataTable)ViewState["dt"];
        if (dt.Rows.Count == 0)
        {
            return;
        }
        using (DbDataReader reader = EditShipment.QueryLotInfo(txtLotid.Text))
        {
            if (reader.Read())
            {
                dt = (DataTable)ViewState["dt"];

                //add by lei.xue on 2017-7-18 批次是否已经在列表中
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["lotid"].ToString() == txtLotid.Text)
                    {
                        JScript.Alert("批次已存在于列表中", this);
                        return;
                    }
                }

                //是否入库
                if (reader["warehouse"].ToString() != "Y")
                {
                    JScript.Alert("批次尚未入库", this);
                    return;
                }
                //是否出货
                if (reader["shipment"].ToString() == "Y")
                {
                    JScript.Alert("批次已经出货", this);
                    return;
                }
                if (reader["tempshipmenttime"].ToString() != "")
                {
                    JScript.Alert("批次号已经预出库！", this);
                    return;
                }

                result = Shipment.InsertShipmentInfo(ViewState["shipmentid"].ToString()
                                    , txtLotid.Text
                                    , System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString());
                if (result == "fail")
                {
                    JScript.Alert("添加出错！", this);
                    return;
                }

                DataRow dtRow = dt.NewRow();
                dtRow["shipmentID"] = ViewState["shipmentid"].ToString();
                dtRow["pinmin"] = reader["pinmin"].ToString();
                dtRow["lotid"] = reader["lotid"].ToString();
                dtRow["type"] = reader["type"].ToString();
                dtRow["validwidth"] = reader["validwidth"].ToString();
                dtRow["validlength"] = reader["validlength"].ToString();
                dtRow["tempshipmenttime"] = System.DateTime.Now.ToString();
                dt.Rows.Add(dtRow);
                grd.DataSource = dt;
                grd.DataBind();
                
            }
            else
            {
                ////JScript.Alert("未找到条码信息", this);
                //JScript.Alert("批次未入库", this);
                //return;
            }
        }
    }
    private void Databind(string id)
    {
        DataTable dt = EditShipment.QueryData(id);
        ViewState["dt"] = dt;
        grd.DataSource = dt;
        grd.DataBind();
        //Nmtree.MergeGridViewCell.MergeRow(grd,0,7);
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string result = "";
        string shipmentid="";
        for (int i = 0; i <= grd.Rows.Count - 1; i++)
        {
            CheckBox cbx = (CheckBox)grd.Rows[i].FindControl("cbx");
            if (cbx.Checked == true)
            {
                //result = ManageColor.DeleteColor(UserGrd.Rows[i].Cells[1].Text, UserGrd.Rows[i].Cells[2].Text);
                result = ShipmentManage.DelShipmentInfo(grd.Rows[i].Cells[1].Text,grd.Rows[i].Cells[3].Text);//Userdata.DelUser(grd.Rows[i].Cells[1].Text);
                if (result !="success")
                {
                    JScript.Alert("删除批次号失败！", this);
                }
                shipmentid = grd.Rows[i].Cells[1].Text;
            }
        }
        if (result =="success")
        {
            JScript.Alert("批次删除成功！", this);
            Databind(shipmentid);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dt"];
        if (dt.Rows.Count == 0)
        {
            return;
        }
        string result= ShipmentManage.ConfirmShipment(ViewState["shipmentid"].ToString());
        if (result == "success")
        {
            JScript.AlertAndRedirect("最终出库成功", "ShipmentManage.aspx", this);
        }
        else
        {
            JScript.Alert("出库失败", this);
        }
    }
}