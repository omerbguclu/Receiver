using System;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Connecting to hello world server…");
            // using (var requester = new RequestSocket())
            // {
            //     requester.Connect("tcp://localhost:5555");

            //     int requestNumber;
            //     for (requestNumber = 0; requestNumber != 100; requestNumber++)
            //     {
            //         Console.WriteLine("Sending Hello {0}...", requestNumber);
            //         requester.SendFrame("Hello");
            //         string str = requester.ReceiveFrameString();
            //         Console.WriteLine("Received World {0}", requestNumber);
            //     }
            // }
            using (var responder = new PushSocket())
            {
                responder.Bind("tcp://*:5555");

                while (true)
                {
                    //string str = responder.ReceiveFrameString();
                    string str = "hellllllo";
                    Console.WriteLine(str);
                    Thread.Sleep(50);  //  Do some 'work'
                    responder.SendFrame(str);
                }
            }
        }
    }
}
