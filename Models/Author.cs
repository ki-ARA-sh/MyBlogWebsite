using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebsite.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
