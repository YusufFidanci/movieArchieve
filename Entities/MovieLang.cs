using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieArchieve.Entities
{
    public class MovieLang
    {
        [Key]
        public int languageID { get; set; }

        [Required]
        public string langName { get; set; }
        public ICollection<Movie>? Movies { get; set; }
        
    }
}
