using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StichtingAccessibility.Server.Models;

public partial class StichtingDbContext : IdentityDbContext<IdentityUser>
{
    public StichtingDbContext()
    {
    }

    public StichtingDbContext(DbContextOptions<StichtingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public DbSet<Onderzoek> Onderzoeken { get; set; }
    public DbSet<Vragenlijst> Vragenlijsten { get; set; }
    public DbSet<WebsiteOnderzoek> WebsiteOnderzoeken { get; set; }
    public DbSet<Uitnodiging> Uitnodidingen { get; set; }

    public DbSet<BedrijfsPortaal> BedrijfsPortaalen { get; set; }
    public DbSet<BeheerdersPortaal> BeheerdersPortaal { get; set; }

    public DbSet<BedrijfsMedewerker> BedrijfsMedewerkers { get; set; }
    public DbSet<Beheerder> Beheerders { get; set; }
    public DbSet<Ervaringsdeskundig> Ervaringsdeskundigen { get; set; }
    public DbSet<Voogd> Voogden { get; set; }
    public DbSet<Invite> Invites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__A4AE64D8BBE16905");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Onderzoek>(entity =>
        {
            entity.HasMany(e => e.Ervaringsdeskundigen)
                .WithMany()
                .UsingEntity(j => j.ToTable("OnderzoekErvaringsdeskundig"));

            entity.HasDiscriminator<string>("OnderzoekType")
                .HasValue<Vragenlijst>("Vragenlijst")
                .HasValue<Uitnodiging>("Uitnodiging")
                .HasValue<WebsiteOnderzoek>("WebsiteOnderzoek");
        });


        modelBuilder.Entity<Ervaringsdeskundig>()
            .HasMany(e => e.Voogden)
            .WithMany(v => v.Ervaringsdeskundigen)
            .UsingEntity(j => j.ToTable("ErvaringsdeskundigVoogd"));

        modelBuilder.Entity<Gebruiker>(entity =>
        {
            entity.HasDiscriminator<string>("GebruikerType")
                .HasValue<Beheerder>("Beheerder")
                .HasValue<Ervaringsdeskundig>("Ervaringsdeskundig")
                .HasValue<BedrijfsMedewerker>("Bedrijfsmedewerker");
        });


        modelBuilder.Entity<BedrijfsPortaal>()
            .HasDiscriminator<string>("PortaalType")
            .HasValue<BeheerdersPortaal>("BeheerderPortaal");
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}