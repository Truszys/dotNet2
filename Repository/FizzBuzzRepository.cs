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
            return _context.FizzBuzz.OrderByDescending(item => item.Date);
        }

        public void AddToRepo(FizzBuzz fizzBuzz)
        {
            _context.FizzBuzz.Add(fizzBuzz);
            _context.SaveChanges();
        }
        
        public void DeleteEntity(int delId)
        {
            var FizzBuzz = _context.FizzBuzz.Find(delId);
            if (FizzBuzz != null)
            {
                _context.FizzBuzz.Remove(FizzBuzz);
                _context.SaveChanges();
            }
        }

#pragma warning disable CS8602
        public bool IsOwner(string uid, int id)
        {
            if (_context.FizzBuzz.Find(id) != null && _context.FizzBuzz.Find(id).UId == uid)
                return true;
            return false;
        }
#pragma warning restore CS8602
    }
}
