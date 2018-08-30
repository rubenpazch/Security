using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business.backup
{
    public class Data
    {
        public  List<Person> ListPersons = new List<Person>();
        public  List<User> ListUsers = new List<User>() ;
        public List<ExpenseRate> ListExpenseRate = new List<ExpenseRate>();
        

        public Data() {

            Activities activities1 = new Activities(1, "Tour Catedral", "tour catedral del cusco");
            Activities activities2 = new Activities(2, "Tour Museo Inca", "tour catedral del cusco");
            Activities activities3 = new Activities(3, "Tour Qoricancha", "tour catedral del cusco");
            


            Expenses expenses1 = new Expenses(1,00.00,1);
            Expenses expenses2 = new Expenses(2, 00.00, 1);
            Expenses expenses3 = new Expenses(3, 39.00, 4);
            Expenses expenses4 = new Expenses(4, 43.00, 8);
            Expenses expenses5 = new Expenses(5, 52.00, 14);
            Expenses expenses6 = new Expenses(6, 90.00, 32);
            Expenses expenses7 = new Expenses(7, 00.00, 1);
            Expenses expenses8 = new Expenses(8, 00.00, 1);
            Expenses expenses9 = new Expenses(9, 40.00, 4);
            Expenses expenses10 = new Expenses(10, 40.00, 8);
            Expenses expenses11 = new Expenses(10, 40.00, 14);
            Expenses expenses12 = new Expenses(10, 40.00, 32);

            Rate rate1 = new Rate(1,"Costo Fijo Soles",1,Currency.PEN);
            Rate rate2 = new Rate(2, "Costo Fijo Dolares", 3.25, Currency.USD);
            Rate rate3 = new Rate(3, "Costo por Mayor H1", 3.25, Currency.USD);
            Rate rate4 = new Rate(4, "Costo por Mayor Sprinter Corto", 3.25, Currency.USD);
            Rate rate5 = new Rate(5, "Costo por Mayor Sprinter Largo", 3.25, Currency.USD);
            Rate rate6 = new Rate(6, "Costo por Mayor Bus", 3.25, Currency.USD);
            Rate rate7 = new Rate(7, "Costo por Mayor Auto", 3.25, Currency.USD);

            ExpenseRate expenseRate1 = new ExpenseRate(1,DateTime.UtcNow, DateTime.UtcNow, "Transporte compartido", expenses1,rate1);
            ExpenseRate expenseRate2 = new ExpenseRate(2, DateTime.UtcNow, DateTime.UtcNow, "Transporte compartido", expenses2, rate2);
            ExpenseRate expenseRate3 = new ExpenseRate(3, DateTime.UtcNow, DateTime.UtcNow, "Transporte compartido", expenses3, rate3);
            ExpenseRate expenseRate4 = new ExpenseRate(4,DateTime.UtcNow, DateTime.UtcNow, "Transporte compartido", expenses4,rate4);
            ExpenseRate expenseRate5 = new ExpenseRate(5,DateTime.UtcNow, DateTime.UtcNow, "Transporte compartido", expenses5,rate5);
            ExpenseRate expenseRate6 = new ExpenseRate(6,DateTime.UtcNow, DateTime.UtcNow, "Transporte compartido", expenses6,rate6);

            ExpenseRate expenseRate7 = new ExpenseRate(7,DateTime.UtcNow, DateTime.UtcNow, "Guia bilingüe", expenses7,rate1);
            ExpenseRate expenseRate8 = new ExpenseRate(8,DateTime.UtcNow, DateTime.UtcNow, "Guia bilingüe", expenses8,rate2);
            ExpenseRate expenseRate9 = new ExpenseRate(9, DateTime.UtcNow, DateTime.UtcNow, "Guia bilingüe", expenses9, rate3);


            ListExpenseRate.Add( expenseRate1);
            ListExpenseRate.Add( expenseRate2);
            ListExpenseRate.Add( expenseRate3);
            ListExpenseRate.Add( expenseRate4);
            ListExpenseRate.Add( expenseRate5);
            ListExpenseRate.Add( expenseRate6);
            ListExpenseRate.Add( expenseRate7);
            ListExpenseRate.Add( expenseRate8);
            ListExpenseRate.Add( expenseRate9);


            Hours hour1 = new Hours(1,new TimeSpan(8,0,0), new TimeSpan(9, 0, 0));
            Hours hour2 = new Hours(2, new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0));
            Hours hour3 = new Hours(3, new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0));
            Hours hour4 = new Hours(4, new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0));
            Hours hour5 = new Hours(5, new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));

            ServiceType ServiceType1 = new ServiceType(1, "Transport");
            ServiceType ServiceType2 = new ServiceType(2, "Guides");
            ServiceType ServiceType3 = new ServiceType(3, "Entrances");
            ServiceType ServiceType4 = new ServiceType(4, "Trains");
            ServiceType ServiceType5 = new ServiceType(5, "Assistant Guides");

            
            Service service1 = new Service(1, "Transporte compartido","Transporte compartido tipo van",hour1, ServiceType1);
            Service service2 = new Service(2, "Guia bilingüe", "Guias que hablan espaniol e ingles", hour1, ServiceType2);
            Service service3 = new Service(3, "ticket de entrada a Templo Coricancha", "entradas a lugares turisticos", hour1, ServiceType3);
            Service service4 = new Service(4, "Ticket de entrada a la catedral del cusco","tickets de entrada a la catedral del cusco", hour1, ServiceType3);



            ServiceActivity serviceActivity1 = new ServiceActivity(1, Days.Day1, service1, activities1);
            ServiceActivity serviceActivity2 = new ServiceActivity(2, Days.Day1, service2, activities1);
            ServiceActivity serviceActivity3 = new ServiceActivity(3, Days.Day1, service4, activities1);



            Menu menu1 = new Menu(1,"Modules", "/security/permitis/menu",1);
            Menu menu2 = new Menu(2, "SubModules", "/security/permitis/menu", 1);
            Menu menu3 = new Menu(3, "Menu", "/security/permitis/menu", 1);
            Menu menu4 = new Menu(4, "Sub-Menu", "/security/permitis/menu", 1);
            Menu menu5 = new Menu(5, "Users", "/security/permitis/menu", 1);
            Menu menu6 = new Menu(6, "Personel", "/security/permitis/menu", 1);
            Menu menu7 = new Menu(7, "Guides", "/security/permitis/menu", 1);


            List<Menu> listMenus1 = new List<Menu>();
            listMenus1.Add(menu1);
            listMenus1.Add(menu2);
            listMenus1.Add(menu3);


            SubModule submodule1 = new SubModule(1,"Permits and access", "localhost:1212/icons/image1.jpg", "/security/permitis",1, listMenus1);
            SubModule submodule2 = new SubModule(2, "users", "localhost:1212/icons/image1.jpg", "/security/users", 2, listMenus1);
            SubModule submodule3 = new SubModule(3, "Reports", "localhost:1212/icons/image1.jpg", "", 1, listMenus1);
            SubModule submodule4 = new SubModule(4, "Personel administration", "localhost:1212/icons/image1.jpg", "", 2, listMenus1);
            SubModule submodule5 = new SubModule(5, "administrtion", "localhost:1212/icons/image1.jpg", "", 1, listMenus1);
            SubModule submodule6 = new SubModule(7, "cotizador", "localhost:1212/icons/image1.jpg", "", 2, listMenus1);
            SubModule submodule7 = new SubModule(8, "personel information", "localhost:1212/icons/image1.jpg", "", 1, listMenus1);
            SubModule submodule8 = new SubModule(9, "itineraries", "localhost:1212/icons/image1.jpg", "", 2, listMenus1);

            List<SubModule> listSubModules1 = new List<SubModule>();
            listSubModules1.Add(submodule1);
            listSubModules1.Add(submodule2);
            List<SubModule> listSubModules2 = new List<SubModule>();
            listSubModules2.Add(submodule3);
            listSubModules2.Add(submodule4);
            List<SubModule> listSubModules3 = new List<SubModule>();
            listSubModules3.Add(submodule5);
            listSubModules3.Add(submodule6);
            List<SubModule> listSubModules4 = new List<SubModule>();
            listSubModules4.Add(submodule7);
            listSubModules4.Add(submodule8);


            Module module1 = new Module(1, "Security", "localhost:1212/icons/image1.jpg", true, 1, listSubModules1);
            Module module2 = new Module(2, "Personel", "localhost:1212/icons/image2.jpg", true, 2, listSubModules2);
            Module module3 = new Module(3, "Tours", "localhost:1212/icons/image3.jpg", true, 3, listSubModules3);
            Module module4 = new Module(4, "Guides", "localhost:1212/icons/image4.jpg", true, 4, listSubModules4);


            Profiles profl1 = new Profiles(1,"Administrator","Have all the permissions");
            Profiles profl2 = new Profiles(2, "Visitor", "Have all the permissions");
            Profiles profl3 = new Profiles(3, "Guide", "Have all the permissions");
            Profiles profl4 = new Profiles(4, "Tranfer", "Have all the permissions");


            City city1 = new City(1, "Cusco");
            City city2 = new City(2, "Quillabamba");
            City city3 = new City(3, "Sicauni");
            City city4 = new City(4, "Fairfield");
            City city5 = new City(5, "Otumwa");
            City city6 = new City(6, "Demoins");

            List<City> listCities1 = new List<City>();
            listCities1.Add(city1);
            listCities1.Add(city2);
            listCities1.Add(city3);

            List<City> listCities2 = new List<City>();
            listCities2.Add(city4);
            listCities2.Add(city5);
            listCities2.Add(city6);


            State state1 = new State(1, "Cusco", listCities1);
            State state2 = new State(2, "Iowa", listCities2);

            List<State> listStates1 = new List<State>();
            listStates1.Add(state1);
            List<State> listStates2 = new List<State>();
            listStates2.Add(state2);

            Country Peru = new Country(1, "Peru", "PE", listStates1);
            Country USA = new Country(2, "United States", "USA", listStates2);


            Address adrs1 = new Address(1, "Jiron Jerusalen D-2 Santiago", "80080", city1);
            Address adrs2 = new Address(2, "1000 N 4th Street, ", "52557", city4);

            List<Address> personAddress = new List<Address>();
            personAddress.Add(adrs1);
            personAddress.Add(adrs2);


            User user1 = new User(1, "cperez", "cperez", "123", "www.google.com/carlosperes", "aa", "utyoweurtyweuri", true, "Carlos P.",profl1);
            User user2 = new User(2, "cpaz", "cpaz", "123", "www.google.com/carlosperes", "aa", "utyoweurtyweuri", true, "Carmen P.", profl1);
            User user3 = new User(3, "cramires", "cramires", "123", "www.google.com/carlosperes", "aa", "utyoweurtyweuri", false, "Cesar R.", profl2);
            User user4 = new User(4, "cquispe", "cquispe", "123", "www.google.com/carlosperes", "aa", "utyoweurtyweuri", true, "Carla Q.", profl3);
            User user5 = new User(5, "Ealvarez", "Ealvarez", "123", "www.google.com/carlosperes", "aa", "utyoweurtyweuri", true, "Ernesto A.", profl4);

            ListUsers.Add(user1);
            ListUsers.Add(user2);
            ListUsers.Add(user3);
            ListUsers.Add(user4);
            ListUsers.Add(user5);

            ListPersons.Add(new Person(1, "Carlos", "Perez", "Yoel", Gender.MALE, DateTime.Now, user1, personAddress));
            ListPersons.Add(new Person(2, "Carmen", "Paz", "Ana", Gender.FEMALE, DateTime.Now, user2, personAddress));
            ListPersons.Add(new Person(3, "Cesar", "Ramirez", "Augusto", Gender.MALE, DateTime.Now, user3, personAddress));
            ListPersons.Add(new Person(4, "Carla", "Quispe", "Yoel", Gender.FEMALE, DateTime.Now, user4, personAddress));
            ListPersons.Add(new Person(5, "Ernesto", "Alvarez", "Raul", Gender.MALE, DateTime.Now, user5, personAddress));

 

        }

        public static void Main(string[]args) { }

  

        public List<User> getListUsers() {
            return ListUsers;
        }

        public List<Person> getListPersons()
        {
            return ListPersons;
        }
        public List<ExpenseRate> getListExpenseRate() {
            return ListExpenseRate;
        }

    }
}
