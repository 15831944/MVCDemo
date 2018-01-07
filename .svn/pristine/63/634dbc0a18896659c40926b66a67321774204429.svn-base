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
public class OnhandInventory
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public OnhandInventory()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataTable QueryData(string warehousecode, string type, string lotid)
    {
        string sql = " SELECT ( "
                   + "   		SELECT warehousecode "
                   + "   		FROM twarehousecodeconfig "
                   + "   		WHERE id = b.warehousecode "
                   + "   		) warehousecode "
                   + "   	,a.lotid "
                   + "   	,a.validlength "
                   + "   	,a.validwidth "
                   + "   	,a.ValidLength * a.ValidWidth / 1000 area "
                   + "   	,b.pinmin "
                   + "   	,b.type "
                   + "   	,b.warehousetime "
                   + "   FROM tlotbasis a "
                   + "   INNER JOIN twarehouseinfo b ON a.lotid = b.lotid "
                   + "   WHERE a.warehouse = 'Y' "
                   + "   	AND shipment IS NULL         ";
        if (warehousecode!="All")
        {
            sql += " and b.warehousecode='"+warehousecode+"' ";
        }
        if (type != "")
        {
            sql += " and b.type='"+type+"' ";
        }
        if (lotid != "")
        {
            sql += " and a.lotid = '"+lotid+"'";
        }
        return dbhelp.ExecuteDataTable(sql, null);
    }



    public static void SetWarehouseCodedll(DropDownList ddl)
    {
        ddl.AppendDataBoundItems = false;
        string sql = "select  id paraid,warehousecode paraname from jh_mes.twarehousecodeconfig  ; ";
        ddl.Items.Add(new ListItem("All", "All"));
        using (DbDataReader reader = dbhelp.ExecuteReader(sql, null))
        {
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader["paraname"].ToString(), reader["paraid"].ToString()));
            }
            ddl.DataBind();
        }
    }

}