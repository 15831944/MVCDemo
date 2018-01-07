using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;

public partial class Report_WIPReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        databind();
    }
    private void databind()
    {
        DataTable dt = WIPReport.QueryData(ddlType.SelectedValue, ddlMethod.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (ddlType.SelectedValue == "工单")
            {
                grdWO.Visible = true;
                grdModel.Visible = false;
                grdWO.DataSource = dt;
                grdWO.DataBind();
                //Nmtree.MergeGridViewCell.MergeRow(grdWO, 0, 7);
            }
            else if (ddlType.SelectedValue == "型号")
            {
                grdWO.Visible = false;
                grdModel.Visible = true;
                grdModel.DataSource = dt;
                grdModel.DataBind();
            }
        }
    }

    protected void grdWO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.ToString() == "&nbsp;")
                //当鼠标停留时更改背景色

                e.Row.Attributes.Add("style", "background-color:#8EC26F");
            //当鼠标移开时还原背景色
            //e.Row.Cells[1].Attributes.Add("onmouseout", "this.style.backgroundColor=c");

        }
    }
    protected void grdModel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.ToString() == "&nbsp;")
                //当鼠标停留时更改背景色

                e.Row.Attributes.Add("style", "background-color:#8EC26F");
            //当鼠标移开时还原背景色
            //e.Row.Cells[1].Attributes.Add("onmouseout", "this.style.backgroundColor=c");

        }
    }
}