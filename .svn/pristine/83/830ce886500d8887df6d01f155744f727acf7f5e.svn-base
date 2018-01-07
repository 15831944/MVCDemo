using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;

/// <summary>
/// Grit 的摘要说明
/// </summary>
public class Grit
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public Grit()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static string GritCheckIn(string lot, string eqp, string workshopid, string worksiteid, string userid)
    {
        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount)"
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckIn'," + lotUseQuantity + ");";

        //更新checkOut 时间
        sql = sql + "update tlotbasis set checkouttime = now() where lotid = '" + lot + "';";

       
        //插入镀层厚度
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

    public static string GritCheckOut(string lot, string labellot, string eqp, string workshopid, string worksiteid, string userid,string Haze)
    {
        string type = "";
        string sql = "";
        string ColumnName = "";
        string flowid = "";
        DataTable dt = CRUD.GetWorkflow(lot);
        flowid = dt.Rows[0]["flowid"].ToString();

        if (labellot.Length == 10)
        {
            type = labellot.Substring(3, 1).ToString();
        }
        else
        {
            type = "";
        }

        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //if (type == "Z")
        //{
        //    ColumnName = "carvelotid";
        //}
        //else
        //{
        //    ColumnName = "outwardlotid";
        //}
        if (flowid == "flow001")
        {
            ColumnName = "carvelotid";
        }
        else if (flowid == "flow002")
        {
            ColumnName = "gritlotid";
        }
        else
        {
            ColumnName = "outwardlotid";
        }
        sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount," + ColumnName + ")"
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckOut'," + lotUseQuantity + ",'" + labellot + "');";

        //更新checkOut 时间
        sql = sql + "update tlotbasis set checkouttime = now(),flowidno = flowidno+1," + ColumnName + " = '" + labellot + "' where lotid = '" + lot + "';";

        //插入雾度
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','Haze','" + Haze + "','" + userid + "',now());";
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