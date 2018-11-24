using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Udokotela.ServiceUser;

namespace Udokotela.Services
{
    public class CSUser: ConnectedService<IServiceUser>
    {
        private IServiceUser _client;

        // object MUST be ClientBase<IServiceUser>, IServiceUser
        private CSUser(object service)
            : base((ClientBase<IServiceUser>)service)
        {
            this._client = (IServiceUser)service;
        }

        public CSUser(): this(new ServiceUserClient())
        {
        }

        public bool Login(string login, string password)
        {
            return this.Execute(() => this._client.ConnectAsync(login, password), false);
        }

        public User GetUser(string name)
        {
            return this.Execute(() => this._client.GetUserAsync(name), null);
        }
    }
}
