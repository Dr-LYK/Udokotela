using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Udokotela.ServiceLive;

namespace Udokotela.Services
{
    public class CSLiveData: ConnectedService<IServiceLive>
    {
        private IServiceLive _client;

        // object MUST be ClientBase<IServiceLive>, IServiceLive
        private CSLiveData(object service)
            : base((ClientBase<IServiceLive>)service)
        {
            this._client = (IServiceLive)service;
        }

        public CSLiveData(): this(new ServiceLiveClient(null))
        {
            Subscribe();
        }

        private void Subscribe()
        {
            this.Execute(() => this._client.SubscribeAsync());
        }
    }
}
