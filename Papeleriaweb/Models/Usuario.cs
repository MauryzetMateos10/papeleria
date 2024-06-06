using System.ComponentModel.DataAnnotations;

namespace Papeleriaweb.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "El nombre es necesario")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El usuario es necesario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es necesario")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Seleccionar que tipousuario eres, es necesario")]
        public string UserType { get; set; }
    }
}

