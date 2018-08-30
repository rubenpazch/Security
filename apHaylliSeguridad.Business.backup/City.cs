using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class City
    {
        private int CityId { get; set; }
        private string nameCity { get; set; }

        public City(int cityId, string nameCity)
        {
            CityId = cityId;
            this.nameCity = nameCity;
        }
    }
}
