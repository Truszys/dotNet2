using System.ComponentModel.DataAnnotations;

namespace dotNet2.ViewModels.FizzBuzz
{
    public class FizzBuzzForListVM
    {
        public int Id { get; set; }

        [Display(Name = "Imię i nazwisko")]
        public string FullName { get; set; }

        [Display(Name = "Rok")]
        public int Year { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime Date { get; set; }

        [Display(Name = "Wynik")]
        public string? Result { get; set; }

        public string? UId { get; set; }
    }
}
