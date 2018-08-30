using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Hours
    {
        private int idHours { get; set; }
        private TimeSpan startTime { get; set; }
        private TimeSpan endTime { get; set; }

        public Hours(int idHours, TimeSpan startTime, TimeSpan endTime)
        {
            this.idHours = idHours;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}
