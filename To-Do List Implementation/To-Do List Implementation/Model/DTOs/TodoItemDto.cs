using System.ComponentModel.DataAnnotations;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Model.DTOs
{
    public class TodoItemDto
    {
        [Required]
        public string title { get; set; }
        public string description { get; set; }
    }
}
