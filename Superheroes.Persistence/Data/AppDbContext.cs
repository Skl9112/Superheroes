namespace Superheroes.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ability>()
                .HasOne(a => a.Superhero)
                .WithMany(s => s.Abilities)
                .HasForeignKey(a => a.SuperheroId);
        }
    }
}
