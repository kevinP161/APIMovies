using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required]
        [Display(Name = "Nombre de la Categoria")]
        public string Name { get; set; }

    }
}
