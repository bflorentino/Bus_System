using System.ComponentModel.DataAnnotations;

namespace Bus_System.Models.View
{
    public class DriversView
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }

        [Display(Name ="Fecha de contratación")]
        public string FechaContratado { get; set; }

        [Display(Name ="Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }
    }
}