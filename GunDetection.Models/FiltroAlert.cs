using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.Models
{
    public class FiltroAlert
    {
        public int Pag { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Camera { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string TypeAlert { get; set; }
        public Guid IdAccount { get; set; }
    }
}
