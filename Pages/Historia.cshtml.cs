using dotNet2.Data;
using dotNet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNet2.Pages
{
    public class HistoriaModel : PageModel
    {
        private readonly ILogger<HistoriaModel> _logger;
        private readonly FizzBuzzContext _context;
        public FizzBuzz FizzBuzz { get; set; }

        public HistoriaModel(ILogger<HistoriaModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzzData { get; set; }
        public void OnGet()
        {
            if(_context != null)
                FizzBuzzData = _context.FizzBuzz.OrderByDescending(p => p.Date).Take(20).ToList();
        }

        public IActionResult OnPostAsync(int deleteId)
        {
            FizzBuzz = _context.FizzBuzz.Find(deleteId);
            if (FizzBuzz != null)
            {
                _context.FizzBuzz.Remove(FizzBuzz);
                _context.SaveChanges();
            }
            if (_context != null)
                FizzBuzzData = _context.FizzBuzz.OrderByDescending(p => p.Date).Take(20).ToList();
            return Page();
        }
    }
}
