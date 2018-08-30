using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class State
    {
        private int StateId { get; set; }
        private string nameState { get; set; }
        private List<City> cities { get; set; }

        public State(int stateId, string nameState, List<City> cities)
        {
            StateId = stateId;
            this.nameState = nameState;
            this.cities = cities;
        }
    }
}
