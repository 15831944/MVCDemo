using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// PasteFilmCheck 的摘要说明
/// </summary>
public class PasteFilmCheck
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

	public PasteFilmCheck()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string CheckInfo(string lotid, string eqpid, string worksiteid, string result, string userid, string mouldlevel, AGCoatingQCDatalist datalist)
    {
        string lotserial = lotid + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //检验结果
        string sql = "insert into jh_mes.tqclog(lotid,lotserial,worksiteid,eqpid,createtime,createuser,result,mouldlevel)"
                   + " values "
                   + " ('" + lotid + "',"
                   + " '" + lotserial + "',"
                   + " '" + worksiteid + "',"
                   + " '" + eqpid + "',"
                   + " now(),"
                   + " '" + userid + "',"
                   + " '" + result + "',"
                   + " '" + mouldlevel + "');";
        //检验项目
        //1、外观
        //a、左
        string sqldetail = "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','外观','左','" + datalist.appearanceleft + "','" + datalist.appearanceresult + "','" + userid + "',now());";
        //b、右
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','外观','右','" + datalist.appearanceright + "','" + datalist.appearanceresult + "','" + userid + "',now());";
        //2、可用宽幅
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','可用宽幅','','" + datalist.availablewidth + "','" + datalist.availablewidthresult + "','" + userid + "',now());";
        //3、纹路
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','纹路','','" + datalist.lines + "','" + datalist.linesresult + "','" + userid + "',now());";
        //4、点线
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','点线','','" + datalist.dotline + "','" + datalist.dotlineResult + "','" + userid + "',now());";
        //5、正面保护膜张力
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','正面保护膜张力','','" + datalist.FrontTension + "','" + datalist.FrontTensionResult + "','" + userid + "',now());";
        //6、背面保护膜张力
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','背面保护膜张力','','" + datalist.BackTension + "','" + datalist.BackTensionResult + "','" + userid + "',now());";

        int intResult = dbhelp.ExecuteNonQuery(sql + sqldetail, null);
        if (intResult > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }

    }
}