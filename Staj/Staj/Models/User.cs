using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }
    }
}