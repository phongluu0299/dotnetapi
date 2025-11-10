using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace netCoreApi.Models;

public partial class DotNetApiContext : DbContext
{
    public DotNetApiContext(DbContextOptions<DotNetApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Page>(entity =>
        {
            entity.ToTable("Page");

            entity.Property(e => e.PageId).HasColumnName("PageID");
            entity.Property(e => e.Api).HasMaxLength(250);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Display).HasMaxLength(250);
            entity.Property(e => e.Func).HasMaxLength(250);
            entity.Property(e => e.Icon).HasMaxLength(50);
            entity.Property(e => e.Param).HasMaxLength(250);
            entity.Property(e => e.Route).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UserCreated).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.UserModified).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Avatar).HasMaxLength(250);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(250);
            entity.Property(e => e.MainDeviceId).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Salt).HasMaxLength(50);
            entity.Property(e => e.UserCreated).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.UserModified).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
