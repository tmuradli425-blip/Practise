using System.ComponentModel.DataAnnotations;

namespace Practise.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Member> Members { get; set; }
    }
}
