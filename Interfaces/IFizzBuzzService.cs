﻿using dotNet2.Models;
using dotNet2.ViewModels.FizzBuzz;

namespace dotNet2.Interfaces
{
    public interface IFizzBuzzService
    {
        public List<FizzBuzzForListVM> GetAllEntries();
        public void AddEntry(FizzBuzz newItem);
        public List<FizzBuzzForListVM> GetEntriesFromToday();
    }
}