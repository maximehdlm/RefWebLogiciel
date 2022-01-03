using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Models
{
    public class UserSpecialization
    {
        [Key]
        [Required]
        public int id_specialization  { get; set; }

        [Required]
        public string specialization_name { get; set; }
    }
}