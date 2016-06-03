using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebChat.Repository;
using System.Threading.Tasks;
using WebChat.Models;
using System.Threading;

namespace WebChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUsersRepository UserRepository;

        public ChatHub(IUsersRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Send(ChatMessage message)
        {
            Clients.User(message.UserId.ToString()).onMessageReceived(new ChatMessage()
            {
                UserId = int.Parse(Context.User.Identity.Name),
                Message = message.Message
            });
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}