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
using System.Data.Common;
using Pub;

public partial class Material_EditWO : System.Web.UI.Page
{
    //static string userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtWOID.Attributes.Add("readonly", "true");
            setdll();
            databind();
        }
    }
    private void databind()
    {
        string wo = Request.QueryString["workorderid"].ToString();
        DataTable dt = EditWO.Retrieve(wo);
        if (dt.Rows.Count > 0)
        {
            txtWOID.Text = wo;
            ddlWorkFlow.SelectedValue = dt.Rows[0]["flowid"].ToString();
            txtWorkshop.Text = dt.Rows[0]["workshopid"].ToString();
            txtPinmin.Text = dt.Rows[0]["MouldPinmin"].ToString();
            txtLength.Text = dt.Rows[0]["mouldlength"].ToString();
            txtWidth.Text = dt.Rows[0]["mouldwidth"].ToString();
            txtThinkness.Text = dt.Rows[0]["mouldthinkness"].ToString();
            txtType.Text = dt.Rows[0]["mouldtype"].ToString();
            txtPETType.Text = dt.Rows[0]["mouldpettype"].ToString();
            ddlWOType.SelectedValue = dt.Rows[0]["workordertype"].ToString();

        }
    }

    private void setdll()
    {
        CRUD.setWorkFlowDDL(ddlWorkFlow, "Film");
        CRUD.Setdll(ddlWOType, "WorkOrderType");

    }

  
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        string rs=EditWO.Update(txtWOID.Text
            , ddlWorkFlow.SelectedValue
            , txtWorkshop.Text
            , txtPinmin.Text
            , txtThinkness.Text
            , txtLength.Text
            , txtWidth.Text
            , txtType.Text
            , txtPETType.Text
            , ddlWOType.SelectedValue);
        if (rs == "success")
        {
            JScript.Alert("修改成功", this);
            return;
        }
        else
        {
            JScript.Alert("修改失败",this);
            return;
        }
    }
}
