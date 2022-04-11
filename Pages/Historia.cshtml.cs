using dotNet2.Interfaces;
using dotNet2.Models;
using dotNet2.ViewModels.FizzBuzz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNet2.Pages
{
    [Authorize]
    public class HistoriaModel : PageModel
    {
        private readonly ILogger<HistoriaModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFizzBuzzService _FizzBuzzService;
        public List<FizzBuzzForListVM> List;
        public readonly FizzBuzzForListVM FizzBuzzLabels;
        public string currentUserId;

        public HistoriaModel(ILogger<HistoriaModel> logger, IFizzBuzzService FizzBuzzService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _FizzBuzzService = FizzBuzzService;
            _userManager = userManager;
        }
        public void OnGet()
        {
            List = _FizzBuzzService.GetAllEntries();
            currentUserId = _userManager.GetUserId(User);
        }

        public IActionResult OnPostAsync(int deleteId)
        {
            _FizzBuzzService.DeleteEntity(deleteId);
            List = _FizzBuzzService.GetAllEntries();
            currentUserId = _userManager.GetUserId(User);
            return Page();
        }
    }
}
