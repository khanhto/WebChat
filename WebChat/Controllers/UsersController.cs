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

        public IEnumerable<User> GetFriends()
        {
            return UserRepository.GetFriends(1);
        }

        public IEnumerable<User> GetAll(int id)
        {
            return UserRepository.GetAll();
        }

        public IEnumerable<User> GetByName(string nameQuery)
        {
            return UserRepository.GetByName(nameQuery);
        }
    }
}
