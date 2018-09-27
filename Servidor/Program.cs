using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            UdpClient listener = new UdpClient(11000);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 11000);

            try
            {
                int cont = 0;
                Console.WriteLine("Esperando transmissão:");
                String content = "";
                while (!done)
                {

                    byte[] bytes = listener.Receive(ref groupEP);

                    if (cont == 0)
                        Console.WriteLine("Recebendo de {0} :", groupEP.ToString());
                    cont++;

                    content = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                    if (content != "FIM")
                        Console.WriteLine(content);
                    else
                        done = true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("Transmissão finalizada.");
                listener.Close();
                Console.ReadKey();
            }
        }
    }
}
