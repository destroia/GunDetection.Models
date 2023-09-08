using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GunDetection.Models
{
    public class Alert
    {
        public Guid Id { get; set; }
        public Guid IdAccount { get; set; }
        public Guid IdUser { get; set; }
        public string Status   { get; set; } = "";
        public string Category  { get; set; }
        public string Full_photo { get; set; }
        public string Mimetype   { get; set; }
        public string Filename   { get; set; }
        public string Name_alarm { get; set; }
        public DateTime Date     { get; set; }
        public string Msg  { get; set; }
        public string Clip { get; set; }

        [NotMapped]
        public string NameUser { get; set; }
        [NotMapped]
        public string EmailUser { get; set; }
        

    }
}
