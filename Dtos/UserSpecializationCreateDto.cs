using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class UserSpecializationCreateDto
    {
        [Required]
        public string specialization_name { get; set; }
    }
}