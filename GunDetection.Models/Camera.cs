using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GunDetection.Models
{
    public class Camera
    {
        public Guid  Id { get; set; }
        public Guid  IdUser  { get; set; }
        public Guid  IdLocation { get; set; }
        public Guid  IdSubLocation { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public string Location { get; set; }
        [NotMapped]
        public string SubLocation { get; set; }

    }
}
