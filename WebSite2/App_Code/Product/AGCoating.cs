using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;

/// <summary>
/// AGCoating 的摘要说明
/// </summary>
public class AGCoating
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public AGCoating()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// AG涂布分批，查询母批中子批的最大序列号
    /// </summary>
    /// <param name="lot"></param>
    /// <returns></returns>
    public static string QueryMaxAGCoatingLotID(string ParentLotID)
    {
        //string sql = "select count(lotid) from tlotsplit where lotid = '" + Parentlot + "' ";
        //string sql = "select ifnull(max(right(a.uvcompletelotid,5)),0) from jh_mes.tlotbasis a where year(createtime) = year(now()) and a.uvcompletelotid <>''and a.sublotid like '" + eqpid + "%' and a.workshopid = '" + workshopid + "' ; ";
        string sql = "select ifnull(max(right(a.sublotid,2)),0) from jh_mes.tlotsplit a where lotid = '"+ParentLotID+"' ; ";

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

    //取消胶水数量 modify by lei.xue on 2017-3-23
    public static string FilmCheckOut(string lot, string labellot, string eqp, string workshopid, string worksiteid, string userid,

                                      string GlueType)//string prelength, string prewidth, string length, string width,
    {
        string columnname = "UVCompletelotid";//字段名默认值
        //string lotUseQuantity = CRUD.GetUseQuantityOfLot(lot);
        string lotserial = lot + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string sql = "insert into jh_mes.twiplotlog(lotid,lotserial,eqpid,createtime,createuser,workshopid,worksiteid," + columnname + ")"
                   + " values('" + lot + "','" + lotserial + "','" + eqp + "',now(),'" + userid + "','" + workshopid + "','" + worksiteid + "', '" + labellot + "');";

        //更新checkOut 时间
        //sql = sql + "update tlotbasis set checkouttime = now(),flowidno = flowidno+1," + columnname + " = '" + labellot + "',mouldlength = '" + length + "',mouldwidth= '" + width + "',restlength = '" + length + "',restwidth = '" + width + "' where lotid = '" + lot + "';";
        //模具等级变为合格
        //sql += " update jh_mes.tlotbasis set mouldlevel = '合格' where lotid = '" + lot + "';";
        //插入前站卷材长度
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','PreMouldLength','" + prelength + "','" + userid + "',now());";
        ////插入前站幅宽规格
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //  + " values('" + lotserial + "','" + worksiteid + "','PreMouldWidth','" + prewidth + "','" + userid + "',now());";
        ////插入当站卷材长度
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','MouldLength','" + length + "','" + userid + "',now());";
        ////插入当站幅宽规格
        //sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
        //          + " values('" + lotserial + "','" + worksiteid + "','MouldWidth','" + width + "','" + userid + "',now());";
        //插入胶水规格
        sql = sql + "insert into jh_mes.twiplotdetail(lotserial,worksiteid,paratype,paraid,createuser,createtime)"
                  + " values('" + lotserial + "','" + worksiteid + "','AGCoatingGlueType','" + GlueType + "','" + userid + "',now());";
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