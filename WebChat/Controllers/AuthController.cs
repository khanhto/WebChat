using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebChat.Repository;

namespace WebChat.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUsersRepository UserRepository;

        public AuthController(IUsersRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpGet]
        public void Login(string username, string password)
        {
            WebChat.Models.User user = UserRepository.GetUser(username, password);
            if (user != null)
            {
                //temporarily using Forms authentication, will replace with another mechanism
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
            }
            else
            {
                //handle failed authentication requests later.
            }
        }
    }
}
