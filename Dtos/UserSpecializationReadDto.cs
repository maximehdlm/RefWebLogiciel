using System.ComponentModel.DataAnnotations;

namespace RefWebLogiciel.Dtos
{
    public class UserSpecializationReadDto
    {
        public int id_specialization  { get; set; }

        public string specialization_name { get; set; }
    }
}