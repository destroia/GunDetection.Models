using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.Models
{
    public class AlerApiEx
    {
        public string Category { get; set; }
        public string Name_alarm { get; set; }
        public string Msg { get; set; }
        public string Mimetype { get; set; }
        public string Filename { get; set; }
        public string Video { get; set; }
        public string Full_photo  { get; set; }
        public DateTime Date { get; set; }

    }
}
