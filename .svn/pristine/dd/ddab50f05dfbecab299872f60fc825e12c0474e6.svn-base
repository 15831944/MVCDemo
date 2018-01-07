using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;
/// <summary>
/// MouldLotHistory 的摘要说明
/// </summary>
public class MouldLotHistory
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public MouldLotHistory()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static DataTable QueryData(string lot)
    {
        string sql = " call prGetMouldHistory('"+lot+"');";
        return dbhelp.ExecuteDataTable(sql, null);
    }
}