using System.ComponentModel.DataAnnotations;

namespace dotNet2.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Twój szczęśliwy numerek"), Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int? Number { get; set; }
        public (string, string) getOutput()
        {
            string outputMessage = "", outputClass = "";
            if (Number % 3 == 0)
            {
                outputMessage += "Fizz";
                outputClass = "success";
            }
            if (Number % 5 == 0)
            {
                outputMessage += "Buzz";
                outputClass = "success";
            }
            if (outputMessage == "")
            {
                outputMessage = "Liczba: " + Number + " nie spełnia kryteriów FizzBuzz";
                outputClass = "warning";
            }
            return (outputMessage, outputClass);
        }
    }
}
