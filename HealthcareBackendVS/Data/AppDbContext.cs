using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Visit> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships, constraints, here if needed
        // Example:
        // modelBuilder.Entity<Patient>()
        //     .HasMany(p => p.Visits)
        //     .WithOne(v => v.Patient)
        //     .HasForeignKey(v => v.PatientId);
    }
}
