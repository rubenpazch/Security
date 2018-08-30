using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Rate
    {
        private int idRate { get; set; }
        private string nameRate { get; set; }
        private double exchange { get; set; }
        private Currency currency { get; set; }

        public Rate(int idRate, string nameRate, double exchange, Currency currency)
        {
            this.idRate = idRate;
            this.nameRate = nameRate;
            this.exchange = exchange;
            this.currency = currency;
        }

        public override string ToString()
        {
            return "idRate: " + idRate.ToString() + " nameRate: " + nameRate + " exchange: " + exchange.ToString() + " currency : " + currency.ToString()+"\n";
        }

    }
}
