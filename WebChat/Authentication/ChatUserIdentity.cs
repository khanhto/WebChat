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

        public int Id
        {
            get
            {
                string id = GetClaimValue(ClaimTypes.NameIdentifier);

                return !string.IsNullOrEmpty(id) ? int.Parse(id) : 0;
            }
        }

        private string GetClaimValue(string claimType)
        {
            var claim = this.FindFirst(claimType);
            return claim != null ? claim.Value : string.Empty;
        }
    }
}