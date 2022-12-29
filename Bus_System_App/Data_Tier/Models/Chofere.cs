using System;
using System.Collections.Generic;

#nullable disable

namespace Data_Tier.Models
{
    public partial class Chofere
    {
        public Chofere()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdChofer { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaContratado { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
