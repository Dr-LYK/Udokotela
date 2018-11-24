using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Udokotela.ServicePatient;

namespace Udokotela.Services
{
    public class CSPatient: ConnectedService<IServicePatient>
    {
        private IServicePatient _client;

        // object MUST be ClientBase<IServicePatient>, IServicePatient
        private CSPatient(object service)
            : base((ClientBase<IServicePatient>)service)
        {
            this._client = (IServicePatient)service;
        }

        public CSPatient(): this(new ServicePatientClient())
        {
        }

        public Patient GetPatient(int id)
        {
            return this.Execute(() => this._client.GetPatientAsync(id), null);
        }

        public List<Patient> GetPatients()
        {
            Patient[] patients = this.Execute(() => this._client.GetListPatientAsync(), null);
            if (patients != null)
            {
                return patients.ToList();
            }
            return null;
        }

        public bool AddPatient(Patient newPatient)
        {
            return this.Execute(() => this._client.AddPatientAsync(newPatient), false);
        }

        public bool DeleteUser(int id)
        {
            return this.Execute(() => this._client.DeletePatientAsync(id), false);
        }
    }
}
