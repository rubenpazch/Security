    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business.backup
{
    public class Person
    {
        private int idPerson { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string midleName { get; set; }
        private Gender gerder { get; set; }
        private DateTime dateOfBirth { get; set; }
        private User user { get; set; }
        private List<Address> addresses { get; set; }

        public Person() {
        }

        public Person(int idPerson, string firstName, string lastName, string midleName, Gender gerder, DateTime dateOfBirth, User user, List<Address> addresses)
        {
            this.idPerson = idPerson;
            this.firstName = firstName;
            this.lastName = lastName;
            this.midleName = midleName;
            this.gerder = gerder;
            this.dateOfBirth = dateOfBirth;
            this.user = user;
            this.addresses = addresses;                
        }
        public Person(int idPerson, string firstName, string lastName, string midleName, Gender gerder, DateTime dateOfBirth, User user)
        {
            this.idPerson = idPerson;
            this.firstName = firstName;
            this.lastName = lastName;
            this.midleName = midleName;
            this.gerder = gerder;
            this.dateOfBirth = dateOfBirth;
            this.user = user;
        }

        public void AddAdress(Address adrs) {
            addresses.Add(adrs);
        }

    }
}
