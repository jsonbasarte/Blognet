using System.ComponentModel.DataAnnotations;

namespace Blognet.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
