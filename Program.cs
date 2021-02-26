using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ping
{
    class Program
    {
        static void Main(string[] args)
        {
            String destination = "";
            if (args.Length >= 1)
                destination = args[0];
            else
            {
                Console.Write("Enter destination address: ");
                destination = Console.ReadLine();
            }
            bool pingable = false;
            Ping pinger = null;
            PingReply reply = null;

            while (true)
            {
                try
                {
                    pinger = new Ping();
                    reply = pinger.Send(destination);
                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException ex)
                {
                    Console.WriteLine(destination + " error: " + ex.Message);
                }
                if (pinger != null)
                    pinger.Dispose();
                if (pingable)
                {
                    Console.WriteLine("Ping to " + destination + "[" + reply.Address.ToString() + "]" + " Successful"
                       + " Response delay = " + reply.RoundtripTime.ToString() + " ms");
                }
                else
                {
                    Console.WriteLine(destination + " is not pingable...");
                }
            }
        }
    }
}
