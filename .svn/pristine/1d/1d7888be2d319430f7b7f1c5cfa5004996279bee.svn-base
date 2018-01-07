using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// FilmQuery 的摘要说明
/// </summary>
public class FilmQuery
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public FilmQuery()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static DataTable QueryData(string lot)
    {
        string sql = "call prGetLotHistory('" + lot + "');";
        return dbhelp.ExecuteDataTable(sql, null);
    }
}