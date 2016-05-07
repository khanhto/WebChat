using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebChat.Models;
using WebChat.Repository;
using WebChat.Requests;

namespace WebChat.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUsersRepository UserRepository;

        public AuthController(IUsersRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpPost]
        public User Login(LoginRequest request)
        {
            WebChat.Models.User user = UserRepository.GetUser(request.Username, request.Password);
            if (user != null)
            {
                //temporarily using Forms authentication, will replace with another mechanism
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
            }
            else
            {
                //handle failed authentication requests later.
            }

            return user;
        }
    }
}
