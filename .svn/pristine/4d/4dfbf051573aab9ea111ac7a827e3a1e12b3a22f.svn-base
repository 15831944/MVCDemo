using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Serialization;


/// <summary>
/// WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string QueryLotHistory(string lot)
    {
        string strResult  =  Runcard.QueryData(lot);
        //HttpContext.Current.Response.Write(strResult);
        //HttpContext.Current.Response.End();
        return strResult;
    }

    [WebMethod]
    public string SayHelloJson(string firstName, string lastName)
    {
        var data = new { Greeting = "Hello", Name = firstName + " " + lastName };

        // We are using an anonymous object above, but we could use a typed one too (SayHello class is defined below)
        // SayHello data = new SayHello { Greeting = "Hello", Name = firstName + " " + lastName };

        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

        return js.Serialize(data);
    }
    
}
