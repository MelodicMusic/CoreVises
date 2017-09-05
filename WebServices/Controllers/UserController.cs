using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Business;
using Newtonsoft.Json;
using WebServices.Security;
using MongoDB.Bson;

namespace WebServices.Controllers
{
    public class UserController : ApiController
    {

        UserBusiness userBusiness = new UserBusiness();
        //DES des = new DES();

        // POST: api/User
        public User Post([FromBody]Object value)
        {
            User user = new Domain.User();

            //string jsonString = des.Decrypt(value.ToString());
            user = JsonConvert.DeserializeObject<User>(value.ToString());


            if (!userBusiness.verifyEmail(user.email))
            {
                return this.userBusiness.SignUp(user);
            }else
            {
                return null;
            }


            
        }


        // GET: api/User/LogIn/email/password
        [HttpGet]
        [Route("api/User/LogIn/{email}/{password}")]
        public User LogIn(string email, string password)
        {
           // string email = des.Decrypt(cryptedEmail);
            //string password = des.Decrypt(cryptedPassword);
            return this.userBusiness.LogIn(email, password);

        }

        


        // PUT: api/User/value
        public Boolean Put(string id, [FromBody]Object value)
        {
            User user = new User();
           // string id = des.Decrypt(cryptedId);
            //string JsonValue = des.Decrypt(value.ToString());
            user = JsonConvert.DeserializeObject<User>(value.ToString());

            return this.userBusiness.UpdateUser(ObjectId.Parse(id), user);
        }

    }
}
