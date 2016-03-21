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
        IList<User> GetAll();
        IList<User> GetByName(string nameQuery);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly IList<User> allUsers = new List<User>()
        {
            new User() {
                    Id = 1,
                    Name = "Khanh"
                },
                new User() {
                    Id = 2,
                    Name = "Tung"
                },
                new User() {
                    Id = 3,
                    Name = "Khang"
                }
        };

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

        public IList<User> GetAll()
        {
            return allUsers;
        }

        public IList<User> GetByName(string nameQuery)
        {
            return allUsers;
        }
    }
}