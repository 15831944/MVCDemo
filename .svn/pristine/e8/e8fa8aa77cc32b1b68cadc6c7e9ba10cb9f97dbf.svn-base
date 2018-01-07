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

public partial class PermissionManage_EditGroup : System.Web.UI.Page
{
    static string Groupid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //CommonClass.isAllow(User.Identity.Name, this, "群组维护");
            //获取用户id
            Groupid = Request.QueryString["id"].ToString();
            databind();

        }
    }

    private void databind()
    {
        //生成权限list
        using (DbDataReader reader = GroupManage.Premissioninfo())
        {
            while (reader.Read())
            {

                this.cblPermission.Items.Add(new ListItem(reader["powername"].ToString(), reader["id"].ToString()));

            }
        }
            //显示群组信息
        using (DbDataReader readerGroup = GroupManage.getGroupinfo(Groupid))
        {

            if (readerGroup.Read())
            {
                txtGroup.Text = readerGroup["name"].ToString();
            }
        }
        //显示群组成员
        this.Usergrd.DataSource = GroupManage.getGroupUser(Groupid);
        this.Usergrd.DataBind();

        //群组权限
        DataTable dt = GroupManage.getGroupPermission(Groupid);//Userdata.GetUserGroup(userID);
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr1 in dt.Rows)
            {
                for (int i = 0; i < cblPermission.Items.Count; i++)
                {
                    if (dr1["powername"].ToString() == cblPermission.Items[i].ToString())
                    {
                        cblPermission.Items[i].Selected = true;
                    }
                }


            }
        }

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        //设置user群组
        GroupManage.delPermission(Groupid);//Userdata.deleteUsergroup(userID);
        for (int i = 0; i < cblPermission.Items.Count; i++)
        {
            if (cblPermission.Items[i].Selected == true)
            {
                GroupManage.addPermission(Groupid, cblPermission.Items[i].Value);
                //Userdata.addUsergroup(Groupid, cblPermission.Items[i].Value);
            }
        }
    }
}
