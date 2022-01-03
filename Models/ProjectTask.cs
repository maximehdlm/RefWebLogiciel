using System.ComponentModel.DataAnnotations;


namespace RefWebLogiciel.Models
{

    public class ProjectTask
    {
         [Key] 
        [Required]
        public int id_task  { get; set; }

        [Required]
        public string task_name { get; set; }

        [Required]
        public string task_description { get; set; }

        [Required]
        public int task_time { get; set; }

        [Required]
        public string task_status { get; set; }

        [Required]
        public int task_xp { get; set; }

        public int fk_id_task_type  { get; set; }

        public int fk_id_user  { get; set; }

        public int fk_id_project  { get; set; }


    }
}