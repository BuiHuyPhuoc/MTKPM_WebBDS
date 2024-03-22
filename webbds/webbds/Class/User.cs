using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webbds.Models;

namespace webbds.Class
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string VerifiedEmail { get; set; }
        public string MobilePhone { get; set; }
        public string Locate { get; set; }
    }
}