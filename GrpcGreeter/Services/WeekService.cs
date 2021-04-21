using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter
{
    //Greeter.GreeterBase类根据greet.proto文件自动生成，位置 obj\Debug\netcoreapp3.0
    public class WeekService : Weeks.WeeksBase
    {
        private readonly ILogger<GreeterService> _logger;
        public WeekService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        List<string> weekArray = new List<string> { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期天" };
        //HelloRequest 请求参数   HelloReply 响应参数
        public override Task<WeeksDayReply> SayWeeksDay(WeeksRequest request, ServerCallContext context)
        {
            var reply = new WeeksDayReply();
            if (request.Day > weekArray.Count)
            {
                reply.Message = "输入日期超出范围";
            }
            else
            {
                reply.Message = weekArray[request.Day].ToString();
            }
            return Task.FromResult(reply);
        }
    }
}
