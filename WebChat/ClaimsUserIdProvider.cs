using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Authentication;

namespace WebChat
{
    public class ClaimsUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            string userId = null;
            var identity = request.User.Identity as ChatUserIdentity;

            if (identity != null)
            {
                userId = identity.Id;
            }
            return userId;
        }
    }
}