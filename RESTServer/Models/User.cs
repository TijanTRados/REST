using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public String Proffesion { get; set; }

    }
}