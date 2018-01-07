<%@ WebHandler Language="C#" Class="login" %>

using System;
using System.Web;

public class login : IHttpHandler
{
    log4net.ILog log = log4net.LogManager.GetLogger(typeof(login));
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string username = context.Request.Params["pusername"].ToString();
        string password = context.Request.Params["ppassword"].ToString();
        string ResponseResult = "";
        Userdata users = Userdata.getUserInfo(username);
        if (users.ID == null)
        {
            ResponseResult = "用户不存在";

        }
        else
        {
            if (users.Pwd != password)
            {
                ResponseResult = "密码错误！";
            }
            else
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(username, false);
                //设置车间cookie
                context.Response.Cookies["workshop"].Value = users.Workshop;
                context.Response.Cookies["name"].Value = HttpUtility.UrlEncode(users.Name);
                context.Response.Cookies["userID"].Value = users.ID;
                log.Info("登陆成功");
                ResponseResult = "success";
            }

        }
        context.Response.Write(ResponseResult);
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}