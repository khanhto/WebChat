using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebChat.Models;
using WebChat.Repository;

namespace WebChat.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersRepository UserRepository;

        public UsersController(IUsersRepository userRepository)
        {
            UserRepository = userRepository;
        }
        // GET api/users
        public IEnumerable<User> GetFriends()
        {
            return UserRepository.GetFriends(1);
        }

        // GET api/users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
