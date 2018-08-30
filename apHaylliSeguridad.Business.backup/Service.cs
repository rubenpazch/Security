using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business.backup
{
    public class Service
    {
        private int idService { get; set; }
        private string nameService { get; set; }
        private string descriptionService { get; set; }
       // private TimeSpan hourExecution { get; set; }
        private Hours hours { get; set; }
        private ServiceType serviceType { get; set; }

        public Service(int idService, string nameService, string descriptionService, Hours hours, ServiceType serviceType)
        {
            this.idService = idService;
            this.nameService = nameService;
            this.descriptionService = descriptionService;            
            this.hours = hours;
            this.serviceType = serviceType;
        }
    }
}
