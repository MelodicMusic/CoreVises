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

namespace WebServices.Controllers
{
    public class UserController : ApiController
    {

        UserBusiness userBusiness = new UserBusiness();
        DES des = new DES();

        // POST: api/User
        public User Post([FromBody]Object value)
        {
            User user = new Domain.User();

            string jsonString = des.Decrypt(value.ToString());
            user = JsonConvert.DeserializeObject<User>(value.ToString());

            return this.userBusiness.SignUp(user);
        }


        // GET: api/User/LogIn/email/password
        [HttpGet]
        [Route("api/User/LogIn/{email}/{password}")]
        public User LogIn(string email, string password)
        {
            string email_ = des.Decrypt(email);
            string password_ = des.Decrypt(password);
            return this.userBusiness.LogIn(email_, password_);
        }


        // PUT: api/User/value
        public Boolean Put(string cryptedId, [FromBody]Object value)
        {
            User user = new User();
            string id = des.Decrypt(cryptedId);
            string jsonValue = des.Decrypt(value.ToString());
            user = JsonConvert.DeserializeObject<User>(jsonValue);

            return this.userBusiness.UpdateUser(id, user);
        }

    }
}
