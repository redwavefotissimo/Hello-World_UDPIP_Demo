using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Configuration;

namespace UDPManager
{
    public class UDPController
    {
        public static int PortNumber;
        
        public static void Server()
        {
            IPEndPoint Ep = null;
            UdpClient Udp = new UdpClient(PortNumber);
            while (true)
            {
                try
                {
                    byte[] rdata = Udp.Receive(ref Ep);
                    string name = Encoding.ASCII.GetString(rdata);
                    string job = ConfigurationManager.AppSettings[name];
                    if (string.IsNullOrWhiteSpace(job))
                    {
                        job = "No Such Employee";
                    }
                    byte[] sdata = Encoding.ASCII.GetBytes(job);
                    Udp.Send(sdata, sdata.Length, Ep);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }





        public static string Client(string Name)
        {
            UdpClient Udp = new UdpClient();
            string job = string.Empty;
            IPEndPoint ep = new IPEndPoint(Dns.GetHostAddresses(Dns.GetHostName()).Last(), PortNumber);
            Udp.Connect(ep);
            
            byte[] rdata = null;

            try
            {
                byte[] sdata = Encoding.ASCII.GetBytes(Name);
                Udp.Send(sdata, sdata.Length);
                //while (true)
                //{
                //    try
                //    {
                rdata = Udp.Receive(ref ep);
                job = Encoding.ASCII.GetString(rdata);
                //    }
                //    finally
                //    { }
                //}
            }
            catch (Exception ex)
            {
                throw;
            }

            return job; //Encoding.ASCII.GetString(rdata);
        }

    }
}
