using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.App.Models
{
    public class Camera
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdLocation { get; set; }
        public Guid IdSubLocation { get; set; }
        public string Name { get; set; }

        
        public string Location { get; set; }
        
        public string SubLocation { get; set; }
    }
}
