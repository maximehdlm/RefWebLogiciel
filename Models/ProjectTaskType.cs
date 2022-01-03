using System.ComponentModel.DataAnnotations;
using RefWebLogiciel.Dtos;


namespace RefWebLogiciel.Models
{
    public class ProjectTaskType
    {
        [Key]
        [Required]
        public int id_task_type  { get; set; }

        [Required]
        public string task_type_name { get; set; }

        [Required]
        public string description { get; set; }


    }
}