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
    class UserBusiness
    {
        private UserData userData = new UserData();

        public void UpdateUser(string objectId, User user)
        {
            userData.UpdateUser(objectId, user);
        }

        public void DeleteUser(string objectId)
        {
            userData.DeleteUser(objectId);
        }
        public User SignIn(User user)
        {
            return userData.SignIn(user);

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
