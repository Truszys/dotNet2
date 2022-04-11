using System.ComponentModel.DataAnnotations;

namespace dotNet2.ViewModels.FizzBuzz
{
    public class FizzBuzzForListVM
    {
        public int Id { get; set; }

        [Display(Name = "Imię i nazwisko")]
#pragma warning disable CS8618
        public string FullName { get; set; }
#pragma warning restore CS8618

        [Display(Name = "Rok")]
        public int Year { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime Date { get; set; }

        [Display(Name = "Wynik")]
        public string? Result { get; set; }

        public string? UId { get; set; }
    }
}
