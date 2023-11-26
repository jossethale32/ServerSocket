using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace sockettest
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server("127.0.0.1", 3367);
            s.Start();
        }
    }

}