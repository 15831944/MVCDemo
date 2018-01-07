using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.Common;

/// <summary>
/// Electroplate 的摘要说明
/// </summary>
public class MouldComplete
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public MouldComplete()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		// 
	}

    public static string MouldCompleteCheckIn(string lot,string labellot, string eqp, string workshopid, string worksiteid, string userid)
    {
        string type = "";
        string sql = "";
        string ColumnName = "";
        if (labellot.Length > 3)
        {
            type = labellot.Substring(3, 1).ToString();
        }
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
                   + "values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckIn',"+lotUseQuantity+",'"+labellot+"');";

        //更新checkin 时间
        sql = sql + "update tlotbasis set checkintime = now() where lotid = '" + lot + "';";
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

    /// <summary>
    /// 成型出站
    /// 增加 恢复返工状态 modify by lei.xue on 2017-2-13
    /// </summary>
    /// <param name="lot"></param>
    /// <param name="labellot"></param>
    /// <param name="eqp"></param>
    /// <param name="workshopid"></param>
    /// <param name="worksiteid"></param>
    /// <param name="userid"></param>
    /// <returns></returns>
    public static string MouldCompleteCheckOut(string lot,string labellot, string eqp, string workshopid, string worksiteid, string userid ,string processcomplete,string rework
                                                 )
    {
        string type = "";
        string sql = "";
        string ColumnName = "";
        if (labellot.Length > 3)
        {
            type = labellot.Substring(3, 1).ToString();
        }
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
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckOut',"+lotUseQuantity+",'"+labellot+"');";

        //更新checkOut 时间
        //更新返工状态为N modify by lei.xue on 2017-2-13 
         sql = sql + "update jh_mes.tlotbasis set checkouttime = now(),flowidno = flowidno+1,rework = '"+rework+"',processcomplete = '"+processcomplete+"' where lotid = '" + lot + "';";

        //插入镀层材料
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