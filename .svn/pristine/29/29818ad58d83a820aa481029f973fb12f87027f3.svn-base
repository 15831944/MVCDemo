using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Common;

/// <summary>
///UserManage 的摘要说明
/// </summary>
public class UserManage
{
    static  DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.SqlServer);

	public UserManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static DataTable Query(string sql)
    {
       return  dbhelp.ExecuteDataTable(sql, null);

    }
}
