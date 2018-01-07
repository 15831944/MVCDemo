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
public class Electroplate
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public Electroplate()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		// 
	}

    public static string EletroplateCheckIn(string lot, string eqp, string workshopid,string worksiteid,string userid)
    {
        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount)"
                   + "values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckIn',"+lotUseQuantity+");";

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

    public static string ElectroplateCheckOut(string lot, string eqp, string workshopid, string worksiteid, string userid,
                                              string DCMaterial, string DCThinkness   )
    {
        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount)"
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckOut',"+lotUseQuantity+");";

        //更新checkOut 时间
        sql = sql + "update tlotbasis set checkouttime = now(),flowidno = flowidno+1 where lotid = '" + lot + "';";

        //插入镀层材料
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','DCMaterial','" + DCMaterial + "','" + userid + "',now());";
        //插入镀层厚度
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
          + " values('" + lotserial + "','" + worksiteid + "','DCThinkness','" + DCThinkness + "','" + userid + "',now());";

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