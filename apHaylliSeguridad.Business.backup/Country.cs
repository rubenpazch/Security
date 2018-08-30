using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Country
    {
        private int CountryID { get; set; }
        private string nameCountry { get; set; }
        private string shortNameCountry { get; set; }
        private List<State> states { get; set; }

        public Country(int countryID, string nameCountry, string shortNameCountry, List<State> states)
        {
            CountryID = countryID;
            this.nameCountry = nameCountry;
            this.shortNameCountry = shortNameCountry;
            this.states = states;
        }
    }
}
