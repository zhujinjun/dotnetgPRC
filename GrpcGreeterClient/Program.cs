using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            //自定义服务
            var weekClient = new Weeks.WeeksClient(channel);
            var weekReply = await weekClient.SayWeeksDayAsync(
                             new WeeksRequest { Day = 5 });
            Console.WriteLine("Weeks: " + weekReply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
