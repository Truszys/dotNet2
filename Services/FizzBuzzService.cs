using dotNet2.Interfaces;
using dotNet2.Models;
using dotNet2.ViewModels.FizzBuzz;

namespace dotNet2.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IFizzBuzzRepository _FizzBuzzRepo;
        public FizzBuzzService(IFizzBuzzRepository FizzBuzzRepo)
        {
            _FizzBuzzRepo = FizzBuzzRepo;
        }

        public List<FizzBuzzForListVM> GetAllEntries()
        {
            var EntriesList = _FizzBuzzRepo.GetAllEntries();
            List<FizzBuzzForListVM> Data = new List<FizzBuzzForListVM>();
            foreach (var entry in EntriesList)
            {
                var eVM = new FizzBuzzForListVM()
                {
                    Id = entry.Id,
                    FullName = entry.FirstName + " " + entry.LastName,
                    Year = entry.Year,
                    Date = entry.Date,
                    Result = entry.Result,
                };
                Data.Add(eVM);
            }
            return Data;
        }
        public void AddEntry(FizzBuzz newItem)
        {
            _FizzBuzzRepo.AddToRepo(newItem);
        }
        public List<FizzBuzzForListVM> GetEntriesFromToday()
        {
            var EntriesList = _FizzBuzzRepo.GetAllEntries().Where(item => item.Date.Date == DateTime.Today);
            List<FizzBuzzForListVM> Data = new List<FizzBuzzForListVM>();
            foreach (var entry in EntriesList)
            {
                var eVM = new FizzBuzzForListVM()
                {
                    Id = entry.Id,
                    FullName = entry.FirstName + " " + entry.LastName,
                    Year = entry.Year,
                    Date = entry.Date,
                    Result = entry.Result,
                };
                Data.Add(eVM);
            }
            return Data;
        }
    }
}
