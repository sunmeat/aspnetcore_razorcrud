using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StudentContext _context;

        public IndexModel(StudentContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }

        // щоб побачити сортування за віком, треба додати до URL сторінки Index наступне: ?handler=ByAge
        // https://localhost:7079/?handler=ByAge
        // <a asp-page-handler="ByAge">Відсортувати за віком</a>
        public async Task OnGetByAge()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.OrderBy(s => s.Age).ToListAsync();
            }
        }
    }
}