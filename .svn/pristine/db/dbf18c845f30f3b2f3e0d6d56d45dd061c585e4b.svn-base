using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// WOManage 的摘要说明
/// </summary>
public class WOManage
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public WOManage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataTable Retrieve(string bt, string et)
    {
        string sql = @" select workorderid,
                        bomid
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
                        from jh_mes.tworkorderinfo where createtime >'" + bt + "' and createtime <'" + et + "'; ";
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

    public static string ChangeWOStatus(string wo, string status)
    {
        string sql = "update jh_mes.tworkorderinfo set status='" + status + "' where workorderid = '" + wo + "' ";
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