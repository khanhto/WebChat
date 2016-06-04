using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebChat.Authentication;
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
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.Name.ToString()));

                var id = new ClaimsIdentity(claims, "Cookies");
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(id);
            }
            else
            {
                //handle failed authentication requests later.
            }

            return user;
        }
    }
}
