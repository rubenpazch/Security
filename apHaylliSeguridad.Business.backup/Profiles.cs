using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Profiles
    {
        private int profileId { get; set; }
        private string name { get; set; }
        private string descripcion { get; set; }

        public Profiles(int profileId, string name, string descripcion)
        {
            this.profileId = profileId;
            this.name = name;
            this.descripcion = descripcion;
        }
    }
}
