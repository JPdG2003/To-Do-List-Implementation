using System.ComponentModel.DataAnnotations;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Model.DTOs
{
    public class UserDto
    {
        [Required]
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string address { get; set; }
    }
}
