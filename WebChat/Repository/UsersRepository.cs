using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Models;

namespace WebChat.Repository
{
    public interface IUsersRepository
    {
        IList<User> GetFriends(int userId);
    }

    public class UsersRepository : IUsersRepository
    {
        public IList<User> GetFriends(int userId)
        {
            return new List<User>()
            {
                new User() {
                    Id = 1,
                    Name = "Khanh"
                },
                new User() {
                    Id = 2,
                    Name = "Tung"
                }
            };
        }
    }
}