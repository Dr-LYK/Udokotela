using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Udokotela.ServiceObservation;

namespace Udokotela.Services
{
    public class CSObservation: ConnectedService<IServiceObservation>
    {
        private IServiceObservation _client;

        // object MUST be ClientBase<IServiceObservation>, IServiceObservation
        private CSObservation(object service)
            : base((ClientBase<IServiceObservation>)service)
        {
            this._client = (IServiceObservation)service;
        }

        public CSObservation(): this(new ServiceObservationClient())
        {
        }

        public bool AddObservation(int idPatient, Observation observation)
        {
            return this.Execute(() => this._client.AddObservationAsync(idPatient, observation), false);
        }
    }
}
