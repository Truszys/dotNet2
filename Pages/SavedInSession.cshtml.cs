using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotNet2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



namespace dotNet2.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<FizzBuzz>? List { get; set; }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                List = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);
                HttpContext.Session.SetString("Data", Data);
            }
        }
    }
}
