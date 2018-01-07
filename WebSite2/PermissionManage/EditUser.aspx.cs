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

public partial class PermissionManage_EditUser : System.Web.UI.Page
{
    //static string userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //CommonClass.isAllow(User.Identity.Name, this, "用户维护");
            //获取用户id
            //userID = Request.QueryString["id"].ToString();
            databind();

        }
    }
    private void databind()
    {
        int listN = 0;
        //生成群组list
        DbDataReader reader = GroupManage.Groupinfo();
        while (reader.Read())
        {
            cblUsergroup.Items.Add(new ListItem(reader["name"].ToString(), reader["id"].ToString()));
            //cblUsergroup.Items[listN++].Selected = true;
        }




        //userinfo
        DataTable dt = Userdata.GetUserinfo(Request.QueryString["id"].ToString());
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                txtID.Text = 
                dr["id"].ToString();
                txtName.Text= dr["name"].ToString();
                txtStation.Text= dr["station"].ToString();
                txtWorkShop.Text =  dr["workshop"].ToString();
                txtClass.Text =  dr["class"].ToString();


            }
        }

       int a = cblUsergroup.Items.Count;

        //usergroup
       dt = Userdata.GetUserGroup(Request.QueryString["id"].ToString());
        if (dt.Rows.Count > 0)
        {
            
            foreach (DataRow dr1 in dt.Rows)
            {
                for (int i = 0; i < cblUsergroup.Items.Count; i++)
                {
                    if (dr1["name"].ToString() == cblUsergroup.Items[i].ToString())
                    {
                        cblUsergroup.Items[i].Selected = true;
                    }
                }


            }
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
       //设置user群组
        Userdata.deleteUsergroup(Request.QueryString["id"].ToString());
        for (int i = 0; i < cblUsergroup.Items.Count; i++)
        {
            if (cblUsergroup.Items[i].Selected==true)
            {

                Userdata.addUsergroup(Request.QueryString["id"].ToString(), cblUsergroup.Items[i].Value);
            }
        }


    }
}
