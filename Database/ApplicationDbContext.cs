using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notary.Models;
using Files = Notary.Models.Files;

namespace Notary.Database
{

  public class ApplicationDbContext : IdentityDbContext

  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }

    public DbSet<CompanyClient> CompanyClients { get; set; }
    public DbSet<Files> Files { get; set; }
    public DbSet<Documents> Documents { get; set; }
    public DbSet<FilesClient> FilesClients { get; set; }
    public DbSet<FilesCompanyClient> FilesCompanyClients { get; set; }
    public DbSet<DocumentsFiles> DocumentsFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<FilesClient>(entity =>
      {
        entity.HasKey(pt => new { pt.FilesId, pt.ClientId });

        entity.HasOne(pt => pt.files)
            .WithMany(p => p.FilesClient)
            .HasForeignKey(pt => pt.FilesId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(pt => pt.client)
            .WithMany(t => t.FilesClient)
            .HasForeignKey(pt => pt.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
      });

      modelBuilder.Entity<FilesCompanyClient>(entity =>
      {
        entity.HasKey(pt => new { pt.FilesId, pt.CompanyClientId });

        entity.HasOne(pt => pt.files)
            .WithMany(p => p.FilesCompanyClient)
            .HasForeignKey(pt => pt.FilesId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(pt => pt.companyClient)
            .WithMany(t => t.FilesCompanyClient)
            .HasForeignKey(pt => pt.CompanyClientId)
            .OnDelete(DeleteBehavior.Cascade);
      });

      modelBuilder.Entity<DocumentsFiles>(entity =>
      {
        entity.HasKey(pt => new { pt.DocumentsId, pt.FilesId });

        entity.HasOne(pt => pt.documents)
            .WithMany(p => p.DocumentsFiles)
            .HasForeignKey(pt => pt.DocumentsId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(pt => pt.files)
            .WithMany(t => t.DocumentsFiles)
            .HasForeignKey(pt => pt.FilesId)
            .OnDelete(DeleteBehavior.Cascade);
      });

      modelBuilder.Entity<Client>()
                .HasMany(c => c.Documents)
                .WithOne(e => e.Client)
                .HasForeignKey(m => m.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<CompanyClient>()
            .HasMany(c => c.Documents)
            .WithOne(e => e.CompanyClient)
            .HasForeignKey(m => m.CompanyClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
  }
}


