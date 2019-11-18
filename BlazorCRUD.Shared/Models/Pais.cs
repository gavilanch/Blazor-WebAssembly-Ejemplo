using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCRUD.Shared.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estado> Estados { get; set; }
    }
}
