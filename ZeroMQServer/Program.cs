using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Pushlisher();
        }

        // ZMQ提供进程内（inproc://）、进程间（ipc://）、机器间（tcp://）、广播（pgm://）等四种通信协议。

        //普通消息接收服务器
        private static void REP()
        {
            using (var context = ZContext.Create())
            {
                using (var resp = new ZSocket(context, ZSocketType.REP))
                {
                    resp.Bind("tcp://*:5555");
                    while (true)
                    {
                        ZFrame reply = resp.ReceiveFrame();
                        string message = reply.ReadString();

                        Console.WriteLine("Receive message {0}", message);

                        resp.Send(new ZFrame(message));

                        if (message == "exit")
                        {
                            break;
                        }
                    }
                }
            }
        }

        //发布者
        private static void Publisher()
        {
            using (var context = new ZContext())
            {
                using (var publisher = new ZSocket(context, ZSocketType.PUB))
                {
                    publisher.Bind("tcp://127.0.0.1:5555");
                    Random random = new Random();
                    while (true)
                    {
                        Console.WriteLine("Please enter your message:");
                        string message = Console.ReadLine();
                        publisher.Send(new ZFrame(message));
                        Console.WriteLine("Send:{0}", message);
                    }
                }
            }
        }

        private static void Pushlisher()
        {
            using (var context = new ZContext())
            {
                using (var publisher = new ZSocket(context, ZSocketType.PUSH))
                {
                    publisher.Bind("tcp://127.0.0.1:5555");
                    Random random = new Random();
                    while (true)
                    {
                        Console.WriteLine("Please enter your message:");
                        string message = Console.ReadLine();
                        publisher.Send(new ZFrame(message));
                        Console.WriteLine("Send:{0}", message);
                    }
                }
            }
        }
    }
}