using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.Udp);

            bool repita = true;
            String x;
            IPAddress broadcast = IPAddress.Parse("127.0.0.1");
            do
            {
                Console.WriteLine("Digite a informação:");
                x = Console.ReadLine();
                byte[] sendbuf = Encoding.ASCII.GetBytes(x);
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);

                s.SendTo(sendbuf, ep);
                if (x != "FIM")
                    Console.WriteLine("Mensagem enviada para o endereço de broadcast");
                else
                    repita = false;
            } while (repita);

            Console.WriteLine("Saindo");
            Console.ReadKey();
        }
    }
}
