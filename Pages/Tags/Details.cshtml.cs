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
    public class DetailsModel : PageModel
    {
        private readonly MyBlogWebsite.Data.MyBlogWebsiteContext _context;

        public DetailsModel(MyBlogWebsite.Data.MyBlogWebsiteContext context)
        {
            _context = context;
        }

        public Tag Tag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tag = await _context.Tag.FirstOrDefaultAsync(m => m.TagId == id);

            if (Tag == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
