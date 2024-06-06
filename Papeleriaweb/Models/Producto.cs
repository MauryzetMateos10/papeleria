using System.ComponentModel.DataAnnotations;
namespace Papeleriaweb.Models
{
    public class Producto
    {
        [Key]
        public int Id_producto { get; set; }

        [Required(ErrorMessage = "El nombreproducto es necesario")]
        public string Nombreproducto { get; set; }

        [Required(ErrorMessage = "El marcaproducto es necesario")]
        public string Marcaproducto { get; set; }

        [Required(ErrorMessage = "La descripcion es necesario")]
        public string Descripcionproducto { get; set; }

        [Required(ErrorMessage = "El precio es necesario")]
        public decimal Precioproducto { get; set; }

        [Required(ErrorMessage = "El stock es necesario")]
        public int Stockproducto { get; set; }

        [Required(ErrorMessage = "El tamaño es necesario")]
        public string Tamañoproducto { get; set; }

        [Required(ErrorMessage = "El color es necesario")]
        public string Colorproducto { get; set; }

        [Required(ErrorMessage = "El tipoproducto es necesario")]
        public string Tipoproducto { get; set; }

    }
}
