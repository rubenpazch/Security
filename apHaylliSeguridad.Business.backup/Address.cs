using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Address
    {
        private int addressID { get; set; }
        private string nameAddress { get; set; }
        private string zipCode { get; set; }
        private City city { get; set; }

        public Address(int addressID, string nameAddress, string zipCode, City city)
        {
            this.addressID = addressID;
            this.nameAddress = nameAddress;
            this.zipCode = zipCode;
            this.city = city;
        }
    }
}
