using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
namespace WinFrmThreadDemo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                

                while (true)
                {
                    Console.WriteLine(DateTime.Now.ToString());
                    if (this.btnLoop.InvokeRequired)//如果是别的控件创建的此线程
                    {
                        btnLoop.Invoke(new Action<string>(s => this.btnLoop.Text = s), DateTime.Now.ToString());
                    }
                    else
                    {
                        btnLoop.Text = DateTime.Now.ToString();
                    }
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }
    }
}
