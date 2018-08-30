using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business.backup
{
    public class ServiceType
    {
        private int idServiceType { get; set; }
        private string nameServiceType { get; set; }

        public ServiceType(int idServiceType, string nameServiceType)
        {
            this.idServiceType = idServiceType;
            this.nameServiceType = nameServiceType;
        }
    }
}
