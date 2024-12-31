using Demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public class DataContext : IdentityDbContext<AppUserModel>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<AbsentModel> Absents {  get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ComboMenuModel> ComboMenus { get; set; }
        public DbSet<ContractModel> Contracts { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderModel> Orders {  get; set; }  
        public DbSet<PositionModel> Positions { get; set; }
        public DbSet<PreOrderModel> PreOrders { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<SalaryModel> Salaries { get; set;}
        public DbSet<StaffModel> Staffs { get; set;}
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Tabletype> Tabletypes { get; set; }
        public DbSet<AttendanceModel> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PositionModel>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Positions)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // Nếu muốn ngăn xóa dữ liệu có liên quan
        }
    }

    
}
