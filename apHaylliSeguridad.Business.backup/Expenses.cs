using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Expenses
    {
        private int idAmount { get; set; }
        private double value { get; set; }
        private double quantity { get; set; }

        public Expenses(int idAmount, double value, double quantity)
        {
            this.idAmount = idAmount;
            this.value = value;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return "idAmount: "+idAmount.ToString()+" value :"+value + " quantity: "+quantity.ToString()+"\n";
        }
    }
}
