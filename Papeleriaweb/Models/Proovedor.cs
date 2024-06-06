using System.ComponentModel.DataAnnotations;

namespace Papeleriaweb.Models
{
    public class Proovedor
    {
        [Key]
        public int Id_proveedor { get; set; }

        [Required(ErrorMessage = "El nombreproveedor es necesario")]
        public string Nombreproveedor { get; set; }

        [Required(ErrorMessage = "La direccion es necesario")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La Marca es necesario")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "La Tipoproducto es necesario")]
        public string Tipoproducto { get; set; }

        [Required(ErrorMessage = "La Cantidad es necesario")]
        public int Cantidad{ get; set; }

        [Required(ErrorMessage = "El preciounitario es necesario")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "El preciototal es necesario")]
        public decimal PrecioTotal { get; set; }

    }
}
