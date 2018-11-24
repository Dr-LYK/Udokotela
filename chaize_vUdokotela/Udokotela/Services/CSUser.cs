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

        public void Disconnect(string login)
        {
            this.Execute(() => this._client.DisconnectAsync(login));
        }

        public User GetUser(string login)
        {
            return this.Execute(() => this._client.GetUserAsync(login), null);
        }

        public List<User> GetUsers()
        {
            User[] users = this.Execute(() => this._client.GetListUserAsync(), null);
            if (users != null)
            {
                return users.ToList();
            }
            return null;
        }

        public string GetRole(string login)
        {
            return this.Execute(() => this._client.GetRoleAsync(login), null);
        }

        public bool AddUser(User newUser)
        {
            return this.Execute(() => this._client.AddUserAsync(newUser), false);
        }

        public bool DeleteUser(string login)
        {
            return this.Execute(() => this._client.DeleteUserAsync(login), false);
        }
    }
}
