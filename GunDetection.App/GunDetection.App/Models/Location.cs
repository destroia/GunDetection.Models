using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.App.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Name { get; set; }
    }
}
