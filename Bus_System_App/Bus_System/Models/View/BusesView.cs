using System.ComponentModel.DataAnnotations;

namespace Bus_System.Models.View

{
    public class BusesView
    {
        public int Capacidad {  get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Display(Name = "Fecha de Compra")]
        public string FechaComprado { get; set; }
    }
}
