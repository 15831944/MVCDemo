using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

/// <summary>
/// CreateMouldLot 的摘要说明
/// </summary>
public class CreateMouldLot
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public CreateMouldLot()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    //查询当日最大批次数量
    public static int QueryMaxNum()
    {
        string sql = " select ifnull(max(lotid),0) num from jh_mes.tlotbasis where   lottype = 'Mould' -- and date(createtime) =  curdate() ";
        DbDataReader result = dbhelp.ExecuteReader(sql, null);
        if (result.Read())
        {
            return Convert.ToInt32(result["num"]);
        }
        else
        {
            return 0;
        }

    }

    public static string InsertLot(LotBasisDatalist list)
    {
        //批次是否已经创建 add by lei.xue on 2017-6-2
        if (CreateMouldLot.LotExist(list.lotid) == "success")
        {
            return "批次已存在!";
        }
        string sql = "insert into jh_mes.tlotbasis(lotid,workorder,reworkorder,status,factoryid,workshopid,"
                   + " flowidno,worksitename,checkintime,checkouttime,createtime,createuser,flowid,lottype,lotcount,filmlevel,uvcompletelotid,pastefilmlotid,mouldlength,restlength,mouldwidth,restwidth,eqpid,validwidth,validlength"
                   + ")values ("
                   + "'" + list.lotid + "',"
                   + "'" + list.workorder + "',"
                   + "'" + list.reworkorder + "',"
                   + "'" + list.status + "',"
                   + "'" + list.factoryid + "',"
                   + "'" + list.workshopid + "',"
                   + "'" + list.currentflowidno + "',"
                   + "Null," //worksitename
                   + "Null," //checkintime
                   + "Null," //checkouttime
                   + "sysdate()," //createtime
                   + "'" + list.createuser + "',"
                   + "'" + list.flowid + "',"
                   + "'" + list.lottype + "',"
                   + list.lotcount + ","
                   + "'" + list.Filmlevel + "',"
                   + "'" + list.UVCompleteLotid + "',"
                   + "'" + list.PasteFilmLotid + "',"
                   + "'" + list.length + "',"
                   + "'" + list.restlength + "',"
                   + "'" + list.width + "',"
                   + "'" + list.restwidth + "',"
                   + "'" + list.eqpid + "',"
                   + "'" + list.validwidth + "',"
                   + "'" + list.validlength + "'"
                   + ") ;";
        int result = dbhelp.ExecuteNonQuery(sql, null);

        if (result > 0)
        {
            return "success";
        }
        else
        {
            return "批次创建失败！";
        }
    }

    public static string LotExist(string lot)
    {
        string sql = " select lotid from tlotbasis where lotid ='"+lot+"' ";
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