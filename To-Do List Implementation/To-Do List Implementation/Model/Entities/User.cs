using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do_List_Implementation.Model.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_user { get; set; }
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string address { get; set; }

        public ICollection<TodoItem> TodoItems { get; set; }
    }
}
