using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly StudentContext _context;

        public EditModel(StudentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student =  await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentFromDb = await _context.Students.FindAsync(Student.Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            studentFromDb.Name = Student.Name;
            studentFromDb.Surname = Student.Surname;
            studentFromDb.Age = Student.Age;
            studentFromDb.GPA = Student.GPA;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}