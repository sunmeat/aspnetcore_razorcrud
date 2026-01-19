using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly StudentContext _context;

        public CreateModel(StudentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] // зручний спосіб прив'язки властивостей моделі до даних форми
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Students == null || Student == null)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}