using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class ProjectReadDto
    {
        public int id_project { get; set; }

        public string project_name { get; set; }

        public string project_description { get; set; }

        public string start_date_time { get; set; }
        
        public string end_date_time { get; set; }

        public int fk_id_project_type { get; set; }

    }
}