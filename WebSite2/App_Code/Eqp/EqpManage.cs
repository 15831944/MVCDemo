using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.Common;

/// <summary>
/// EqpManage 的摘要说明
/// </summary>
public class EqpManage
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public EqpManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static void Setdll(DropDownList ddl,string ddltype)
    {
        ddl.AppendDataBoundItems = true;
        string sql = "select  paraname,paraid from jh_mes.tparaconfig where paratype = '" + ddltype + "' ; ";
        using (DbDataReader reader = dbhelp.ExecuteReader(sql, null))
        {
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader["paraname"].ToString(), reader["paraid"].ToString()));
            }
            ddl.DataBind();
        }
    }

    public static DataTable Exist( string eqpid)
    {
        string sql = "select eqpid From jh_mes.teqpinfo where 1=1 ";
        if (eqpid != "All")
        {
            sql += " and eqpid = '" + eqpid + "' ;";
        }

        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static DataTable Query(string eqpid,string workshop,string worksite)
    {
        string sql = "select eqpid, eqpname,workshopid,worksiteid,remark,createuser,createtime,maintainuser,maintaintime,status From jh_mes.teqpinfo where 1=1 ";
        if (eqpid != "")
        {
            sql += " and eqpid = '" + eqpid + "' ";
        }
        if (workshop != "")
        {
            sql += " and workshopid = '" + workshop + "' ";
        }
        if (eqpid != "")
        {
            sql += " and worksiteid = '" + worksite + "' ";
        }

        return dbhelp.ExecuteDataTable(sql, null);
    }



    //增加PECVD类型 modify by lei.xue on 2016-12-5
    public static string Add(string eqpid, string eqpname, string worksite, string workshop,string status,string createuser,string remark)
    {
        string sql = "INSERT INTO jh_mes.teqpinfo VALUES ('" + eqpid + "', '" + workshop + "', '" + eqpname + "','"+status+"', '" + worksite + "',"+
                     "'"+remark+"','"+createuser+"',sysdate(),null,null);";
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

    public static string Delete(string eqpid)
    {
        string sql = "delete from jh_mes.teqpinfo where eqpid = '" + eqpid + "' ; ";
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

    public static string Update(string eqpid,string status,string maintainuser)
    {
        string sql = "update  jh_mes.teqpinfo set status = '"+status+"', maintainuser = '"+maintainuser+"',maintaintime = sysdate() where eqpid = '" + eqpid + "' ; ";
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