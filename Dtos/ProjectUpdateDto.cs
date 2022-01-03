using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class ProjectUpdateDto
    {
        [Required]
        public int id_project { get; set; }

        [Required]
        public string project_name { get; set; }

        [Required]
        public string project_description { get; set; }

        [Required]
        public string start_date_time { get; set; }
        
        [Required]
        public string end_date_time { get; set; }

        [Required]
        public int fk_id_project_type { get; set; }
    }
}