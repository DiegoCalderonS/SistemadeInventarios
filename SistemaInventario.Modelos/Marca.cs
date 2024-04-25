using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Marca
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="El campo Nombre es Requerido")]
        [MaxLength(60,ErrorMessage ="El nombre solo se compone de 60 caracteres como Maximo")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es Requerido")]
        [MaxLength(100, ErrorMessage = "La Descripcion solo se compone de 60 caracteres como Maximo")]
        public String Descripcion { get; set; }
        [Required(ErrorMessage ="El estado de la Marca es Requerido")]
        public bool Estado { get; set; }
    }
}
