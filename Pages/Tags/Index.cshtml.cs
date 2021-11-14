using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Data;
using MyBlogWebsite.Models;

namespace MyBlogWebsite.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly MyBlogWebsite.Data.MyBlogWebsiteContext _context;

        public IndexModel(MyBlogWebsite.Data.MyBlogWebsiteContext context)
        {
            _context = context;
        }

        public IList<Tag> Tag { get;set; }

        public async Task OnGetAsync()
        {
            Tag = await _context.Tag.ToListAsync();
        }
    }
}
