using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace TrabDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();

            this.Visible = false;
        }
        public static void ThreadProc()
        {
            Application.Run(new Form2());
        }
        public static void ThreadProc2()
        {
            Application.Run(new Form3());
        }
        private void btnlogar_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc2));
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();

            this.Visible = false;
        }
    }
}
