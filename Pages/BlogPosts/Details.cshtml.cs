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
    public class DetailsModel : PageModel
    {
        private readonly MyBlogWebsite.Data.MyBlogWebsiteContext _context;

        public DetailsModel(MyBlogWebsite.Data.MyBlogWebsiteContext context)
        {
            _context = context;
        }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Post
                .Include(p => p.PostAuthor)
                .Include(p => p.PostTag).FirstOrDefaultAsync(m => m.AuthorId == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
