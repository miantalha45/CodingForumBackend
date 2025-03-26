using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace forum.Server.Models;

public partial class IDiscussContext : DbContext
{
    public IDiscussContext()
    {
    }

    public IDiscussContext(DbContextOptions<IDiscussContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Threads> Threads { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B467BC9370");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryDescription)
                .HasColumnType("text")
                .HasColumnName("category_description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category_name");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__comments__E7957687D9992CDF");

            entity.ToTable("comments");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.CommentBy).HasColumnName("comment_by").HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CommentContent)
                .HasColumnType("text")
                .HasColumnName("comment_content");
            entity.Property(e => e.CommntTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("commnt_time");
            entity.Property(e => e.ThreadId).HasColumnName("thread_id");
        });

        modelBuilder.Entity<Threads>(entity =>
        {
            entity.HasKey(e => e.ThreadId).HasName("PK__threads__7411E2F067B15FD4");

            entity.ToTable("threads");

            entity.Property(e => e.ThreadId).HasColumnName("thread_id");
            entity.Property(e => e.ThreadCatId).HasColumnName("thread_cat_id");
            entity.Property(e => e.ThreadDesc)
                .HasColumnType("text")
                .HasColumnName("thread_desc");
            entity.Property(e => e.ThreadTitle)
                .HasColumnType("text")
                .HasColumnName("thread_title");
            entity.Property(e => e.ThreadUserId).HasColumnName("thread_user_id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.ThreadUserName)
                .HasColumnName("thread_user_name")
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Sno).HasName("PK__users__DDDF6446307792BB");

            entity.ToTable("users");

            entity.Property(e => e.Sno).HasColumnName("sno");
            entity.Property(e => e.Dt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dt");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
