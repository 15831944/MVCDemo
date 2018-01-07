using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;

public partial class Report_LineOutputReport : System.Web.UI.Page
{
    int sumOutputQty = 0;
    int sumAGradeQty = 0;
    int sumBGradeQty = 0;
    int sumHoldQty = 0;
    int sumScrapQty = 0;
    int sumInputQty = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //绑定查询选项内容
            LineOutputReport.setWorksiteDDL(ddlWorksite);
            //工单类型
            OutputReport.setWOTypeddl(ddlWOType);
            //工单厚度
            OutputReport.setWOddl(ddlThinkness, "mouldthinkness");
            //工单宽度
            OutputReport.setWOddl(ddlWidth, "mouldwidth");
            //工单产品类型
            OutputReport.setWOddl(ddlWOProducttype, "mouldtype");
            //班次
            OutputReport.setClassDDL(ddlClass);
            BindTimeByClass();
        }
    }
    protected void btnSaveClose_Click(object sender, EventArgs e)
    {
        string bt = "", et = "";
        if (ddlClass.SelectedValue == "ALL")
        {
            bt = txtBt.Text + " 08:30:00";
            et = Convert.ToDateTime(txtEt.Text).AddDays(1).ToString("yyyy-MM-dd") + " 08:30:00";
        }
        else if (ddlClass.SelectedValue == "Day")
        {
            bt = txtBt.Text + " 08:30:00";
            et = txtEt.Text + " 20:30:00";
        }
        else if (ddlClass.SelectedValue == "Night")
        {
            bt = txtBt.Text + " 20:30:00";
            et = Convert.ToDateTime(txtEt.Text).AddDays(1).ToString("yyyy-MM-dd") + " 08:30:00";
        }
        databind(bt,et);
    }
    private void databind(string bt,string et)
    {
        DataTable dt;

            dt = LineOutputReport.QueryData(bt, et, ddlWOType.SelectedValue, ddlWOProducttype.SelectedValue, ddlWidth.SelectedValue, ddlThinkness.SelectedValue, ddlWorksite.SelectedItem.Value,ddlClass.SelectedValue);
            grd.DataSource = dt;
            grd.DataBind();
     
    }



    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(e.Row.Cells[1].Text.ToString()=="Total")
            //当鼠标停留时更改背景色

                e.Row.Attributes.Add("style", "background-color:#8EC26F");
            //当鼠标移开时还原背景色
            //e.Row.Cells[1].Attributes.Add("onmouseout", "this.style.backgroundColor=c");

        }
    }
    protected void ddlClass_TextChanged(object sender, EventArgs e)
    {
        BindTimeByClass();


    }
    private void BindTimeByClass()
    {
        //if (ddlClass.SelectedValue == "ALL")
        //{
        //    txtBt.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 08:30:00";
        //    txtEt.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 08:30:00";
        //}
        //else if (ddlClass.SelectedValue == "Day")
        //{
        //    txtBt.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 08:30:00";
        //    txtEt.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 20:30:00";
        //}
        //else if (ddlClass.SelectedValue == "Night")
        //{
        //    txtBt.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 20:30:00";
        //    txtEt.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 08:30:00";
        //}
        if (ddlClass.SelectedValue == "ALL")
        {
            txtBt.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            txtEt.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        }
        else if (ddlClass.SelectedValue == "Day")
        {
            txtBt.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            txtEt.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        }
        else if (ddlClass.SelectedValue == "Night")
        {
            txtBt.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            txtEt.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        }
    }
}