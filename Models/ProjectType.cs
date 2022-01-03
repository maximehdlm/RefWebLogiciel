using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Models
{
    //je crée mon objet Project avec ses proprietés
    public class ProjectType
    {
        [Key]
        [Required]
        public int id_project_type { get; set; }

        [Required]
        public string project_type_name { get; set; }
    }
}