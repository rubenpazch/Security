using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business.backup
{
    public class User:Person
    {
        public Int32 idUser { get; set; }
        public string nickName { get; set; }
        public string userLogin { get; set; }
        public string paswoord { get; set; }
        public string userUrl { get; set; }
        public string userRegistered { get; set; }
        public string userActivationKey { get; set; }
        public bool userStatus { get; set; }
        public string displayName { get; set; }
        public Profiles profile { get; set; }

        public User() :base(){

        }
             

        public User(int idUser, string nickName, string userLogin, string paswoord, string userUrl, string userRegistered, string userActivationKey, bool userStatus, string displayName, Profiles profile) : base()
        {
            this.idUser = idUser;
            this.nickName = nickName;
            this.userLogin = userLogin;
            this.paswoord = paswoord;
            this.userUrl = userUrl;
            this.userRegistered = userRegistered;
            this.userActivationKey = userActivationKey;
            this.userStatus = userStatus;
            this.displayName = displayName;
            this.profile = profile;
        }

        public Boolean ValidatingUser( string UserLogin, string Password, List<User> list)
        {
            //Data data = new Data();
            //List<User> list = data.getListUsers();
            bool result = false;
            foreach (var user in list)
            {
                if (user.userLogin == UserLogin  && user.paswoord == Password)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public User ReturnUser( string UserLogin, List<User> list)
        {
            //Data data = new Data();
            //List<User> list = data.getListUsers();

            User var = new User();
            foreach (User user in list)
            {
                if (user.userLogin == UserLogin)
                {
                    var.displayName = user.displayName;
                    var.nickName = user.nickName;
                    var.userStatus = user.userStatus;
                }
            }
            return var;
        }
        public void DeleteUser(int IdUser, List<User> list)
        {
            //Data data = new Data();
            //List<User> list = data.getListUsers();
            foreach (var item in list)
            {
                if (item.idUser == IdUser) {
                    list.Remove(item);
                }
            }
        }
        public void AddUser(User user, List<User> list) {
            list.Add(user);
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   idUser == user.idUser &&
                   nickName == user.nickName &&
                   userLogin == user.userLogin &&
                   paswoord == user.paswoord &&
                   userUrl == user.userUrl &&
                   userRegistered == user.userRegistered &&
                   userActivationKey == user.userActivationKey &&
                   userStatus == user.userStatus &&
                   displayName == user.displayName;
        }

        public override int GetHashCode()
        {
            var hashCode = 1305015683;
            hashCode = hashCode * -1521134295 + idUser.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nickName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(userLogin);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(paswoord);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(userUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(userRegistered);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(userActivationKey);
            hashCode = hashCode * -1521134295 + userStatus.GetHashCode();
            hashCode = hashCode * -1521134295 + displayName.GetHashCode();
            return hashCode;
        }


    }
}
