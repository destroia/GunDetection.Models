using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.Data.Helpers.Filter
{
    public class Paginacion
    {
        public int Pagina { set; get; } = 1;
        public int CantidadMostrar { get; set; } = 20;
    }
}
