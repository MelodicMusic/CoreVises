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

        public void Update(ObjectId objectId, User user)
        {
            userData.Update(objectId, user);
        }

        public void Delete(ObjectId objectId)
        {
            userData.Delete(objectId);
        }
        public User Insert(User user)
        {
            return userData.Insert(user);

        }
        public User Search(String userId)
        {
            return userData.Search(userId);
        }
    }
}
