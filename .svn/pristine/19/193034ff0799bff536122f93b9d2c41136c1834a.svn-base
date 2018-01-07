using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OutWard 的摘要说明
/// </summary>
public class OutWard
{
 static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public OutWard()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string OutWardCheckOut(string lot, string outwardlotid,string eqp, string workshopid, string worksiteid, string userid, string DKWidth, string MouldStructure, string MouldPitch)
    {
        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount)"
                   + "values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckOut'," + lotUseQuantity + ");";

        //更新checkOut 时间
        sql = sql + "update tlotbasis set checkouttime = now(),flowidno = flowidno+1,outwardlotid = '"+outwardlotid+"' where lotid = '" + lot + "';";

        //插入雕刻幅宽
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','DKWidth','" + DKWidth + "','" + userid + "',now());";
        //插入模具结构
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
          + " values('" + lotserial + "','" + worksiteid + "','MouldStructure','" + MouldStructure + "','" + userid + "',now());";

        //插入模具Pitch
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
          + " values('" + lotserial + "','" + worksiteid + "','MouldPitch','" + MouldPitch + "','" + userid + "',now());";


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