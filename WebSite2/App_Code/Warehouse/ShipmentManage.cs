using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// ShipmentManage 的摘要说明
/// </summary>
public class ShipmentManage
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public ShipmentManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static DataTable QueryData(string workshopid, string shipmentid, string bt, string et, string lotid, string pinmin, string type)
    {
        string sql = "  SELECT a.shipmentid,a.lotid "
        + "  ,a.workshopid"
        + "  ,a.shipmentuser "
        + "  ,a.tempshipmenttime "
        + "  ,b.pinmin "
        + "  ,b.length validlength"
        + "  ,b.width validwidth"
        + "  ,b.type "
            //+ "  ,ifnull(b.shipment,'N') shipment "
            //+ "  ,shipmentID "
        + "  FROM jh_mes.tshipmentinfo a "
        + "  INNER JOIN jh_mes.twarehouseinfo b ON a.lotid = b.lotid "
        + "  WHERE 1=1 and shipment is null  ";
        //============出库单号======================================
        if (shipmentid != "")
        {
            sql += " and a.shipmentID = '" + shipmentid + "' ";
        }

        if (workshopid != "")
        {
            sql += " and b.workshopid = '" + workshopid + "' ";
        }
        if (bt != "" && et != "")
        {
            sql += " and a.tempshipmenttime between '" + bt + "' and '" + et + "' ";
        }
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
        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static string DelShipmentInfo(string ShipmentID, string lotid)
    {
        string sql = "delete from jh_mes.tshipmentinfo where shipmentid = '"+ShipmentID+"' and lotid = '"+lotid+"' ;";
        int result = dbhelp.ExecuteNonQuery(sql, null);
        if (result > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

    public static string ConfirmShipment(string shipmentid)
    {
        string sql = "update jh_mes.tshipmentinfo set shipment = 'Y',shipmenttime = now() where shipmentid = '" + shipmentid + "';"
                   + " update jh_mes.tlotbasis set shipment = 'Y' where lotid in (select lotid from tshipmentinfo where shipmentid = '"+shipmentid+"'); ";
        int result = dbhelp.ExecuteNonQuery(sql, null);
        if (result > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

    public static DataTable FinalShipmentQuery(string workshopid, string shipmentid, string bt, string et, string lotid, string pinmin, string type)
    {
        string sql = "  SELECT a.shipmentid,a.lotid "
        + "  ,a.workshopid"
        + "  ,a.shipmentuser "
        + "  ,a.tempshipmenttime "
        + "  ,b.pinmin "
        + "  ,b.length validlength"
        + "  ,b.width validwidth"
        + "  ,b.type "
            //+ "  ,ifnull(b.shipment,'N') shipment "
            //+ "  ,shipmentID "
        + "  FROM jh_mes.tshipmentinfo a "
        + "  INNER JOIN jh_mes.twarehouseinfo b ON a.lotid = b.lotid "
        + "  WHERE 1=1 and shipment='Y' ";
        //============出库单号======================================
        if (shipmentid != "")
        {
            sql += " and a.shipmentID = '" + shipmentid + "' ";
        }

        if (workshopid != "")
        {
            sql += " and b.workshopid = '" + workshopid + "' ";
        }
        if (bt != "" && et != "")
        {
            sql += " and a.shipmenttime between '" + bt + "' and '" + et + "' ";
        }
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
        return dbhelp.ExecuteDataTable(sql, null);
    }

}