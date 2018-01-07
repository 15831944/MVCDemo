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

public partial class PermissionManage_ChangePWD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (txtConfirmPWD.Text != txtConfirmPWD.Text)
        {
            JScript.Alert("新密码和确认密码不一致！", this);
            return;

        }
        Userdata newUser = new Userdata();
        newUser = Userdata.getUserInfo(txtUserID.Text);
        if (newUser.ID != null)
        {
            if (newUser.Pwd != txtOriginalPWD.Text)
            {
                JScript.Alert("原始密码错误", this);
                return;


            }
            int result = Userdata.ChangePWD(txtUserID.Text, txtNewPWD.Text);
            if (result > 0)
            {
                JScript.AlertAndRedirect("密码修改成功！", "../Index.aspx", this);

            }
        }
        else
        {
            JScript.Alert("用户不存在", this);
            return;
        }

    }
}
