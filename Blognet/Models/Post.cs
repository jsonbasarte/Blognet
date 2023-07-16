using Blognet.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Blognet.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }  
        public string Content { get; set; }
        public string Thumbnail { get; set; }

        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
     

    }
}
