using Microsoft.EntityFrameworkCore;

namespace CRUD_Application_DB_First.Models;

public partial class MyLocalDbContext : DbContext
{
    public MyLocalDbContext()
    {
    }

    public MyLocalDbContext(DbContextOptions<MyLocalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // The connection string will now be read from appsettings.json via dependency injection
            // No hardcoded connection string here
        }
    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employee");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.EmpName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3214EC27ECBC6BE0");

            entity.ToTable("students");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Section)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("section");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("test");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
