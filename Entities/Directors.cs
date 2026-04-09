using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace movieArchieve.Entities
{
    public class Directors
    {
        [Key]
        public int directorID { get; set; }

        [Required]

        public string fullName { get; set; }
        public int age { get; set; }

        public double rating { get; set; }


    }
}
