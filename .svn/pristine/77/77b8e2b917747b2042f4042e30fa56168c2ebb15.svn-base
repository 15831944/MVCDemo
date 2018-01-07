using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using Pub;
using System.Data.Common;

/// <summary>
///FileOperation 的摘要说明
/// </summary>
public class CommonClass
{
    static DbUtility dbhelp = new DbUtility(System.Configuration.ConfigurationManager.ConnectionStrings["mesConn"].ToString(), DbProviderType.MySql);

    public CommonClass()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}



    //写入文件  
    public static  void isAllow(string name,Page page ,string power)
    {
        if (!Userdata.getUserPower(name, power))
        { JScript.JavaScriptLocationHref("../denied.aspx", page); }
    }
    public static void WriteFile(string Content, string FileSavePath)
    {
        
        //int aa = FileSavePath.LastIndexOf("\\");
        //string fileroot = FileSavePath.Substring(0,8);
        //foreach (string d in Directory.GetFileSystemEntries("D:\\desktop_bak\\USB连接PC，通过PC上网"))
        //{
        //    string mulu = d;
        //}
        string[] sArray = Regex.Split(FileSavePath, "\\\\", RegexOptions.IgnoreCase);
        string strPath= sArray[0].ToString() +"\\" ;
        for (int i = 1; i < sArray.Length-1;i++ )
        {
            strPath = strPath + sArray[i].ToString();
            if (!File.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            strPath = strPath + "\\";

        }

        if (Directory.Exists(strPath.Substring(0,strPath.Length-1).ToString()))
        {
            if (System.IO.File.Exists(FileSavePath))
            {
                System.IO.File.Delete(FileSavePath);
            }
            System.IO.File.Create(FileSavePath).Close();
            System.IO.FileStream fs = System.IO.File.Create(FileSavePath);

            Byte[] bContent = System.Text.Encoding.GetEncoding("gb2312").GetBytes(Content);
            fs.Write(bContent, 0, bContent.Length);
            fs.Close();
            fs = null;
        }




        
    }

    //读取文件
    public static string ReadFile(string FilePath)
    {
        System.IO.StreamReader rd = System.IO.File.OpenText(FilePath);
        string StrRead = rd.ReadToEnd().ToString();
        rd.Close();
        return StrRead;
    }

    //执行dos命令
    public static void ExecuteCmd(string command)
    {
        Process p = new Process();
        p.StartInfo.FileName = "cmd.exe";

        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;

        p.Start();
        p.StandardInput.WriteLine(command);

        p.StandardInput.WriteLine("exit");
        p.WaitForExit();
       // this.textBox1.Text = textBox1.Text + p.StandardOutput.ReadToEnd();
        p.Close();
    }

    public static string Execute(string dosCommand, int outtime)
    {
        string output = "";
        if (dosCommand != null && dosCommand != "")
        {
            Process process = new Process();//创建进程对象
            ProcessStartInfo startinfo = new ProcessStartInfo();//创建进程时使用的一组值，如下面的属性
            startinfo.FileName = "cmd.exe";//设定需要执行的命令程序
            //以下是隐藏cmd窗口的方法
            startinfo.Arguments = "/c" + dosCommand;//设定参数，要输入到命令程序的字符，其中"/c"表示执行完命令后马上退出
            startinfo.UseShellExecute = false;//不使用系统外壳程序启动
            startinfo.RedirectStandardInput = false;//不重定向输入
            startinfo.RedirectStandardOutput = true;//重定向输出，而不是默认的显示在dos控制台上
            startinfo.CreateNoWindow = true;//不创建窗口
            process.StartInfo = startinfo;

            try
            {
                if (process.Start())//开始进程
                {
                    if (outtime == 0)
                    { process.WaitForExit(); }
                    else
                    { process.WaitForExit(outtime); }
                    output = process.StandardOutput.ReadToEnd();//读取进程的输出
                }
            }
            catch
            {

            }
            finally
            {
                if (process != null)
                { process.Close(); }
            }
        }
        return output;
    }

    public static string Cmd (string root)
    {
        ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");

            psi.CreateNoWindow = true;//不显示dos命令行窗口

            psi.UseShellExecute = false;

            psi.RedirectStandardOutput = true;

            psi.RedirectStandardError = true;

            psi.FileName = root;

            // Start the process

            System.Diagnostics.Process proc =System.Diagnostics.Process.Start(psi);

            // Attach the output for reading

            System.IO.StreamReader sOut = proc.StandardOutput;

            proc.Close();



            // Read the sOut to a string.

            string results = sOut.ReadToEnd().Trim();
            //results = proc.StandardOutput.ReadToEnd();
            sOut.Close();
            
        return results;
    }

    //替换HTML 中的特殊字符
    public static String changHtmlTo(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }
        string html = str;
        html = html.Replace("&amp;", "&"); //(html, "&", "&amp;");
        html = html.Replace("&lt;", "<"); //replace(html, "<", "&lt;");
        html = html.Replace("&gt;", ">"); //replace(html, ">", "&gt;");
        html = html.Replace("&nbsp", ""); 
        return html;
    }

    #region dataTable转换成Json格式
    /// <summary>  
    /// dataTable转换成Json格式  
    /// </summary>  
    /// <param name="dt"></param>  
    /// <returns></returns>  
    public static String DataTable2Json(DataTable dt,string name)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        jsonBuilder.Append("{\"");
        jsonBuilder.Append(name);
        jsonBuilder.Append("\":[");
        //jsonBuilder.Append("[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            jsonBuilder.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                jsonBuilder.Append("\"");
                jsonBuilder.Append(dt.Columns[j].ColumnName);
                jsonBuilder.Append("\":\"");
                jsonBuilder.Append(dt.Rows[i][j].ToString());
                jsonBuilder.Append("\",");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("},");
        }
        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
        jsonBuilder.Append("]");
        jsonBuilder.Append("}");
        return jsonBuilder.ToString();
    }

    #endregion dataTable转换成Json格式

}
public class LotBasisDatalist
{
    public string lotid { get; set; }
    public string workorder { get; set; }
    public string reworkorder { get; set; }
    public string status { get; set; }
    public string factoryid { get; set; }
    public string workshopid { get; set; }
    public string currentflowidno { get; set; }
    public string createuser { get; set; }
    public string flowid { get; set; }
    public string lottype { get; set; }
    public string lotcount{ get; set; }
    public string Mouldlevel { get; set; }
    public string Filmlevel { get; set; }
    public string ProcessComplete { get; set; }
    public string UVCompleteLotid { get; set; }
    public string PasteFilmLotid { get; set; }
    public string sublotid { get; set; }
    public string length { get; set; }
    public string width { get; set; }
    public string restlength { get; set; }
    public string restwidth { get; set; }
    public string eqpid { get; set; }
    //uv成型和贴膜增加有效幅宽属性
    public string validwidth { get; set; }
    //==========增加有效长度 add by lei.xue on 2017-5-28===============
    public string validlength { get; set; }

}
//制造条码过站记录
public class WipLotDatalist
{
    public string eqpid { get; set; }
    public string Mouldlot { get; set; }
    public string width { get; set; }
    public string validwidth { get; set; }
    public string length { get; set; }
    public string thinkness { get; set; }
    public string userid { get; set; }
    public string createtime { get; set; }
    public string Glue { get; set; }
    public string PET { get; set; }
    public string Haze { get; set; }
    //母批长度
    public string FatherLotidLength { get; set; }
    //母批宽度
    public string FatherLotidWidth { get; set; }

    //增加批次有效长度属性 add by lei.xue on 2017-6-13
    public string validlength { get; set; }
    //追溯报表增加员工姓名 add by lei.xue on 2017-6-16
    public string username { get; set; }

}
public class AGCoatingQCDatalist
{
    //厚度左
    public string thinknessleft { get; set; }
    //厚度中
    public string thinknessmiddle { get; set; }
    //厚度右
    public string thinknessright { get; set; }
    //厚度结果
    public string thinknessresult { get; set; }
    //翘曲变形
    public string buckling { get; set; }
    //翘曲变形检验结果
    public string bucklingresult { get; set; }
    //MD雾度
    public string MDhaze { get; set; }
    //MD雾度检验结果
    public string MDhazeresult { get; set; }
    //MD穿透率
    public string MDpenetration { get; set; }
    //MD穿透率检验结果
    public string MDpenetrationresult { get; set; }
    //TD雾度
    public string TDhaze { get; set; }
    //TD雾度检验结果
    public string TDhazeresult { get; set; }
    //TD穿透率
    public string TDpenetration { get; set; }
    //TD穿透率检验结果
    public string TDpenetrationresult { get; set; }
    //外观左
    public string appearanceleft { get; set; }
    //外观右
    public string appearanceright { get; set; }
    //外观检验结果
    public string appearanceresult { get; set; }
    //可用宽幅
    public string availablewidth { get; set; }
    //可用宽幅检验结果
    public string availablewidthresult { get; set; }
    //纹路
    public string lines { get; set; }
    //纹路检验结果
    public string linesresult { get; set; }
    //粒子密度
    //public string ParticleDensity { get; set; }
    //粒子分布
    public string ParticleDistribution { get; set; }
    //粒子高度
    public string particleheight { get; set; }
    //粒子大小
    public string particlesize { get; set; }
    //粒子检验结果
    public string particleresult { get; set; }
    //百格
    public string baige { get; set; }
    //百格检验结果
    public string baigeresult { get; set; }
    //铅笔硬度
    public string pencilhardness { get; set; }
    //铅笔硬度检验结果
    public string pencilhardnessresult { get; set; }
    //铅笔硬度正面
    public string pencilhardnessFront { get; set; }
    //铅笔硬度正面检验结果
    public string pencilhardnessFrontresult { get; set; }

    //铅笔硬度背面
    public string pencilhardnessBack { get; set; }
    //铅笔硬度背面检验结果
    public string pencilhardnessBackresult { get; set; }

    //等级
    public string filmlevel { get; set; }
    //高低差dH
    public string HeightDifferenceDH { get; set; }
    //高低差Rz
    public string HeightDifferenceRz { get; set; }
    //高低差检验结果
    public string HeightDifferenceResult { get; set; }
    //辉度增益比
    public string brilliancy { get; set; }
    //辉度增益比
    public string brilliancyResult { get; set; }
    //正面保护膜张力 贴膜检验
    public string FrontTension { get; set; }
    //正面保护膜张力检验结果 贴膜检验
    public string FrontTensionResult { get; set; }
    //背面保护膜张力 贴膜检验
    public string BackTension { get; set; }
    //背面保护膜张力检验结果 贴膜检验
    public string BackTensionResult { get; set; }
    //耐磨 成型检验
    public string abrasion { get; set; }
    //耐磨检验结果 成型检验
    public string abrasionResult { get; set; }
    //点线
    public string dotline { get; set; }
    //点线检验结果 
    public string dotlineResult { get; set; }
    public string userid { get; set; }
    public string createtime { get; set; }
    //追溯报表增加员工姓名 add by lei.xue on 2017-6-16
    public string username { get; set; }



}

        