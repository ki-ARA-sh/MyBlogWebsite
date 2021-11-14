using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebsite.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string PostText { get; set; }
        public DateTime DatePublished { get; set; }
        public Author PostAuthor { get; set; }

        public int AuthorId { get; set; }
        public Tag PostTag { get; set; }

        public int TagId { get; set; }
    }
}
