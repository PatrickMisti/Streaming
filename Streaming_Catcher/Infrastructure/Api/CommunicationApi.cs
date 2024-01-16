using Infrastructure.Adapter;
using Infrastructure.Enums;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Api
{
    public class CommunicationApi : ICommunicationApi
    {       
        private readonly ICommunicationAdapter _adapter;
        public CommunicationApi(ICommunicationAdapter adapter) { }

        public CommunicationApi(ICommunicationAdapter adapter, Services sender) 
        { 
            _adapter = adapter;
        }

        public void Start(Action<IsRedisConnectedEvArgs> started)
        {
            if (_adapter == null)
                throw new ArgumentNullException();

            
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public static CommunicationApi WithContext(ICommunicationAdapter adapter, Services sender)
        {
            return new CommunicationApi(adapter, sender);
        }
    }
}
