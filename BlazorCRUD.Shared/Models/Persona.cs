using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorCRUD.Shared.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
    }
}
