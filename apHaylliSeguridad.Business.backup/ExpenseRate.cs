using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class ExpenseRate
    {
        private int idExpenseRate { get; set; }
        private DateTime expenseRateDate { get; set; }
        private DateTime dueDate { get; set; }
        private string descriptionExpenseRate { get; set; }
        private Expenses expense { get; set; }
        private Rate rate { get; set; }

        public ExpenseRate(int idExpenseRate, DateTime expenseRateDate, DateTime dueDate,string descriptionExpenseRate, Expenses expense, Rate rate)
        {
            this.idExpenseRate = idExpenseRate;
            this.expenseRateDate = expenseRateDate;
            this.dueDate = dueDate;
            this.descriptionExpenseRate = descriptionExpenseRate;
            this.expense = expense;
            this.rate = rate;
        }

        public override string ToString()
        {
            return "idExpenseRate: "+ idExpenseRate.ToString()+"descriptionExpenseRate: " +descriptionExpenseRate.ToString()+ "\n expense: " + expense+ " \n rate: " + rate+"\n";
        }
        public Expenses getExpenses() {
            return this.expense;   
        }
        public Rate GetRate() {
            return this.rate;
        }
        public string getDetailsExpensesRates() {
            return "idExpenseRate= " + idExpenseRate + " descriptionExpenseRate= " + descriptionExpenseRate;
        }

    }
}
