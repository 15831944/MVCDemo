using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
/// <summary>
/// Carve 的摘要说明
/// </summary>
public class Carve
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public Carve()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    //精雕进站模具参数改为出站填写 modify by lei.xue on 2017-4-13 ==========================
    //增加剩余厚度、钻石刀号、雕刻次数 modify by lei.xue on 2017-4-13=========================
    public static string CarveCheckOut(string lot, string carvelot, string eqp, string workshopid, string worksiteid, string userid, string DKWidth, string MouldStructure, string MouldPitch,
                                       string restthinkness,string diamondcutterno,string dkqty )
    {
        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount,carvelotid)"
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckOut'," + lotUseQuantity + ",'" + carvelot + "');";

        //更新checkOut 时间
        sql = sql + "update tlotbasis set checkouttime = now(),flowidno = flowidno+1,carvelotid = '" + carvelot + "' where lotid = '" + lot + "';";
        //模具等级变为合格
        sql += " update jh_mes.tlotbasis set mouldlevel = '合格' where lotid = '" + lot + "';";
        //插入雕刻幅宽
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','DKWidth','" + DKWidth + "','" + userid + "',now());";
        //插入模具结构
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
          + " values('" + lotserial + "','" + worksiteid + "','MouldStructure','" + MouldStructure + "','" + userid + "',now());";

        //插入模具Pitch
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
          + " values('" + lotserial + "','" + worksiteid + "','MouldPitch','" + MouldPitch + "','" + userid + "',now());";
        //增加剩余厚度 add by lei.xue on 2017-4-13==================================================
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','RestThinkness','" + restthinkness + "','" + userid + "',now());";
        //增加钻石刀号 add by lei.xue on 2017-4-13==================================================
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','DiamondCutterNo','" + diamondcutterno + "','" + userid + "',now());";
        //增加雕刻次数 add by lei.xue on 2017-4-13==================================================
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','DKQty','" + dkqty + "','" + userid + "',now());";       

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

    //取消模具参数录入 modify by lei.xue on 2017-4-13=====================
    public static string CarveCheckIn(string lot, string eqp, string workshopid, string worksiteid, string userid)//,string DKWidth ,string MouldStructure,string MouldPitch)
    {
        string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid,type,lotcount)"
                   + "values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "','CheckIn'," + lotUseQuantity + ");";

        //更新checkin 时间
        sql = sql + "update tlotbasis set checkintime = now() where lotid = '" + lot + "';";

        ////插入雕刻幅宽
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','DKWidth','" + DKWidth + "','" + userid + "',now());";
        ////插入模具结构
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //  + " values('" + lotserial + "','" + worksiteid + "','MouldStructure','" + MouldStructure + "','" + userid + "',now());";

        ////插入模具Pitch
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //  + " values('" + lotserial + "','" + worksiteid + "','MouldPitch','" + MouldPitch + "','" + userid + "',now());";


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
        //模具等级变为不良
        sql += " update jh_mes.tlotbasis set mouldlevel = '不良';";
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