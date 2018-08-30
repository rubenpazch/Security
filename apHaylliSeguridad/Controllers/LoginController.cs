using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using apHaylliSeguridad.Business.Model;
using apHaylliSeguridad.Business.backup;

namespace apHaylliSeguridad.Controllers
{
    public class LoginController : ApiController
    {
        public static Data data = new Data();
        public static List<User> listUsers = data.getListUsers();
        
        /*public User Get()
        {
            string UserLogin="cperez",  Password = "123";
            //string Password = "123";

            User user = new User();
            if (!user.ValidatingUser(UserLogin, Password))
            {
                return user;
            }
            user= user.ReturnUser(UserLogin); 
            return user;
        }*/
        public List<User> Get()
        {
            //Data data = new Data();
            return listUsers;
        }

        public void Delete(int id) {
            User user = new User();
            user.DeleteUser(id, listUsers);
        }

        public void Post([FromBody]User newuser)
        {
            listUsers.Add(newuser);
        }
        public void Put([FromBody]User newuser)
        {
            foreach (var item in listUsers)
            {
                if (item.idUser == newuser.idUser) {
                    item.nickName = newuser.nickName;
                    item.paswoord = newuser.paswoord;
                }
            }
        }

    }
}
