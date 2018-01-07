using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// WOManage 的摘要说明
/// </summary>
public class EditWO
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public EditWO()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataTable Retrieve(string wo)
    {
        string sql = @" select workorderid
                        ,bomid
                        ,flowid
                        ,workshopid
                        ,createtime
                        ,createuser
                        ,mouldpinmin
                        ,mouldthinkness
                        ,mouldlength
                        ,mouldwidth
                        ,mouldtype 
                        ,mouldpettype
                        ,workordertype
                        ,status
                        ,transfertime
                        from jh_mes.tworkorderinfo where workorderid='" + wo + "'; ";
        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static string Delete(string wo)
    {
        string sql = "delete from jh_mes.tworkorderinfo where workorderid='" + wo + "' ";
        int rs = dbhelp.ExecuteNonQuery(sql, null);
        if (rs > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

    public static string Update(string wo, string flowid,string workshop,string pinmin,string thinkness,string length,string width,string type,string pettype,string wotype )
    {
        string sql = "update jh_mes.tworkorderinfo set ";
               sql+= " flowid='" + flowid + "'";
               sql+= ",workshopid='"+workshop+"'";
               sql += ",mouldpinmin='" + pinmin + "'";
               sql += ",mouldthinkness='" + thinkness + "'";
               sql += ",mouldlength='" + length + "'";
               sql += ",mouldwidth='" + width + "'";
               sql += ",mouldtype='" + type + "'";
               sql += ",mouldpettype='" + pettype + "'";
               sql += ",workordertype='" + wotype + "'";
               sql += " where workorderid = '"+wo+"';";   
        int rs = dbhelp.ExecuteNonQuery(sql, null);
        if (rs > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }
}