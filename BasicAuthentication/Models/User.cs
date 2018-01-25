using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Models
{
    public class User
    {
        public string Username { get; set; }
        public  string Password{ get; set; }
        public int UserId { get; set; }
    }
}