using Microsoft.EntityFrameworkCore;

namespace GiftCodeManager.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Usedbarcode_Customer>().HasKey(e => new { e.Customer_Id, e.Barcode_Id });

            model.Entity<Winner>().HasKey(e => new { e.Customer_Id, e.Gift_Id });
        }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Usedbarcode_Customer> Usedbarcode_Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Winner> Winners { get; set; }  
    }
}
