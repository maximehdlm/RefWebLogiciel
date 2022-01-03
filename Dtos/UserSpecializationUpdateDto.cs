using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class UserSpecializationUpdateDto
    {
        [Required]
        public int id_specialization  { get; set; }

        [Required]
        public string specialization_name { get; set; }
    }
}