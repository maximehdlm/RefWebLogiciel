namespace RefWebLogiciel.Dtos
{
    public class UserReadDto
    {
         public int id_user  { get; set; }

         public string user_first_name { get; set; }

         public string user_last_name { get; set; }

         public string user_mail { get; set; }

         public string user_password { get; set; }

         public int user_xp { get; set; }

         public int fk_id_specialisation  { get; set; }
    }
}