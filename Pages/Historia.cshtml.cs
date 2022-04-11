using dotNet2.Interfaces;
using dotNet2.ViewModels.FizzBuzz;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNet2.Pages
{
    public class HistoriaModel : PageModel
    {
        private readonly ILogger<HistoriaModel> _logger;
        private readonly IFizzBuzzService _FizzBuzzService;
        public List<FizzBuzzForListVM> List;
        public readonly FizzBuzzForListVM FizzBuzzLabels;

        public HistoriaModel(ILogger<HistoriaModel> logger, IFizzBuzzService FizzBuzzService)
        {
            _logger = logger;
            _FizzBuzzService = FizzBuzzService;
        }
        public void OnGet()
        {
            List = _FizzBuzzService.GetAllEntries();
        }
    }
}
