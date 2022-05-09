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

        private List<FizzBuzzForListVM> DataToList(IQueryable<FizzBuzz> Data)
        {
            List<FizzBuzzForListVM> List = new List<FizzBuzzForListVM>();
            foreach (var entry in Data)
            {
                var eVM = new FizzBuzzForListVM()
                {
                    Id = entry.Id,
                    FullName = entry.FirstName + " " + entry.LastName,
                    Year = entry.Year,
                    Date = entry.Date,
                    Result = entry.Result,
                    UId = entry.UId,
                };
                List.Add(eVM);
            }
            return List;
        }

        public List<FizzBuzzForListVM> GetAllEntries()
        {
            var EntriesList = _FizzBuzzRepo.GetAllEntries();
            return DataToList(EntriesList);
        }

        public List<FizzBuzzForListVM> GetLast20Entries()
        {
            var EntriesList = _FizzBuzzRepo.GetAllEntries().Take(20);
            return DataToList(EntriesList);
        }
        public void AddEntry(FizzBuzz newItem)
        {
            _FizzBuzzRepo.AddToRepo(newItem);
        }
        public List<FizzBuzzForListVM> GetEntriesFromToday()
        {
            var EntriesList = _FizzBuzzRepo.GetAllEntries().Where(item => item.Date.Date == DateTime.Today);
            return DataToList(EntriesList);
        }
        public void DeleteEntity(int delId)
        {
            _FizzBuzzRepo.DeleteEntity(delId);
        }

        public bool IsOwner(string uid, int id)
        {
            return _FizzBuzzRepo.IsOwner(uid, id);
        }
    }
}
