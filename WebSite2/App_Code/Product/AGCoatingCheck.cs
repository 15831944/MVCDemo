using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;

/// <summary>
/// AGCoatingCheck 的摘要说明
/// </summary>
public class AGCoatingCheck
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public AGCoatingCheck()
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
        //1、厚度
        //a、厚度左
        string sqldetail = "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) "
                         + " values('" + lotserial + "','" + worksiteid + "','厚度','左','" + datalist.thinknessleft + "','" + datalist.thinknessresult + "','" + userid + "',now());";
        //b、厚度中
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','厚度','中','" + datalist.thinknessleft + "','" + datalist.thinknessresult + "','" + userid + "',now());";
        //c、厚度右
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','厚度','右','" + datalist.thinknessleft + "','" + datalist.thinknessresult + "','" + userid + "',now());";

        //2、翘曲变形
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','翘曲变形','','" + datalist.buckling + "','" + datalist.bucklingresult + "','" + userid + "',now());";
        //3、MD雾度
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','MD雾度','','" + datalist.MDhaze + "','" + datalist.MDhazeresult + "','" + userid + "',now());";
        //4、MD穿透率
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','MD穿透率','','" + datalist.MDpenetration + "','" + datalist.MDpenetrationresult + "','" + userid + "',now());";
        //5、外观
        //a、左
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','外观','左','" + datalist.appearanceleft + "','" + datalist.appearanceresult + "','" + userid + "',now());";
        //b、右
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','外观','右','" + datalist.appearanceright + "','" + datalist.appearanceresult + "','" + userid + "',now());";
        //6、可用宽幅
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','可用宽幅','','" + datalist.availablewidth + "','" + datalist.availablewidthresult + "','" + userid + "',now());";
        //7、纹路
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','纹路','','" + datalist.lines + "','" + datalist.linesresult + "','" + userid + "',now());";
        //8、粒子
        //a、密度改为分布modify by lei.xue on 2017-4-19================
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','粒子','分布','" + datalist.ParticleDistribution + "','" + datalist.particleresult + "','" + userid + "',now());";
        //b、高度
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','粒子','高度','" + datalist.particleheight + "','" + datalist.particleresult + "','" + userid + "',now());";
        //c、大小
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','粒子','大小','" + datalist.particlesize + "','" + datalist.particleresult + "','" + userid + "',now());";       
        //9、百格
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','百格','','" + datalist.baige + "','" + datalist.baigeresult + "','" + userid + "',now());";
        //10、铅笔硬度
        sqldetail += "insert into jh_mes.tqcdetail(lotserial,worksiteid,paratype,parasubtype,paraid,result,createuser,createtime) ";
        sqldetail += " values('" + lotserial + "','" + worksiteid + "','铅笔硬度','','" + datalist.pencilhardness + "','" + datalist.pencilhardnessresult + "','" + userid + "',now());";

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