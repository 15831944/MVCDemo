using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.Common;

/// <summary>
/// Configpara 的摘要说明
/// </summary>
public class Configpara
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public Configpara()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static void Setdll(DropDownList ddl)
    {
        ddl.AppendDataBoundItems = true;
        string sql = "select  paraname,paraid from jh_mes.tparaconfig where paratype = 'paratype' or paratype='paratypename'; ";
        using (DbDataReader reader = dbhelp.ExecuteReader(sql, null))
        {
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader["paraname"].ToString(), reader["paraid"].ToString()));
            }
            ddl.DataBind();
        }
    }

    public static DataTable Exist(string type,string paraid)
    {
        string sql = "select paratype, paraid,paraname,createtime,createuser From jh_mes.tparaconfig where 1=1 ";
        if (type != "All")
        {
            sql += " and paratype = '" + type + "' and paraid = '"+paraid+"'";
        }

        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static DataTable Query(string type)
    {
        string sql = "select paratype, paraid,paraname,createtime,createuser From jh_mes.tparaconfig where 1=1 ";
        if (type != "All")
        {
            sql += " and paratype = '" + type + "' ";
        }

        return dbhelp.ExecuteDataTable(sql, null);
    }



    //增加PECVD类型 modify by lei.xue on 2016-12-5
    public static string Add(string paratype,string paraid, string paraname, string user)
    {
        string sql = "INSERT INTO jh_mes.tparaconfig VALUES ('"+paratype+"', '"+paraid+"', '"+paraname+"',sysdate(), '"+user+"');";
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

    public static string Delete(string paratype, string paraid)
    {
        string sql = "delete from jh_mes.tparaconfig where paratype = '"+paratype+"' and paraid = '"+paraid+"' ";
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
}