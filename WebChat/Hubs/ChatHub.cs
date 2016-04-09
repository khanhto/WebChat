using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebChat.Repository;
using System.Threading.Tasks;

namespace WebChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUsersRepository UserRepository;

        public ChatHub(IUsersRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Send(string userId, string message)
        {
            Clients.User(userId).addNewMessageToPage(message);
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}