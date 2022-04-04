using dotNet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using dotNet2.Data;

namespace dotNet2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;

        public IList<FizzBuzz> FizzBuzzData { get; set; }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        
        [BindProperty(SupportsGet = true), FromQuery]
        public string? Name { get; set; }
        
        [TempData]
        public string Message { get; set; }

        public List<FizzBuzz>? List { get; set; }
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void OnGet()
        {
            Message = "";
            FizzBuzzData = _context.FizzBuzz.ToList();
        }
        public IActionResult OnPost()
        {
            Message = "";
            if (List == null)
                List = new List<FizzBuzz>();
            FizzBuzz.Date = DateTime.Now;
            FizzBuzz.Result = "";
            if (ModelState.IsValid)
            {
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                    List = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);
                else
                    List = new List<FizzBuzz>();
                if(!List.Any(item => item.FirstName == FizzBuzz.FirstName && 
                                     item.LastName == FizzBuzz.LastName && item.Year == FizzBuzz.Year))
                    List.Add(FizzBuzz);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(List));
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
                _context.FizzBuzz.Add(FizzBuzz);
                _context.SaveChanges();
            }
            return Page();
        }
    }
}