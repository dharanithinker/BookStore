using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class UserInfo
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime Expiresin { get; set; }
    }
}
