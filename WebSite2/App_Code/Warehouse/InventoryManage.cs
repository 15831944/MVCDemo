using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;

/// <summary>
/// InventoryManage 的摘要说明
/// </summary>
public class InventoryManage
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public InventoryManage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataTable QueryData(string workshopid, string warehousecode, string warehousebt, string warehouseet,string lotid, string pinmin, string type,string warehouseid)
    {
        string sql = "  SELECT a.warehousecode,a.warehouseid "
        + "  ,a.workshopid"
        + "  ,a.lotid "
        + "  ,a.warehousetime "
        + "  ,a.shipmenttime "
        + "  ,a.pinmin "
        + "  ,b.validlength length "
        + "  ,b.validwidth width "
        + "  ,a.type "
        //+ "  ,ifnull(b.shipment,'N') shipment "
        //+ "  ,shipmentID "
        + "  FROM jh_mes.twarehouseinfo a "
        + "  INNER JOIN jh_mes.tlotbasis b ON a.lotid = b.lotid "
        + "  WHERE 1=1 ";
        //============入库单号======================================
        if (warehouseid != "")
        {
            sql += " and a.warehouseid = '" + warehouseid + "' ";
        }
        //============库位信息======================================
        if (warehousecode != "ALL")
        {
            sql += " and a.warehousecode = '" + warehousecode + "' ";
        }
        if (workshopid != "")
        {
            sql += " and a.workshopid = '" + workshopid + "' ";
        }
        if (warehousebt != "" && warehouseet != "")
        {
            sql += " and a.warehousetime between '" + warehousebt + "' and '" + warehouseet + "' ";
        }
        //if (shipmentbt != "" && shipmentet != "")
        //{
        //    sql += " and a.shipmenttime between '" + shipmentbt + "' and '" + shipmentet + "' ";
        //}
        if (pinmin != "")
        {
            sql += " and a.pinmin = '" + pinmin + "'";
        }
        if (lotid != "")
        {
            sql += " and a.lotid ='" + lotid + "'";
        }
        if (type != "")
        {
            sql += " and a.type = '" + type + "'";
        }
        //if (status != "")
        //{
        //    if (status == "Y")
        //    {
        //        sql += " and b.shipment = 'Y'";
        //    }
        //    else
        //    {
        //        sql += " and b.shipment <> 'Y'";
        //    }
        //}
        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static void Setdll(DropDownList ddl, string workshopid)
    {
        ddl.AppendDataBoundItems = true;
        ddl.Items.Clear();
        string sql = "select  warehousecode,workshopid,workordertype from jh_mes.twarehousecodeconfig where workshopid = '" + workshopid + "' ; ";
        ddl.Items.Add(new ListItem("ALL", "ALL"));
        using (DbDataReader reader = dbhelp.ExecuteReader(sql, null))
        {
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader["warehousecode"].ToString(), reader["warehousecode"].ToString()));
            }
            ddl.DataBind();
        }
    }

}