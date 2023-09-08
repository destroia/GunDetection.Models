using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GunDetection.Models
{
    public  class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool Activate { get; set; }
        public Guid Account { get; set; }

        [ForeignKey("IdUser")]
        public ICollection<Location> Locations { get; set; }
        //[ForeignKey("IdAccount")]
        //public ICollection<UserAlarm> UserAlarms { get; set; }

    }
}
