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

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}