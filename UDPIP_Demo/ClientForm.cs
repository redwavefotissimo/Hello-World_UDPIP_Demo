using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDPManager;

namespace UDPIP_Demo
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void BTNSend_Click(object sender, EventArgs e)
        {
            label1.Text = UDPController.Client(textBox1.Text);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            UDPController.PortNumber = 2055;
        }
    }
}
