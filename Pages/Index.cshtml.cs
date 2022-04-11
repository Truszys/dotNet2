using dotNet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotNet2.Interfaces;
using dotNet2.ViewModels.FizzBuzz;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using dotNet2.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace dotNet2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFizzBuzzService _FizzBuzzService;
        private readonly UserManager<IdentityUser> _userManager;
        public List<FizzBuzzForListVM> List;
        public FizzBuzzForListVM FizzBuzzForListVM;
        public string currentUserId;


        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        
        [BindProperty(SupportsGet = true), FromQuery]
        public string? Name { get; set; }
        
        [TempData]
        public string Message { get; set; }
        public IndexModel(ILogger<IndexModel> logger, 
            IFizzBuzzService FizzBuzzService,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _FizzBuzzService = FizzBuzzService;
            _userManager = userManager;
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
                FizzBuzz.UId = _userManager.GetUserId(User);
                _FizzBuzzService.AddEntry(FizzBuzz);
            }
            List = _FizzBuzzService.GetEntriesFromToday();
            return Page();
        }
    }
}