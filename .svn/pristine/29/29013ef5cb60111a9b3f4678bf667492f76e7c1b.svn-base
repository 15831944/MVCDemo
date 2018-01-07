using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// CreateWorkorder 的摘要说明
/// </summary>
public class CreateWorkorder
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public CreateWorkorder()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static string ExistWO(string wo)
    {
        string sql = " select workorderid from tworkorderinfo where workorderid = '"+wo+"' ";
        object ob = dbhelp.ExecuteScalar(sql, null);
        if (ob !=null)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

    public static string CreateWO(string workorderid, string bomid, string flowid, string workshopid, string createuser, 
                                         string MouldPinMin,string MouldLength,string MouldThinkness,string MouldWidth,string MouldType,string MouldPETType,string workordertype)
    {
        string sql = "insert into jh_mes.tworkorderinfo(workorderid,bomid,flowid,workshopid,createtime,createuser,mouldpinmin,mouldthinkness,mouldlength,mouldwidth,mouldtype,mouldpettype,workordertype)"
                                             + " values('" + workorderid + "', "
                                             + " '" + bomid + "',"
                                             + " '" + flowid + "',"
                                             + " '" + workshopid + "',"
                                             + " now(),"
                                             + " '" + createuser + "',"
                                             + " '" + MouldPinMin + "',"
                                             + " '" + MouldThinkness + "',"
                                             + " '" + MouldLength + "',"
                                             + " '" + MouldWidth + "',"
                                             + " '" + MouldType + "',"
                                             + " '" + MouldPETType + "',"
                                             + " '" + workordertype + "')";
      
    
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

    public static string getWorkOrderQty(string WO)
    {
        string sql = "select ifnull(max(right(workorderid,3)),0) from jh_mes.tworkorderinfo where workorderid like '" + WO + "%'   ";
        object ob = dbhelp.ExecuteScalar(sql,null);
        if (ob != null)
        {
            return ob.ToString();
        }
        else
        {
            return "fail";
        }
    }


}