using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace WebChat.Authentication
{
    public class ChatUserIdentity : ClaimsIdentity
    {
        public ChatUserIdentity(IIdentity identity) : base(identity)
        {
        }

        public ChatUserIdentity(IEnumerable<Claim> claims, string authenticationType) : base(claims,authenticationType)
        {
        }

        public string Id
        {
            get
            {
                string id = null;
                var claim = this.FindFirst(ClaimTypes.NameIdentifier);
                if (claim != null)
                {
                    id = claim.Value;
                }

                return id;
            }
        }
    }
}