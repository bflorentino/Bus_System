using System;
using System.Collections.Generic;

#nullable disable

namespace Data_Tier.Models
{
    public partial class Parada
    {
        public Parada()
        {
            ViajeIdPuntoLlegadaNavigations = new HashSet<Viaje>();
            ViajeIdPuntoSalidaNavigations = new HashSet<Viaje>();
        }

        public int IdParada { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Calle { get; set; }
        public string NombreParada { get; set; }

        public virtual ICollection<Viaje> ViajeIdPuntoLlegadaNavigations { get; set; }
        public virtual ICollection<Viaje> ViajeIdPuntoSalidaNavigations { get; set; }
    }
}
