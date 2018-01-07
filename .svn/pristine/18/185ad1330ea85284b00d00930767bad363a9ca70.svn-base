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
///GroupManage 的摘要说明
/// </summary>
public class GroupManage
{

    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public GroupManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    //获取群组信息
    public  static DbDataReader  Groupinfo()
    {
        string sql = "select * from tgroup ";
         DbDataReader reader = dbhelp.ExecuteReader(sql, null);
         return reader;
    }

    public static DataTable Query(string sql)
    {
        //string sql = "select * from tgroup";
        return dbhelp.ExecuteDataTable(sql, null);
 
    }

    //获取所有权限
    public static DbDataReader Premissioninfo()
    {
        string sql = "select * from tpower";
        DbDataReader reader = dbhelp.ExecuteReader(sql, null);
        return reader;

    }

    //获取群组信息
    public static DbDataReader getGroupinfo(string id )
    {
        string sql = "select * from tgroup where id ='"+id+"'";
        return dbhelp.ExecuteReader(sql, null);
    }

    //获取群组权限
    public static DataTable getGroupPermission(string groupid)
    {
        string sql = "select c.id,c.powername from tgroup as a " +
                     "inner join tgrouppower as b on a.id = b.group_id " +
                     "inner join tpower as c on c.id = b.power_id " +
                     "where a.id = '" + groupid + "'";
        return dbhelp.ExecuteDataTable(sql, null);
    }

    //获取群组成员
    public static DataTable getGroupUser(string groupid)
    {
        string sql = "select c.id ,c.name ,c.workshop from tgroup as a " +
                     "inner join tusergroup as b on a.id = b.group_id " +
                     "inner join tuser as c on c.id = b.user_id " +
                     "where a.id = '" + groupid + "'";
        return dbhelp.ExecuteDataTable(sql, null);


    }

    //添加权限
    public static int addPermission(string groupid ,string powerid )
    {
        string sql ="insert tgrouppower select '"+ groupid +"','"+ powerid+"'";
        return dbhelp.ExecuteNonQuery(sql,null);

    }

    //删除权限
    public static int delPermission(string groupid)
    {
        string sql = "delete from tgrouppower where group_id = '"+groupid+"'";
        return dbhelp.ExecuteNonQuery(sql, null);
    }
}
