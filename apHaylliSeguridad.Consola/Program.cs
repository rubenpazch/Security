using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using apHaylliSeguridad.Business.Model;
using apHaylliSeguridad.Business.backup;

namespace apHaylliSeguridad.Consola
{
    class Program
    {
        public static Data data = new Data();
        public static List<User> listUsers = data.getListUsers();

        static void Main(string[] args)
        {
            /* List<ExpenseRate> list = new List<ExpenseRate>();
             list =data.getListExpenseRate();

             foreach (ExpenseRate item in list)
             {
                 //System.Console.WriteLine(item.getDetailsExpensesRates()+" "+item.getExpenses()+"  "+item.GetRate());
                 System.Console.WriteLine(item.getDetailsExpensesRates() + "  " + item.GetRate());

             }
             */

            TimeSpan a = new TimeSpan(1, 1, 1);

            System.Console.WriteLine(a);

            System.Console.ReadLine();
            /*validatingUser("cperez", "123");
           

            User newuser = new User();
            newuser.idUser = 6;
            newuser.nickName = "carmen";
            listUsers.Add(newuser);

            foreach (var item in listUsers)
            {
                System.Console.WriteLine(item.nickName);
            }
            System.Console.ReadLine();*/
        }

        public static bool validatingUser(string UserLogin, string Password) {
            User user = new User();
            bool result = false;
            if (!user.ValidatingUser(UserLogin, Password,listUsers))
            {
                result = false;
            }
            else
            {
                System.Console.WriteLine(user.ReturnUser(UserLogin, listUsers).nickName);
                result = true;    
            }

            System.Console.WriteLine(result);
            return result;
        }
    }
}
