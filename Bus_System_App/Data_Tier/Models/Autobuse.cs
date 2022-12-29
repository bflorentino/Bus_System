using System;
using System.Collections.Generic;

#nullable disable

namespace Data_Tier.Models
{
    public partial class Autobuse
    {
        public Autobuse()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdAutobus { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public int Capacidad { get; set; }
        public DateTime FechaAdquisicion { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
