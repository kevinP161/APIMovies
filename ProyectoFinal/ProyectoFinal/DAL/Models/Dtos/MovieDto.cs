using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres")]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "La Calsificacion en requerida")]
        [MaxLength(10, ErrorMessage = "La clasificacion no puede tener mas de 10 caracteres")]
        public string Clasification { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
