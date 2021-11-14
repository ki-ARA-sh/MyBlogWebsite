using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Data;
using MyBlogWebsite.Models;

namespace MyBlogWebsite.Pages.BlogPosts
{
    public class IndexModel : PageModel
    {
        private readonly MyBlogWebsite.Data.MyBlogWebsiteContext _context;

        public IndexModel(MyBlogWebsite.Data.MyBlogWebsiteContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Post
                .Include(p => p.PostAuthor)
                .Include(p => p.PostTag).ToListAsync();
        }
    }
}
