using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookManager.Models
{
    public partial class BookManagerContext : DbContext
    {
        public BookManagerContext()
            : base("name=BookManagerContext")
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public object Books { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
