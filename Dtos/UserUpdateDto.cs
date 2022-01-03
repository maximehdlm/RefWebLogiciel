using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class UserUpdateDto
    {
        [Required]
         public int id_user  { get; set; }

         [Required]
         public string user_first_name { get; set; }

         [Required]
         public string user_last_name { get; set; }

         [Required]
         public string user_mail { get; set; }

         [Required]
         public string user_password { get; set; }

         [Required]
         public int user_xp { get; set; }

         [Required]
         public int fk_id_specialisation  { get; set; }
    }
}