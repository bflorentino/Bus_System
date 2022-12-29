using System.ComponentModel.DataAnnotations;
using System;

namespace Bus_System.Models.BindingModel
{
    public class DriverBinding
    {
        [Required (ErrorMessage ="La cedula del chofer es requerida")]
        [StringLength(11, MinimumLength =11, ErrorMessage ="Cedula de identidad inválida")]
        [RegularExpression("[0-9]{11}", ErrorMessage ="Patrón de cédula inválido. Asegurese de no usar guiones")]
        [Display(Name ="Cedula (sin guiones)")]
        public string Cedula { get; set; }
    
        [Required (ErrorMessage ="Se requiere agregar el nombre del chofer")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Se requiere agregar el apellido del chofer")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Favor de agregar su fecha de nacimiento")]
        public string FechaNacimiento { get; set; }

        public string FechaContratado { get; set; } = DateTime.Now.ToString();

    }
}
