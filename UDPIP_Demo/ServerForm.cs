using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDPManager;
using System.Threading;

namespace UDPIP_Demo
{
    public partial class ServerForm : Form
    {
        UDPController UdpC;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void BTNServerStart_Click(object sender, EventArgs e)
        {
            UDPController.PortNumber = 2055;
            Thread t = new Thread(new ThreadStart(UDPController.Server));
            t.Start();
            
            Form client = new ClientForm();
            client.Show();
            
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            UdpC = new UDPController();
        }
    }
}
