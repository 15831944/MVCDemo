using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Shipment 的摘要说明
/// </summary>
public class Shipment
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public Shipment()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static string ShipmentInfo(string lotid,string shipmentID )
    {
        string SQL = "update jh_mes.twarehouseinfo set shipmentid = '"+shipmentID+"' where lotid = '"+lotid+"' ;";
        //更新批次出货状态
        SQL += " update jh_mes.tlotbasis set shipment='Y' where lotid = '" + lotid + "'; ";
        int result = dbhelp.ExecuteNonQuery(SQL, null);
        if (result > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

    #region 查询出货单号的流水码 按日递增
    public static string QueryShipmentIDByDay()
    {
        string sql = "select ifnull(max(right(shipmentid,3)),0) from twarehouseinfo where   date(warehousetime) =  curdate() ";
        object ob = dbhelp.ExecuteScalar(sql, null);
        if (ob != null)
        {
            return ob.ToString();
        }
        else
        {
            return "fail";
        }
    }
    #endregion

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
                   + " from twarehouseinfo a "
                   + " inner JOIN "
                   + " tlotbasis b "
                   + " on a.lotid = b.lotid "
                   + " where a.lotid='" + lotid + "'";
        return dbhelp.ExecuteReader(sql, null);
    }

    public static string InsertShipmentInfo(string shipmentid,
                                         string lotid,
                                         string user
                                          )//string shipmentnotice  
    {
        string sql = " insert into jh_mes.tshipmentinfo(shipmentid,lotid,shipmentuser,tempshipmenttime)"//,shipmentnotice
                   + " values('" + shipmentid
                   + "','" + lotid
                   + "','" + user
                   + "',now());";//,'"+shipmentnotice+"');";

        
        int res = dbhelp.ExecuteNonQuery(sql, null);
        if (res > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }

    }


    public static string ExistShipmentID(string shipmentid)
    {
        string sql = "select shipmentid from tshipmentinfo where shipmentid = '" + shipmentid + "';";
        object ob = dbhelp.ExecuteScalar(sql, null);
        if (ob != null)
        {
            return "success";
        }
        else
        {
            return "fail";
        }

    }

    public static void setShipmentNoticeDDL(DropDownList ddl)
    {
        string sql = "select distinct shipmentnotice from terpshipmentnoticeinfo where shipmentstatus is null ;";

        ddl.AppendDataBoundItems = true;
        ddl.Items.Clear();
        //string sql = "select  warehousecode,workshopid,workordertype from jh_mes.twarehousecodeconfig where workshopid = '" + workshopid + "' ; ";
        ddl.Items.Add(new ListItem("请选择单号", "请选择单号"));
        using (DbDataReader reader = dbhelp.ExecuteReader(sql, null))
        {
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader["shipmentnotice"].ToString(), reader["shipmentnotice"].ToString()));
            }
            ddl.DataBind();
        }

    }

    public static DataTable QueryShipmentNoticeData(string shipmentnotice)
    {
        string sql = " select distinct type,shipmentqty from  terpshipmentnoticeinfo where shipmentnotice = '"+shipmentnotice+"' ;";
        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static string UpdateShipmentNoticeStatus(string status,string shipmentnotice)
    {
        string sql = " update terpshipmentnoticeinfo set shipmentstatus = '"+status+"' where shipmentnotice = '" + shipmentnotice + "' ";
        object ob = dbhelp.ExecuteNonQuery(sql, null);
        if (ob != null)
        {
            return "success";
        }
        else
        {
            return "fail";
        }

    }

    

}