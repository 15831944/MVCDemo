using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Pub;

public partial class MasterPage : System.Web.UI.MasterPage
{
    //protected void Page_Preload(object sender, EventArgs e)
    //{
    //    this.Page.ClientScript.RegisterStartupScript(this.Page.ClientScript.GetType(), "myscript", "<script>LoadingEffection();</script>"); 

    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        lblID.Text = Page.User.Identity.Name;
        lblWorkshop.Text = Request.Cookies["workshop"].Value;
        lblName.Text = HttpUtility.UrlDecode(Request.Cookies["name"].Value);
        //this.Page.ClientScript.RegisterStartupScript(Page.GetType(), "myfunction()", "LoadingEffection();");
        //this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "myscript", "<script> AddElement(); </script>");
        //Response.Write("<script>window.onload =LoadingEffection();</script>");
        //JScript.initJavascript();
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        EmptyCache();
        Session.Remove("userID");
        Session.Remove("name");
        Session.Remove("workshop");
        JScript.JavaScriptLocationHref("../Login.aspx", this);
    }

    /// <summary>
    /// 清空页面缓存，防止重复提交和跳转后后退
    /// </summary>
    private static void EmptyCache()
    {
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Expires = 0;
        HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.AddHeader("pragma", "no-cache");
        HttpContext.Current.Response.AddHeader("cache-control", "private");
        HttpContext.Current.Response.CacheControl = "no-cache";
    }
    protected void lbtnChnagePWD_Click(object sender, EventArgs e)
    {
        JScript.JavaScriptLocationHref("PermissionManage/ChangePWD.aspx", this);
    }
}
