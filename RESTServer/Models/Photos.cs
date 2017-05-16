using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServer.Models
{
    public class Photos
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Name { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Size { get; set; }
        public DateTime Date { get; set; }
    }
}