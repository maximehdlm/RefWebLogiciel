using System.ComponentModel.DataAnnotations;
using RefWebLogiciel.Dtos;

namespace RefWebLogiciel.Models
{
    public class Project
    {
        [Key]
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