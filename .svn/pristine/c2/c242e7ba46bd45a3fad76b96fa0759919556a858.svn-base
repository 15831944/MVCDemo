using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Runcard 的摘要说明
/// </summary>
public class Runcard
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public Runcard()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static string DataByWorksite(DataTable dt, string worksitename)
    {
        DataTable dtjson = dt.Clone();
        DataRow[] rows = dt.Select("worksiteid='" + worksitename + "'");
        
        foreach (DataRow row in rows)
        {
            
            dtjson.Rows.Add(row.ItemArray);
        }
        if (dtjson.Rows.Count > 0)
        {
            return CommonClass.DataTable2Json(dtjson, worksitename);
        }
        else
        {
            return "";
        }
    }

    public static string QueryData(string lot)
    {
        DataTable QCdt;
        DataTable dt = FilmQuery.QueryData(lot);
        string AGJson = "";
        string UVBackJson = "";
        string UVCompleteJson = "";
        string PasteFilmJson = "";
        string SubsectionJson = "";
        string PackageJson = "";
        //检验结果
        string QCAGJson = "";
        string QCUVBackJson = "";
        string QCUVCompleteJson = "";
        string QCPasteFilmJson = "";
        string QCSubsectionJson = "";
        if (dt.Rows.Count > 0)
        {
            //1、AG涂布
            AGJson = DataByWorksite(dt, "AG涂布");
            //2、UV背涂
            UVBackJson = DataByWorksite(dt, "UV背涂");
            //3、UV成型
            UVCompleteJson = DataByWorksite(dt, "UV成型");
            //4、贴膜
            PasteFilmJson = DataByWorksite(dt, "贴膜");
            //5、分条
            SubsectionJson = DataByWorksite(dt, "分条");
            //6、包装
            PackageJson = DataByWorksite(dt, "包装");

        }
        else
        {
            return "未查询到批次号";
        }
        //===================检验内容===============================
        QCdt = QueryQCData(lot);
        if (QCdt.Rows.Count > 0)
        {
            //1、AG涂布
            QCAGJson = DataByWorksite(QCdt, "AG涂布检验");
            //2、UV背涂
            QCUVBackJson = DataByWorksite(QCdt, "UV背涂检验");
            //3、UV成型
            QCUVCompleteJson = DataByWorksite(QCdt, "UV成型检验");
            //4、贴膜
            QCPasteFilmJson = DataByWorksite(QCdt, "贴膜检验");
            //5、分条
            QCSubsectionJson = DataByWorksite(QCdt, "分条检验");
        }

        string strJson = "{\"lothistory\": [";
        strJson = AGJson != "" ? strJson += AGJson + "," : strJson;
        strJson = UVBackJson != "" ? strJson += UVBackJson + "," : strJson;
        strJson = UVCompleteJson != "" ? strJson += UVCompleteJson + "," : strJson;
        strJson = PasteFilmJson != "" ? strJson += PasteFilmJson + "," : strJson;
        strJson = SubsectionJson != "" ? strJson += SubsectionJson + "," : strJson;
        strJson = PackageJson != "" ? strJson += PackageJson + "," : strJson;
        strJson = QCAGJson != "" ? strJson += QCAGJson + "," : strJson;
        strJson = QCUVBackJson != "" ? strJson += QCUVBackJson + "," : strJson;
        strJson = QCUVCompleteJson != "" ? strJson += QCUVCompleteJson + "," : strJson;
        strJson = QCPasteFilmJson != "" ? strJson += QCPasteFilmJson + "," : strJson;
        strJson = QCSubsectionJson != "" ? strJson += QCSubsectionJson + "," : strJson;
        //去除最后的逗号
        strJson = strJson.EndsWith(",") == true ? strJson = strJson.Substring(0, strJson.Length - 1) : strJson;
        strJson += "]}";
        return strJson;
    }

    public static DataTable QueryQCData(string lot)
    {
        string sql = " call prRuncard_QCData('" + lot + "');";
        return dbhelp.ExecuteDataTable(sql, null);
    }
}