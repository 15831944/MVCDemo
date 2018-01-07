using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Pub;


public partial class Login : System.Web.UI.Page
{
    log4net.ILog log = log4net.LogManager.GetLogger(typeof(Login));
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
       Userdata users =  Userdata.getUserInfo(txtID.Text);
       if (users.ID == null)
       {
           JScript.Alert("用户不存在！", this);

       }
       else
       {
           if (users.Pwd != txtPassWord.Text)
           {
               JScript.Alert("密码错误！", this);
           }
           else
           {
               System.Web.Security.FormsAuthentication.SetAuthCookie(txtID.Text, false);
               //设置车间cookie
               Response.Cookies["workshop"].Value = users.Workshop;
               Response.Cookies["name"].Value = HttpUtility.UrlEncode(users.Name);
               Response.Cookies["userID"].Value = users.ID;
               log.Info("登陆成功");
               JScript.JavaScriptLocationHref("Index.aspx", this);
           }
       
       }

    }
}
