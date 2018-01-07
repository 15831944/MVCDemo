using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data;
/// <summary>
/// FilmCRUD 的摘要说明
/// </summary>
public class FilmCRUD
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public FilmCRUD()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static DataTable QueryLabeltimeByStation(string lot, string stationid)
    {
        string sql = "select lotid,a.createtime from tlotsplit a INNER JOIN tworkflow b on a.flowid=b.flowid and a.flowidno = b.flowidno "
                   + " where b.worksiteid='" + stationid + "' and a.sublotid = '" + lot + "';";
        return dbhelp.ExecuteDataTable(sql, null);
    }

    public static string[] GetLabelTime(string lot)
    {
        DataTable dt = null;
        string ParentLot = "";
        string sql = "";
        string[] Time = new string[3]; //1分条 2贴膜 3UV成型
        //分条
        dt = QueryLabeltimeByStation(lot, "M55");
        if (dt.Rows.Count > 0)
        {
            Time[0] = dt.Rows[0]["createtime"].ToString();
            //是否有贴膜
            ParentLot = dt.Rows[0]["lotid"].ToString();
            dt = QueryLabeltimeByStation(ParentLot, "M50");
            if (dt.Rows.Count > 0)
            {
                Time[1] = dt.Rows[0]["createtime"].ToString();
                ParentLot = dt.Rows[0]["lotid"].ToString();//uv成型条码
                //UV成型进行分批，修改获取时间 modify by lei.xue on 2017-3-28====================================================
                //sql = "select createtime from jh_mes.twiplotlog where uvcompletelotid = '" + ParentLot + "' and worksiteid = 'M45' order by createtime desc ";
                //object ob = dbhelp.ExecuteScalar(sql, null);
                //if (ob != null)
                //{
                //    Time[2] = ob.ToString();
                //}
                dt = QueryLabeltimeByStation(ParentLot, "M45");
                if (dt.Rows.Count > 0)
                {
                    Time[2] = dt.Rows[0]["createtime"].ToString();
                }
            }
            else
            {
                Time[1] = "";
                //UV成型进行分批，修改获取时间 modify by lei.xue on 2017-3-28====================================================
                //UVComplete时间
                //sql = "select createtime from jh_mes.twiplotlog where uvcompletelotid = '" + ParentLot + "' and worksiteid = 'M45' order by createtime desc ";
                //object ob = dbhelp.ExecuteScalar(sql, null);
                //if (ob != null)
                //{
                //    Time[2] = ob.ToString();
                //}
                dt = QueryLabeltimeByStation(ParentLot, "M45");
                if (dt.Rows.Count > 0)
                {
                    Time[2] = dt.Rows[0]["createtime"].ToString();
                }

            }
        }
        else
        {
            Time[0] = "";
            //贴膜时间
            dt = QueryLabeltimeByStation(lot, "M50");
            if (dt.Rows.Count > 0)
            {
                Time[1] = dt.Rows[0]["createtime"].ToString();
                ParentLot = dt.Rows[0]["lotid"].ToString();
                //UV成型进行分批，修改获取时间 modify by lei.xue on 2017-3-28====================================================
                //UV成型时间
                //sql = "select createtime from jh_mes.twiplotlog where uvcompletelotid = '" + ParentLot + "' and worksiteid = 'M45' order by createtime desc ";
                //object ob = dbhelp.ExecuteScalar(sql, null);
                //if (ob != null)
                //{
                //    Time[2] = ob.ToString();
                //}
                dt = QueryLabeltimeByStation(ParentLot, "M45");
                if (dt.Rows.Count > 0)
                {
                    Time[2] = dt.Rows[0]["createtime"].ToString();
                }
            }
            else
            {
                //uv时间
                Time[1] = "";
                //UV成型进行分批，修改获取时间 modify by lei.xue on 2017-3-28====================================================
                //UV成型时间
                //sql = "select createtime from jh_mes.twiplotlog where uvcompletelotid = '" + lot + "' and worksiteid = 'M45' order by createtime desc ";
                //object ob = dbhelp.ExecuteScalar(sql, null);
                //if (ob != null)
                //{
                //    Time[2] = ob.ToString();
                //}
                dt = QueryLabeltimeByStation(lot, "M45");
                if (dt.Rows.Count > 0)
                {
                    Time[2] = dt.Rows[0]["createtime"].ToString();
                }
            }
        }
        return Time;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="txtLength"></param>
    /// <param name="txtWidth"></param>
    /// <param name="lot"></param>
    /// <param name="worksiteID"></param>
    /// <param name="WO"></param>
    /// <param name="worksiteIDofData 获取长度和宽度的站点ID"></param>
    public static void GetPreLengthAndWidth(TextBox txtLength, TextBox txtWidth, string lot, string worksiteID, string WO, string worksiteIDofData)
    {
        DataTable dt = CRUD.GetWorkflow(lot);
        string firstWorksiteID = dt.Rows[0]["worksiteid"].ToString();

        //第一个站点从工单获取；
        if (worksiteID == firstWorksiteID)
        {
            //查询工单中的长、宽
            //dt.Clear();
            //dt = CreateLot.QueryWorkorderIno(WO);
            //txtLength.Text = dt.Rows[0]["mouldlength"].ToString();
            //txtWidth.Text = dt.Rows[0]["mouldwidth"].ToString();
            //如果站点是第一站取批次创建时手动输入的长度和宽度 modify by lei.xue on 2017-4-12========================================
            DataTable lotDt = CRUD.GetLotBasisInfo(lot);
            if (lotDt.Rows.Count > 0)
            {
                txtLength.Text = lotDt.Rows[0]["mouldlength"].ToString();
                txtWidth.Text = lotDt.Rows[0]["mouldwidth"].ToString();
            }
        }
        else
        {
            //批次已过站点 获取数据的站点

            string WorksiteIDOfLot = "";// CRUD.GetWorksite(lot);
            if (worksiteIDofData == "")
            {
                WorksiteIDOfLot = CRUD.GetWorksite2(lot);
            }
            else
            {
                WorksiteIDOfLot = worksiteIDofData;
            }
            //查询前站的长宽
            dt.Clear();
            dt = CRUD.getStationInfo(lot, WorksiteIDOfLot);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["paratype"].ToString() == "MouldLength")
                {
                    txtLength.Text = dt.Rows[i]["paraid"].ToString();
                }
                if (dt.Rows[i]["paratype"].ToString() == "MouldWidth")
                {
                    txtWidth.Text = dt.Rows[i]["paraid"].ToString();
                }
            }
        }
    }

    public static string GetMouldInfo(string Mouldlot, string worksiteid, ref DataTable dt)
    {
        DataTable dtWorkflow = CRUD.GetWorkflow(Mouldlot);
        string strExist = "";
        string strFlowIDNo = "";
        string strLotFlowIDNo = "";
        //流程是否包含worksiteid
        for (int i = 0; i < dtWorkflow.Rows.Count; i++)
        {
            if (dtWorkflow.Rows[i]["worksiteid"].ToString() == worksiteid)
            {
                strExist = "Y";
                strFlowIDNo = dtWorkflow.Rows[i]["flowidno"].ToString();
            }
        }
        //worksiteid是否已经做完 
        if (strExist == "Y")
        {
            dtWorkflow = null;
            dtWorkflow = CRUD.GetLotBasisInfo(Mouldlot);
            if (dtWorkflow.Rows.Count > 0)
            {
                strLotFlowIDNo = dtWorkflow.Rows[0]["flowidno"].ToString();
                if (Convert.ToInt32(strLotFlowIDNo) >= Convert.ToInt32(strFlowIDNo))
                {
                    //返回worksiteid过账记录
                    dt = CRUD.getStationInfo(Mouldlot, worksiteid);
                    return "success";
                }
            }
        }
        return "fail";
    }

    //查询批次对应的分条流程ID
    public static string QuerySubsectionFlowID(string lot)
    {
        string sql = "select distinct flowid from jh_mes.tworkflow where mappingflowid = (select flowid from jh_mes.tlotbasis where lotid = '" + lot + "')";
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

    public static void setDDLQCResult(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.AppendDataBoundItems = true;

        //ddl.Items.Add(new ListItem("", ""));
        ddl.Items.Add(new ListItem("OK", "OK"));
        ddl.Items.Add(new ListItem("NG", "NG"));

        ddl.DataBind();

    }

    public static string ExistSublot(string ParentLot, string SubLot)
    {
        string sql = "select sublotid from jh_mes.tlotsplit where lotid = '"+ParentLot+"' and sublotid = '"+SubLot+"'; ";
        object ob = dbhelp.ExecuteScalar(sql, null);
        if (ob != null)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }

}