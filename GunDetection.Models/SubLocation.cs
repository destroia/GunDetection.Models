using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GunDetection.Models
{
    public class SubLocation
    {
        public Guid Id { get; set; }
        public Guid IdLocation { get; set; }
        public string Name { get; set; }

        [ForeignKey("IdSubLocation")]
        public ICollection<Camera> Cameras { get; set; }
    }
}
