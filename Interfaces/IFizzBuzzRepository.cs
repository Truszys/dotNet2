using dotNet2.Models;

namespace dotNet2.Interfaces
{
    public interface IFizzBuzzRepository
    {
        IQueryable<FizzBuzz> GetAllEntries();
        void AddToRepo(FizzBuzz fizzBuzz);
    }
}
