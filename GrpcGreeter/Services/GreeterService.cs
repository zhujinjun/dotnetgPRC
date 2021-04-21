using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter
{
    //Greeter.GreeterBase类根据greet.proto文件自动生成，位置 obj\Debug\netcoreapp3.0
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        //HelloRequest 请求参数   HelloReply 响应参数
        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return await Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
