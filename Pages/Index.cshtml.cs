using dotNet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotNet2.Interfaces;
using dotNet2.ViewModels.FizzBuzz;

namespace dotNet2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFizzBuzzService _FizzBuzzService;
        public List<FizzBuzzForListVM> List;
        public FizzBuzzForListVM FizzBuzzForListVM;


        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        
        [BindProperty(SupportsGet = true), FromQuery]
        public string? Name { get; set; }
        
        [TempData]
        public string Message { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IFizzBuzzService FizzBuzzService)
        {
            _logger = logger;
            _FizzBuzzService = FizzBuzzService;
        }
        public void OnGet()
        {
            List = _FizzBuzzService.GetEntriesFromToday();
            Message = "";
        }
        public IActionResult OnPost()
        {
            Message = "";
            FizzBuzz.Date = DateTime.Now;
            FizzBuzz.Result = "";
            if (ModelState.IsValid)
            {
                Message += FizzBuzz.FirstName;
                if(FizzBuzz.LastName != null)
                {
                    Message += " "+FizzBuzz.LastName;
                }
                if(FizzBuzz.FirstName.Last() == 'a' && FizzBuzz.FirstName.ToLower() != "kuba")
                {
                    Message += " urodziła się w " + FizzBuzz.Year + " roku. To ";
                }
                else
                {
                    Message += " urodził się w " + FizzBuzz.Year + " roku. To ";
                }
                if (!FizzBuzz.IsLeap())
                {
                    Message += "nie ";
                }
                Message += "był rok przystępny.";
                FizzBuzz.Result = Message;
                _FizzBuzzService.AddEntry(FizzBuzz);
            }
            List = _FizzBuzzService.GetEntriesFromToday();
            return Page();
        }
    }
}