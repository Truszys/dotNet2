using dotNet2.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNet2.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext(DbContextOptions options) : base(options) { }
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}
