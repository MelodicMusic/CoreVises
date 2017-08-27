using Data;
using Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private UserData userData = new UserData();

        public Boolean UpdateUser(string objectId, User user)
        {
            return userData.UpdateUser(objectId, user);
        }

        public void DeleteUser(string objectId)
        {
            userData.DeleteUser(objectId);
        }
        public User SignUp(User user)
        {
            return userData.SignUp(user);

        }
        public User SearchUser(string userId)
        {
            return userData.SearchUser(userId);
        }

        public User LogIn(string email, string password)
        {
            return userData.LogIn(email, password);
        }
        public List<User> GetUsers()
        {
            return userData.GetUsers();
        }
    }
}
