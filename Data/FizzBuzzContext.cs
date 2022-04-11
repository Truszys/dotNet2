using dotNet2.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNet2.Data
{
    public class FizzBuzzContext : DbContext
    {
#pragma warning disable CS8618
        public FizzBuzzContext(DbContextOptions<FizzBuzzContext> options) : base(options) { }
#pragma warning restore CS8618
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}
