using dotNet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dotNet2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        
        [BindProperty(SupportsGet = true), FromQuery]
        public string? Name { get; set; }
        
        [TempData]
        public string Message { get; set; }

        public List<FizzBuzz>? List { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            Message = "";
        }
        public IActionResult OnPost()
        {
            Message = "";
            if (List == null)
                List = new List<FizzBuzz>();
            if (ModelState.IsValid)
            {
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                    List = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);
                else
                    List = new List<FizzBuzz>();
                if(!List.Any(item => item.Name == FizzBuzz.Name && item.Year == FizzBuzz.Year))
                    List.Add(FizzBuzz);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(List));
                Message += FizzBuzz.Name;
                if(FizzBuzz.Name.Last() == 'a' && FizzBuzz.Name.ToLower() != "kuba")
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
            }
            return Page();
        }
    }
}