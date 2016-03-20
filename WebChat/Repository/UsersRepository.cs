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
        IList<User> SearchByName(string nameQuery);
        User GetUser(string username, string password);
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

        public IList<User> SearchByName(string nameQuery)
        {
            return allUsers;
        }


        public User GetUser(string username, string password)
        {
            return allUsers.FirstOrDefault(user => string.CompareOrdinal(user.Name, username) == 0);
        }
    }
}