using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business.backup 
{
    public class ServiceActivity
    {
        private int idServiceActivity { get; set; }
        private Days days { get; set; }
        private Service service { get; set; }
        private Activities activities { get; set; }

        public ServiceActivity(int idServiceActivity, Days days, Service service, Activities activities)
        {
            this.idServiceActivity = idServiceActivity;
            this.days = days;
            this.service = service;
            this.activities = activities;
        }
    }
}
