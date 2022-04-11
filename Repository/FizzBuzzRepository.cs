using dotNet2.Data;
using dotNet2.Interfaces;
using dotNet2.Models;

namespace dotNet2.Repository
{
    public class FizzBuzzRepository : IFizzBuzzRepository
    {
        private readonly FizzBuzzContext _context;
        public FizzBuzzRepository(FizzBuzzContext context)
        {
            _context = context;
        }

        public IQueryable<FizzBuzz> GetAllEntries()
        {
            return _context.FizzBuzz;
        }

        public void AddToRepo(FizzBuzz fizzBuzz)
        {
            _context.FizzBuzz.Add(fizzBuzz);
            _context.SaveChanges();
        }
    }
}
