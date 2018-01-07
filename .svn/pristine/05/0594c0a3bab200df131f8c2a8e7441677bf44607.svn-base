using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data;

/// <summary>
/// ChangeLot 的摘要说明
/// </summary>
public class ChangeLot
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public ChangeLot()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static void QueryWorkSite(DropDownList ddl, string flowid)
    {
        ddl.Items.Clear();
        ddl.AppendDataBoundItems = true;
        DataTable dt = CRUD.GetWorkflowByFlowid(flowid);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dt.Rows[i]["worksitename"].ToString(), dt.Rows[i]["worksiteid"].ToString()));
        }
        ddl.DataBind();
    }
}