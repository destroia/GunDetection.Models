using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.Models
{
    public class Login
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
    public class CreatePassword
    {
        public Guid IdUser { get; set; }
        public string Password { get; set; }
    }
}
