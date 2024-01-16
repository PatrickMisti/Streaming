using Infrastructure.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapter
{
    internal class RedisAdapter : ICommunicationAdapter
    {
        private readonly ISubscriber _sub;
        private event EventHandler<IsRedisConnectedEvArgs> IsRedisConnectionFinished;
        private readonly string _host = "localhost:6379";

        public RedisAdapter()
        {
            
        }

        public async Task StartRedis(Action<object, IsRedisConnectedEvArgs> isReady)
        {
            //IsRedisConnectionFinished += isReady
            var redis = await ConnectionMultiplexer.ConnectAsync(_host);


        }

        public void Publish<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request, string pathPrefix = "")
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T>(Action<T> action) where T : class
        {
            throw new NotImplementedException();
        }

        public Task SubscribeAsync<T>(string topic, Func<T, Task> action) where T : class
        {
            throw new NotImplementedException();
        }

        public Task StartRedis(Action<IsRedisConnectedEvArgs> isReady)
        {
            throw new NotImplementedException();
        }
    }

    public class IsRedisConnectedEvArgs : EventArgs 
    {
        public bool isConnected { get; set; }
    }
}
