using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

public class ScreenSoundContext : DbContext
{
    //teste para remover mudanças 
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=true;Application Intent=ReadWrite;Multi Subnet Failover=False";
    //private string connectionString = "Server=tcp:screensoundserver0.database.windows.net,1433;Initial Catalog=ScreenSoundV0;Persist Security Info=False;User ID=patrick;Password=Senh@001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
    //public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options) : base(options)
    //{
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
            .HasMany(c => c.Generos)
            .WithMany(c => c.Musicas);
    }
}
