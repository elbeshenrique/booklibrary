using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Repositories.Context;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                       throw new InvalidOperationException("Connection string is not set."));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__books__book_id");
            entity.HasIndex(e => e.Title).HasDatabaseName("IDX__books__title");
            entity.HasIndex(e => e.FirstName).HasDatabaseName("IDX__books__first_name");
            entity.HasIndex(e => e.LastName).HasDatabaseName("IDX__books__last_name");
            entity.HasIndex(e => e.Isbn).HasDatabaseName("IDX__books__isbn");

            entity.ToTable("books");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.CopiesInUse).HasColumnName("copies_in_use");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Isbn)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.TotalCopies).HasColumnName("total_copies");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });
    }
}