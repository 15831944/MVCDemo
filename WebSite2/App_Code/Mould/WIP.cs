using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// WIP 的摘要说明
/// </summary>
public class WIP
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public WIP()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string WIPCheckOut(string lot, string labellot, string eqp, string workshopid, string worksiteid, string userid)
    {
        string type = "";
        string sql = "";
        string ColumnName="";
        type = labellot.Substring(3, 1).ToString();

        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        if (type == "Z")
        {
            ColumnName = "carvelotid";
        }
        else
        {
            ColumnName = "outwardlotid";
        }
        sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount,"+ColumnName+")"
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckOut'," + lotUseQuantity + ",'" + labellot + "');";

        //更新checkOut 时间
        sql = sql + "update tlotbasis set checkouttime = now(),flowidno = flowidno+1," + ColumnName + " = '" + labellot + "' where lotid = '" + lot + "';";

        ////插入镀层材料
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','DCMaterial','" + DCMaterial + "','" + userid + "',now());";
        ////插入镀层厚度
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //  + " values('" + lotserial + "','" + worksiteid + "','DCThinkness','" + DCThinkness + "','" + userid + "',now());";

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


    public static string rework(string FromWorsiteID, string ToWorksiteID, string lot, string user, string flowidno)
    {
        string sql = "insert into jh_mes.treworklog(lotid,createtime,createuser,fromworksiteid,toworksiteid)" +
                     " values('" + lot + "',now(),'" + user + "','" + FromWorsiteID + "','" + ToWorksiteID + "');";

        //更新返工站点
        sql = sql + "update jh_mes.tlotbasis set flowidno = " + flowidno + " where lotid  = '" + lot + "' ;";

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