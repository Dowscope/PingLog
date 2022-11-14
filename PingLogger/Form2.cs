using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PingLogger
{
    public partial class frmIPC : Form
    {
        
        public frmIPC()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIPCInfo.Text = "";
        }

        public void OnTextUpdate(string data)
        {
            btnClear.Invoke(new Action(() =>
            {
                txtIPCInfo.Text += data;
            }));
            
        }
    }
}
