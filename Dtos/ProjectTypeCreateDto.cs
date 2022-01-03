using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class ProjectTypeCreateDto
    {
        [Required]
        public string project_type_name { get; set; }
    }
}