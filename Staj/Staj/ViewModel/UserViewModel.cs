using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte rankId { get; set; }
    }
}