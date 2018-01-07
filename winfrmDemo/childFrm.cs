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
    public partial class childFrm : Form,IChildfrm
    {
        public void setText(string msg)
        {
            txtMsg.Text = msg;
        }

        public childFrm()
        {
            InitializeComponent();
        }

        internal void ParentTextChage(object sender, EventArgs e)
        {
            txtmsgEventArg arg = e as txtmsgEventArg;
            txtMsg.Text = arg.TxtVal;
        }



        public void setTxtVal(string txt)
        {
            txtMsg.Text = txt;
        }
    }
}
