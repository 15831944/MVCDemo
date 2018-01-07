using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// EditShipment 的摘要说明
/// </summary>
public class EditShipment
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public EditShipment()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static DataTable QueryData(string shipmentID)
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
        + "  WHERE 1=1 and shipment is null ";
        //============出库单号======================================
        if (shipmentID != "")
        {
            sql += " and a.shipmentID = '" + shipmentID + "' ";
        }

        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static DbDataReader QueryLotInfo(string lotid)
    {
        string sql = "   select  (select warehousecode from twarehousecodeconfig where ID = a.Warehousecode) warehousecode "
                   + " ,a.PinMin "
                   + " ,a.lotid "
                   + " ,a.Type "
                   + " ,ifnull(b.ValidWidth,0) validwidth "
                   + " ,ifnull(b.ValidLength,0) validlength "
                   + " ,b.warehouse "
                   + " ,b.shipment "
                   + " ,ifnull(c.tempshipmenttime,'') tempshipmenttime"
                   + " from twarehouseinfo a "
                   + " inner JOIN "
                   + " tlotbasis b "
                   + " on a.lotid = b.lotid "
                   + " left join tshipmentinfo c "
                   + " on b.lotid = c.lotid "
                   + " where a.lotid='" + lotid + "'";
        return dbhelp.ExecuteReader(sql, null);
    }
}