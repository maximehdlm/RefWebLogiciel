using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class ProjectTypeUpdateDto
    {
         [Required]
        public int id_project_type { get; set; }

        [Required]
        public string project_type_name { get; set; }
    }
}