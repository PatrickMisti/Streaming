
using Infrastructure.Adapter;

namespace Infrastructure.Api
{
    public interface ICommunicationApi
    {
        void Start(Action<IsRedisConnectedEvArgs> started);

        void Close();
    }
}
