using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;

/// <summary>
/// Warehouse 的摘要说明
/// </summary>
public class Warehouse
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);
    static DbUtility erphelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["erpConn"].ToString(), DbProviderType.SqlServer);
    public Warehouse()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static DbDataReader QueryLotInfo(string lotid)
    {
        string sql = " select a.lotid,a.WorkshopID,ifnull(a.Warehouse,'') warehouse,a.Shipment,"
        + " ( select worksiteid from jh_mes.tworkflow where flowid = a.flowid and flowidno = a.flowidno ) worksiteid, "
        + " b.workordertype,b.workorderid,"//c.warehousecode,c.warehousetype, "
        + " ifnull(a.validLength,'0') length,a.validWidth width,b.MouldPETType pettype,b.MouldType type,b.MouldPinMin pinmin,b.MouldThinkness thinkness"
        + " from tlotbasis a "
        + " inner join tworkorderinfo b on a.WorkOrder = b.workorderid "
            //+ " inner join twarehousecodeconfig c on c.workordertype = b.workordertype and c.workshopid = b.workshopid "
        + " where a.lotid = '" + lotid + "' ";
        return dbhelp.ExecuteReader(sql, null);
    }

    public static string InsertWarehouseInfo(string warehouseid,
                                             string lotid,
                                             string warehousecode,
                                             string warehousetype,
                                             string workorderid,
                                             string workordertype,
                                             string workshopid,
                                             string userid,
                                             string pinmin,
                                             string thinkness,
                                             string length,
                                             string width,
                                             string type,
                                             string pettype)
    {
        string sql = " insert into jh_mes.twarehouseinfo(warehouseid,lotid,warehousecode,warehousetype,workorderid,workordertype,workshopid,warehouseuser,warehousetime,pinmin,thinkness,length,width,type,pettype)"
                   + " values('" + warehouseid
                   + "','" + lotid
                   + "','" + warehousecode
                   + "','" + warehousetype
                   + "','" + workorderid
                   + "','" + workordertype
                   + "','" + workshopid
                   + "','" + userid
                   + "',now(),'" + pinmin
                   + "','" + thinkness
                   + "','" + length
                   + "','" + width
                   + "','" + type
                   + "','" + pettype + "');";
        sql = sql + " update jh_mes.tlotbasis set warehouse = 'Y' where lotid = '" + lotid + "';";
        int res = dbhelp.ExecuteNonQuery(sql, null);
        if (res > 0)
        {
            return "success";
        }
        else
        {
            return "fail";
        }

    }

    public static void SetWarehouseCodedll(DropDownList ddl)
    {
        ddl.AppendDataBoundItems = false;
        string sql = "select  id paraid,warehousecode paraname from jh_mes.twarehousecodeconfig  ; ";

        using (DbDataReader reader = dbhelp.ExecuteReader(sql, null))
        {
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader["paraname"].ToString(), reader["paraid"].ToString()));
            }
            ddl.DataBind();
        }
    }

    public static string ExistWarehouseID(string warehouseid)
    {
        string sql = "select warehouseid from twarehouseinfo where warehouseid = '" + warehouseid + "';";
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

    public static DataTable QueryWOType(string wotype, string wo, string type)
    {
        string sql = @"select TQ001,TQ002,TQ003,TQ004,MB003 as type
                        from MOCTQ a
                        INNER JOIN 
                        INVMB b on a.TQ004 = b.MB001
                        where TQ001 = '" + wotype + "' and TQ002 = '" + wo + "' and TQ003 = (select MB001 from INVMB where MB003='" + type + "' and MB001 LIKE 'P%'  )   ";
        return erphelp.ExecuteDataTable(sql, null);

    }
    public static string QueryPinHaoOfTypeInERP(string Type)
    {
        string sql = @"select MB001 FROM INVMB WHERE MB001 LIKE 'P%'
                       and MB003 = '" + Type + "' ";
        object ob = erphelp.ExecuteScalar(sql, null);
        if (ob != null)
        {
            return ob.ToString();
        }
        else
        {
            return "fail";
        }

    }

    public static string InsertDataToERP(DataTable dt, GridView grd, string userid, string warehouseid)
    {
        //给datatable添加型号列
        DropDownList ddl;
        dt.Columns.Add("ERPPinHao", typeof(string));
        dt.Columns.Add("sumlength", typeof(int));
        dt.Columns.Add("Type", typeof(string));
        
        DataTable sumdt = dt.Clone();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl = (DropDownList)grd.Rows[i].FindControl("ddlType");
            dt.Rows[i]["ERPPinHao"] = ddl.SelectedValue;
            dt.Rows[i]["Type"] = ddl.SelectedItem.Text;
        }
        //按型号，仓库类型，工单，工单类型计算有效长度之和
        DataTable dtfilter = dt.DefaultView.ToTable(true, "ERPPinHao", "Warehousecode", "workorderid", "workordertype","Type");
        for (int i = 0; i < dtfilter.Rows.Count; i++)
        {
            //查询同一型号，仓库类型，工单，工单类型的数据
            DataRow[] drs = dt.Select(" ERPPinHao='" + dtfilter.Rows[i]["ERPPinHao"] + "' and warehousecode = '" + dtfilter.Rows[i]["warehousecode"] + "' and workorderid='" + dtfilter.Rows[i]["workorderid"] + "' and workordertype = '" + dtfilter.Rows[i]["workordertype"] + "' ");
            DataTable temp = dt.Clone();
            foreach (DataRow dr in drs)
            {
                temp.Rows.Add(dr.ItemArray);
            }
            //计算长度之和
            int sumlength =Convert.ToInt32( temp.Compute("sum(length)", ""));
            //创建统计表的行
            DataRow sumdr = sumdt.NewRow();
            sumdr["ERPPinHao"] = dtfilter.Rows[i]["ERPPinHao"].ToString();
            sumdr["Type"] = dtfilter.Rows[i]["Type"].ToString();
            sumdr["warehousecode"] = dtfilter.Rows[i]["warehousecode"].ToString();
            sumdr["workorderid"] = dtfilter.Rows[i]["workorderid"].ToString();
            sumdr["workordertype"] = dtfilter.Rows[i]["workordertype"].ToString();
            sumdr["sumlength"] = sumlength;
            sumdt.Rows.Add(sumdr);

        }
        string sql = "";
        int intRs = 0;
        if (sumdt.Rows.Count > 0 && sumdt != null)
        {
            for (int i = 0; i < sumdt.Rows.Count; i++)
            {
                string erpwarehousecode = "";
                if (dt.Rows[i]["warehousecode"].ToString() == "1" || dt.Rows[i]["warehousecode"].ToString() == "2")
                {
                    erpwarehousecode = "A001";
                }
                else
                {
                    erpwarehousecode = "A101";
                }
                sql += " INSERT INTO [JFUN2].[dbo].[MOCTG] ";
                sql += "            ([COMPANY]        ";//-- 公司'0001' 
                sql += "            ,[CREATOR]        ";//-- 创建人 取MES
                sql += "            ,[USR_GROUP]      ";//-- 用户组 '0004'
                sql += "            ,[CREATE_DATE]    ";//-- 创建时间 格式17位char： '20170911143950503' 
                sql += "            ,[FLAG]           ";//add by lei.xue on 2017-10-8          
                sql += "            ,[TG001]          ";//-- 单别 '5801'
                sql += "            ,[TG002]          ";//-- 单号 格式：20170930001（年月日加三位流水码)
                sql += "            ,[TG003]          ";//-- 序号 '0001''0002'......
                sql += "            ,[TG004]          ";//-- 品号（提供型号对应表） 
                sql += "            ,[TG005]          ";//-- 品名 '增亮膜'
                sql += "            ,[TG006]          ";//-- 规格 型号 取MES
                sql += "            ,[TG007]          ";//-- 单位 'M'
                sql += "            ,[TG009]          ";//-- 入\出别 1          
                sql += "            ,[TG010]          ";//-- 仓库 A,B入A001 S入A101
                sql += "            ,[TG011]          ";//-- 入库数量 同一仓库同一型号（品号）统计数量 取MES
                sql += "            ,[TG013]          ";//-- 验收数量 同入库数量 取MES
                sql += "            ,[TG014]          ";//-- 对应工单单别 'N'/'E'取MES
                sql += "            ,[TG015]          ";//-- 对应工单单号 取MES
                sql += "            ,[TG016]          ";//增加（检验状态取字符’0’） add by lei.xue on 2017-10-8
                sql += "            ,[TG017]          ";//增加（批号取字符20位’*’） add by lei.xue on 2017-10-8
                sql += "            ,[TG022]		  ";// -- 审核码 'N'  
                sql += "            ,[TG024]          ";//--增加（急料取字符’N’）add by lei,xue on 2017-10-8
                sql += "            ,[TG036]          ";//--增加（库位取字符10位’#’）add by lei,xue on 2017-10-8
                sql += "            ,[TG037]          ";//--增加（库存单位取字符’M’）add by lei,xue on 2017-10-8
                sql += "            ,[TG038]          ";//--增加（验收库存数量取入库数量同TG011）add by lei,xue on 2017-10-8
                sql += "            ,[TGC01]          ";//--增加（品号类型取字符’2’）add by lei,xue on 2017-10-8
                sql += ")";
                sql += "      VALUES                  ";
                sql += "            ('0002','" + userid + "','0004','" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + "','5801',2,'" + warehouseid + "','" + (i+1).ToString("0000") + "','" + sumdt.Rows[i]["ERPPinHao"].ToString() + "' ";
                sql += "            ,'增亮膜','" + sumdt.Rows[i]["Type"].ToString() + "','M',1,'" + erpwarehousecode + "'," + sumdt.Rows[i]["sumlength"].ToString() + "," + sumdt.Rows[i]["sumlength"].ToString() + ",'" + sumdt.Rows[i]["workordertype"].ToString() + "','" + sumdt.Rows[i]["workorderid"].ToString() + "' ";
                sql += "            ,'0'";
                sql += "            ,'********************'";
                sql += "            ,'N','##########','M'," + sumdt.Rows[i]["sumlength"].ToString() + ",'2'); ";
            }
            sql += "INSERT INTO [JFUN2].[dbo].[MOCTF] ";
            sql += "           ([COMPANY]        ";// -- 公司'0001'
            sql += "           ,[CREATOR]        ";// -- 创建人 取MES
            sql += "           ,[USR_GROUP]      ";// -- 用户组 '0004'
            sql += "           ,[CREATE_DATE]    ";// -- 创建时间 格式17位char：
            sql += "           ,[FLAG]           ";//add by lei.xue on 2017-10-8
            sql += "           ,[TF001]          ";// -- 单别 '5801'
            sql += "           ,[TF002]          ";// -- 单号 格式：20170930001（年月日加三位流水码)取MES
            sql += "           ,[TF003]          ";// -- 入库日期 格式：20170930
            sql += "           ,[TF004]          ";// -- 工厂编号 '001'
            sql += "           ,[TF006]          ";// -- 审核码 'N'    
            sql += "           ,[TF007]          ";// -- 生产记录更新码 'N'
            sql += "           ,[TF008]          ";// -- 打印次数 0
            sql += "           ,[TF009]          ";// -- 自动扣料更新码 'N'
            sql += "           ,[TF010]          ";// -- 生成分录 'N' 
            sql += "           ,[TF011]          ";// -- 工作中心 '0001'
            sql += "           ,[TF012]          ";// -- 单据日期 格式：20170930
            sql += "           ,[TF014]          ";// -- 审核状态码 'N' 
            sql += "           ,[TF015]          ";// -- 传送次数 0 
            sql += "           ,[TF016]       )  ";// -- 部门编号 '1200'            
            sql += "     VALUES";
            sql += "           ('0002','" + userid + "','0004','" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + "',2,'5801','" + warehouseid + "','" + System.DateTime.Now.ToString("yyyyMMdd") + "','001','N','N',0,'N','N','0001','" + System.DateTime.Now.ToString("yyyyMMdd") + "','N',0,'1200') ;";
            if (sql != "")
            {
                intRs = erphelp.ExecuteNonQuery(sql, null);
                if (intRs < 1)
                {
                    return "ERP入库接口出错";
                }
                else
                {
                    return "success";
                }

            }
        }
        return "ERP入库接口出错";


    }
}