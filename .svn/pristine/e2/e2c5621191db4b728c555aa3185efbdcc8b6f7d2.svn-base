using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// QCQuery 的摘要说明
/// </summary>
public class QCQuery
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public QCQuery()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static DataTable QueryData(string bt,string et,string worksiteid)
    {
        string sql = " select a.lotid,a.worksiteid," +
        " (select paraname from tparaconfig where paratype = 'worksite' and paraid = a.worksiteid ) worksitename," +
        " a.eqpid,a.createtime,a.createuser,a.result,a.MouldLevel," +
        " b.paratype,b.parasubtype,b.paraid  ,b.result subresult" +
        " from jh_mes.tqclog a LEFT JOIN jh_mes.tqcdetail b " +
        " on a.lotserial =b.lotserial " +
        " where a.createtime between '" + bt + "' and '" + et + "'";
        if (worksiteid != "")
        {
            sql += " and a.worksiteid = '" + worksiteid + "'";
        }

        return dbhelp.ExecuteDataTable(sql, null);

    }
}