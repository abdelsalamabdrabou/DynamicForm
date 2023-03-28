using DynamicForm.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<InputComponent> InputComponents { get; set; }
        public DbSet<InputValue> InputValues { get; set; }
    }
}
