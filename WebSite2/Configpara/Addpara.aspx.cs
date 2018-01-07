using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pub;
using System.Data;

public partial class Configpara_Addpara : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Configpara.Setdll(ddlParatype);
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        DataTable dt = Configpara.Exist(ddlParatype.SelectedValue, txtParaID.Text);
        if (dt.Rows.Count > 0)
        {
            JScript.Alert("参数已存在！", this);
            return;
        }

        string result = Configpara.Add(ddlParatype.SelectedValue, txtParaID.Text, txtParaname.Text
                                        , System.Web.HttpContext.Current.Request.Cookies["userID"].Value.ToString());
        if (result == "success")
        {
            JScript.Alert("添加成功！", this);
            return;
        }
        else
        {
            JScript.Alert("添加失败！", this);
            return;
        }

    }
}