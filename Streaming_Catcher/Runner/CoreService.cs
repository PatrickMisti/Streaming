using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    public class CoreService
    {

        public CoreService() { }

        public async Task StartAsync() 
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            var sub = redis.GetSubscriber();

            await sub.SubscribeAsync("test", (ch, msg) =>
            {
                Console.Write(msg);
                
            });
            return; 
        }

        public void Stop() { }
    }
}
