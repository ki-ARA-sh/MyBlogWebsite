using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Data;
using MyBlogWebsite.Models;

namespace MyBlogWebsite.Pages.BlogPosts
{
    public class EditModel : PageModel
    {
        private readonly MyBlogWebsite.Data.MyBlogWebsiteContext _context;

        public EditModel(MyBlogWebsite.Data.MyBlogWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorId");
           ViewData["TagId"] = new SelectList(_context.Tag, "TagId", "TagId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.AuthorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.AuthorId == id);
        }
    }
}
