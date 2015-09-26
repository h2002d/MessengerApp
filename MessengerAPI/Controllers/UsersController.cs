using MessengerServiceLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MessengerAPI.Controllers
{
    public class UsersController : ApiController
    {

        private static MessengerServiceLibrary.MessengerService mUser = new MessengerServiceLibrary.MessengerService();
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult Login(string userName, string password)
        {
            User user = mUser.Login(userName, password);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ResponseType(typeof(int))]
        public IHttpActionResult Register([FromBody] User user)
        {
            bool result = mUser.Register(user);
            if (result == false)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [ResponseType(typeof(int))]
        public IHttpActionResult UserNameExists(string username)
        {
            bool result = mUser.UserNameExists(username);
            if (result == false)
            {
                return NotFound();
            }

            return Ok(username);
            
        }
    }
}
