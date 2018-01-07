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


public partial class PermissionManage_AddUser : System.Web.UI.Page
{
    //static string userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonClass.isAllow(User.Identity.Name, this, "用户维护");
            //PackageParameter.setWorkShopddl_add(ddlWorkShop);
            CRUD.setWorkShopddl_add(ddlWorkShop);
            //获取用户id
            //userID = Request.QueryString["id"].ToString();
            setddl();
            databind();

        }
    }

    private void setddl()
    {
        //this.ddlWorkShop.AppendDataBoundItems = true;
        //this.ddlWorkShop.Items.Add(new ListItem("", ""));
        //this.ddlWorkShop.Items.Add(new ListItem("C3", "C3"));
        //this.ddlWorkShop.Items.Add(new ListItem("C4", "C4"));
        //this.ddlWorkShop.Items.Add(new ListItem("C5", "C5"));
        //this.ddlWorkShop.Items.Add(new ListItem("C6", "C6"));
        //this.ddlWorkShop.DataBind();

        this.ddlClass.AppendDataBoundItems = true;
        this.ddlClass.Items.Add(new ListItem("", ""));
        this.ddlClass.Items.Add(new ListItem("A", "A"));
        this.ddlClass.Items.Add(new ListItem("B", "B"));
        this.ddlClass.Items.Add(new ListItem("C", "C"));
        this.ddlClass.Items.Add(new ListItem("长白班", "长白班"));
        this.ddlClass.DataBind();

    }

    private void databind()
    {
        int listN = 0;
        //生成群组list
        using (DbDataReader reader = GroupManage.Groupinfo())
        {
            while (reader.Read())
            {
                cblUsergroup.Items.Add(new ListItem(reader["name"].ToString(), reader["id"].ToString()));
                //cblUsergroup.Items[listN++].Selected = true;
            }
        }




        //userinfo
        //DataTable dt = Userdata.GetUserinfo(Request.QueryString["id"].ToString());
        //if (dt.Rows.Count > 0)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        txtID.Text =
        //        dr["id"].ToString();
        //        txtName.Text = dr["name"].ToString();
        //        txtStation.Text = dr["station"].ToString();
        //        txtWorkShop.Text = dr["workshop"].ToString();
        //        txtClass.Text = dr["class"].ToString();


        //    }
        //}

        //int a = cblUsergroup.Items.Count;

        //usergroup
        //dt = Userdata.GetUserGroup(Request.QueryString["id"].ToString());
        //if (dt.Rows.Count > 0)
        //{

        //    foreach (DataRow dr1 in dt.Rows)
        //    {
        //        for (int i = 0; i < cblUsergroup.Items.Count; i++)
        //        {
        //            if (dr1["name"].ToString() == cblUsergroup.Items[i].ToString())
        //            {
        //                cblUsergroup.Items[i].Selected = true;
        //            }
        //        }


        //    }
        //}
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Userdata user = new Userdata();

        user =  Userdata.getUserInfo(txtID.Text);
        if (user.ID != null)
        {
            JScript.Alert("用户已存在", this);
            return;
        }


        user.Class = ddlClass.SelectedValue;
        user.ID = txtID.Text;
        user.Name = txtName.Text;
        user.Pwd = txtPWD.Text;
        user.Station = txtStation.Text;
        user.Workshop = ddlWorkShop.SelectedValue;//System.Web.HttpContext.Current.Request.Cookies["workshop"].Value;
        
        
        
        //添加用户
        if (user.AddUser() < 1)
        {
            JScript.Alert("添加用户失败！", this); 
        }




        //设置user群组
        //Userdata.deleteUsergroup(Request.QueryString["id"].ToString());
        for (int i = 0; i < cblUsergroup.Items.Count; i++)
        {
            if (cblUsergroup.Items[i].Selected == true)
            {

                Userdata.addUsergroup(user.ID, cblUsergroup.Items[i].Value);
            }
        }


    }
}
