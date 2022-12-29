using System;
using System.ComponentModel.DataAnnotations;

namespace Bus_System.Models.Binding_Models
{
    public class BusBinding
    {
        [Required(ErrorMessage ="Debe de registrar el nombre de la marca del Bus")]
        public string Marca { get; set; }

        [Required(ErrorMessage ="Debe de registrar el nombre del modelo del Bus")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Debe de registrar el año del Bus")]
        [Range(1990, Int32.MaxValue, ErrorMessage = "Año inválido")]

        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Display(Name = "Fecha de Compra")]
        [Required(ErrorMessage = "Seleccione la fecha en que el bus fue comprado")]
        public String Fecha_comprado { get; set; }

        [Required(ErrorMessage = "Debe de registrar la capacidad del Bus")]
        public int Capacidad { get; set; }

    }
}
