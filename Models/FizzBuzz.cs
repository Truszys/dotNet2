using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNet2.Models
{
    public class FizzBuzz
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Rok")] 
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakredu {1} i {2}.")]
        [Required(ErrorMessage = "Pole jest obowiązkowe!")]
        public int Year { get; set; }

        [Display(Name = "Imię")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "W imieniu powinny być tylko litery")]
        [StringLength(100, ErrorMessage = "Maksymalna długość to 100")]
        [Required(ErrorMessage = "Pole jest obowiązkowe!")]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "W nazwisku powinny być tylko litery")]
        [StringLength(100, ErrorMessage = "Maksymalna długość to 100")]
        [Column(TypeName = "varchar(100)")]
        public string? LastName { get; set; }

        [Display(Name = "Data")]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Display(Name = "Wynik")]
        [Column(TypeName = "varchar(300)")]
        public string? Result { get; set; }

        [Column(TypeName = "NVARCHAR(450)")]
        public string? UId { get; set; }

        public bool IsLeap()
        {
            if(Year % 4 == 0 && (Year % 100 != 0 || Year % 400 == 0))
                return true;
            return false;
        }

        public int GetId()
        {
            return Id;
        }
    }
}
