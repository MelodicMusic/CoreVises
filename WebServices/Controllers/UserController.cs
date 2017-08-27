using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Business;
using Newtonsoft.Json;

namespace WebServices.Controllers
{
    public class UserController : ApiController
    {

        UserBusiness userBusiness = new UserBusiness();

        
        // POST: api/User
        public User Post([FromBody]Object value)
        {
            User user = new Domain.User();
            user = JsonConvert.DeserializeObject<User>(value.ToString());
            
            return this.userBusiness.SignUp(user);
        }


        // GET: api/User/LogIn/email/password
        [HttpGet]
        [Route("api/User/LogIn/{email}/{password}")]
        public User LogIn(string email, string password)
        {
            return this.userBusiness.LogIn(email, password);
        }

        
        // PUT: api/User/value
        public Boolean Put(string id, [FromBody]Object value)
        {
            User user = new User();
            user = JsonConvert.DeserializeObject<User>(value.ToString());

            return this.userBusiness.UpdateUser(id, user);
        }
       
    }
}
