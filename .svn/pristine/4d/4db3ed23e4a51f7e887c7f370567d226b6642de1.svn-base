using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Subsection 的摘要说明
/// </summary>
public class Subsection
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public Subsection()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string ExistSubsectionLotid(string lot)
    {
        string sql = "select lotid from tlotsplit where  sublotid = '" + lot + "';";
        object ob = dbhelp.ExecuteScalar(sql, null);
        if (ob != null)
        {
            return ob.ToString();
        }
        else
        {
            return "fail";
        }
    }

    public static string FilmCheckOut(string lot, string eqp, string workshopid, string worksiteid, string userid)
    {
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid)"
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "');";

        ////更新checkOut 时间
        //sql = sql + "update tlotbasis set checkouttime = now(),flowidno = flowidno+1," + columnname + " = '" + labellot + "',mouldlength = '" + length + "',mouldwidth= '" + width + "',restlength = '" + length + "',restwidth = '" + width + "' where lotid = '" + lot + "';";
        ////模具等级变为合格
        ////sql += " update jh_mes.tlotbasis set mouldlevel = '合格' where lotid = '" + lot + "';";
        ////插入前站卷材长度
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','PreMouldLength','" + prelength + "','" + userid + "',now());";
        ////插入前站幅宽规格
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','PreMouldWidth','" + prewidth + "','" + userid + "',now());";
        ////插入当站卷材长度
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','MouldLength','" + length + "','" + userid + "',now());";
        ////插入当站幅宽规格
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','MouldWidth','" + width + "','" + userid + "',now());";      
        //插入模具编号

        //插入胶水数量
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','GlueQty','" + GlueQty + "','" + userid + "',now());";

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