using dotNet2.Models;
using dotNet2.ViewModels.FizzBuzz;

namespace dotNet2.Interfaces
{
    public interface IFizzBuzzService
    {
        public List<FizzBuzzForListVM> GetAllEntries();
        public List<FizzBuzzForListVM> GetLast20Entries();
        public void AddEntry(FizzBuzz newItem);
        public List<FizzBuzzForListVM> GetEntriesFromToday();
        public void DeleteEntity(int delId);
    }
}
