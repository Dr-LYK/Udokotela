using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Udokotela.ServiceUser;

namespace Udokotela.Services
{
    public abstract class ConnectedService<T> where T: class
    {
        private ClientBase<T> _service;

        public ConnectedService(ClientBase<T> service)
        {
            this._service = service;
        }

        protected bool CanExecute()
        {
            return _service.State == CommunicationState.Opened || _service.State == CommunicationState.Created;
        }

        protected U Execute<U>(Func<Task<U>> func, U defaultValue)
        {
            if (CanExecute())
            {
                try
                {
                    return func().Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ConnectedService " + typeof(T) + " request received exception: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("ConnectedService " + typeof(T) + " cannot be executed yet");
            }
            return defaultValue;
        }

        protected void Execute(Func<Task> func)
        {
            if (CanExecute())
            {
                try
                {
                    func();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ConnectedService " + typeof(T) + " request received exception: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("ConnectedService " + typeof(T) + " cannot be executed yet");
            }
        }
    }
}
