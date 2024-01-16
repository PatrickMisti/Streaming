using Infrastructure.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICommunicationAdapter
    {
        Task StartRedis(Action<IsRedisConnectedEvArgs> isReady);
        void Publish<T>(T message) where T : class;
        void Subscribe<T>(Action<T> action) where T : class;

        Task SubscribeAsync<T>(string topic, Func<T,Task> action) where T : class;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request, string pathPrefix = "");
    }
}
