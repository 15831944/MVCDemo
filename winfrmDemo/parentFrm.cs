using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace winfrmDemo
{
    public partial class parentFrm : Form
    {
        public Action<string> MyProperty { get; set; }
        public event EventHandler Myevent;
        public List<IChildfrm> ListChildFrm { get; set; }
        public parentFrm()
        {
            InitializeComponent();
        }

        private void parentFrm_Load(object sender, EventArgs e)
        {
            childFrm cfrm = new childFrm();
            cfrm.Show();

            #region 委托方式传值
            //MyProperty += cfrm.setText; 
            #endregion

            #region 事件方式
            Myevent += cfrm.ParentTextChage; 
            #endregion

            //this.ListChildFrm = new List<IChildfrm>();
            ListChildFrm.Add(cfrm);


            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            #region 委托传值

            if (MyProperty == null)
            {
                return;
            }

            MyProperty(txtMsg.Text);

            #endregion

            #region  事件传值
            Myevent(this, new txtmsgEventArg() { TxtVal = txtMsg.Text }); 
            #endregion

            if (ListChildFrm == null) 
            {
                return;
            }

            foreach (var item in ListChildFrm)
            {
                item.setTxtVal(txtMsg.Text);
            }


        }
    }
}
