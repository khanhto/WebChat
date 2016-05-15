using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class ChatMessage
    {
        [JsonProperty("userid")]
        public int UserId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}