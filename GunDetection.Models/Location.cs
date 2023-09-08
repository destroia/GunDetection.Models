using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GunDetection.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Name { get; set; }

        [ForeignKey("IdLocation")]
        public ICollection<SubLocation> SubLocations { get; set; }
        [ForeignKey("IdLocation")]
        public ICollection<Camera> Cameras { get; set; }
    }
}
