using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Web.UI.WebControls;
/// <summary>
/// MouldQuery 的摘要说明
/// </summary>
public class MouldQuery
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public MouldQuery()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataTable MouldDataHistory(string bt, string et, string eqpid,
     string workshopid, string mouldlotid,
     string carvelotid, string outwardlotid,
     string worksiteid )
    {
        string sql = " SELECT a.lotid "
        + "   ,a.carvelotid "
        + "   ,a.outwardlotid "
        + "   ,a.eqpid "
        + "   ,a.type "
        + "   ,a.createtime "
        + "   ,(select paraname from tparaconfig where paratype = 'paratype' and paraid= b.paratype) paratype "
        + "   ,b.paraid "
        + "   ,a.workshopid "
        + "   ,(select paraname from tparaconfig where paraid = a.worksiteid) worksiteid "      
        + "   ,a.lotcount "
        + " FROM twiplotlog a inner join tlotbasis c on a.lotid = c.lotid "
        + " left JOIN twiplotdetail b ON a.lotserial = b.lotserial "
        + " where c.lottype='Mould' and a.createtime between  '" + bt + "' and '" + et + "' ";

        if (eqpid != "")
        {
            sql += " and a.eqpid = '" + eqpid + "' ";
        }

        if (workshopid!= "")
        {
            sql += " and a.workshopid = '"+workshopid+"' ";
        }

        if (mouldlotid != "")
        {
            sql += " and a.lotid = '" + mouldlotid + "' ";
        }

        if (carvelotid != "")
        {
            sql += " and a.carvelotid = '" + carvelotid + "' ";
        }

        if (outwardlotid != "")
        {
            sql += " and a.outwardlotid = '" + outwardlotid + "' ";
        }

        if (worksiteid != "")
        {
            sql += " and a.worksiteid = '" + worksiteid + "' ";
        }

        sql += " ORDER BY a.createtime ";

        return dbhelp.ExecuteDataTable(sql, null);

        
    }

    public static void SetEqpDDL(DropDownList ddl, string workshop, string worksite)
    {
        ddl.AppendDataBoundItems = true;
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("All", ""));
        string sql = "select  eqpid,eqpname from jh_mes.teqpinfo where workshopid = '" + workshop + "' and worksiteid = '" + worksite + "' ; ";
        using (DbDataReader reader = dbhelp.ExecuteReader(sql, null))
        {
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader["eqpname"].ToString(), reader["eqpid"].ToString()));
            }
            ddl.DataBind();
        }
    }
  

}