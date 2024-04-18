using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TPMoraCapdevila1.Entities;

namespace TPMoraCapdevila1.Data.Entities
{
    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTodoItem { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }
        
        
    }
}
