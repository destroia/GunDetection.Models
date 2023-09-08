using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.Models
{
    public class UserAlarm
    {
        public Guid   Id { get; set; }
        public Guid   IdAccount { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool  Figth          { get; set; }
        public bool GunDetected     { get; set; }
        public bool PersonDetection { get; set; }
        public bool HandsUp         { get; set; }
       
    }
}
