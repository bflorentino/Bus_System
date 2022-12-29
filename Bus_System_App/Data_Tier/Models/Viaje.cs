using System;
using System.Collections.Generic;

#nullable disable

namespace Data_Tier.Models
{
    public partial class Viaje
    {
        public int IdViaje { get; set; }
        public int IdPuntoSalida { get; set; }
        public int IdPuntoLlegada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public TimeSpan? HoraEstimadaLlegada { get; set; }
        public int IdAutobus { get; set; }
        public int IdChofer { get; set; }
        public string StatusViaje { get; set; }

        public virtual Autobuse IdAutobusNavigation { get; set; }
        public virtual Chofere IdChoferNavigation { get; set; }
        public virtual Parada IdPuntoLlegadaNavigation { get; set; }
        public virtual Parada IdPuntoSalidaNavigation { get; set; }
    }
}
