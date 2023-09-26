using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollectorsAppApi.Models;

public partial class CollectorsAppDbContext : DbContext
{
    public CollectorsAppDbContext()
    {
    }

    public CollectorsAppDbContext(DbContextOptions<CollectorsAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<CollectionsDictionary> CollectionsDictionaries { get; set; }

    public virtual DbSet<Item> CollectorsItems { get; set; }

    public virtual DbSet<Events> Events{ get; set; }

    public virtual DbSet<ForumPost> ForumPosts { get; set; }

    public virtual DbSet<ForumTopic> ForumTopics { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server="+ Environment.MachineName +";Database=CollectorsAppDB;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Collection>(entity =>
        {
            entity.HasKey(e => e.CollectionId).HasName("PK__caa.Coll__7DE6BC24C6C97E10");

            entity.ToTable("caa.Collection");

            entity.Property(e => e.CollectionId).HasColumnName("CollectionID");
            entity.Property(e => e.CollectionTypeId).HasColumnName("CollectionTypeID");
            entity.Property(e => e.Description).HasMaxLength(2500);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

            entity.HasOne(d => d.CollectionType).WithMany(p => p.CaaCollections)
                .HasForeignKey(d => d.CollectionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectionType");


        });

        modelBuilder.Entity<CollectionsDictionary>(entity =>
        {
            entity.HasKey(e => e.CollectionTypeId).HasName("PK__caa.Coll__40A4204A8B420313");

            entity.ToTable("caa.CollectionsDictionary");

            entity.Property(e => e.CollectionTypeId).HasColumnName("CollectionTypeID");
            entity.Property(e => e.Collection).HasMaxLength(250);
            entity.Property(e => e.MetaCategory).HasMaxLength(250);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__caa.Coll__727E83EB22382B96");

            entity.ToTable("caa.CollectorsItems");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Attachment).HasColumnType("image");
            entity.Property(e => e.CollectionId).HasColumnName("CollectionID");
            entity.Property(e => e.CollectionTypeId).HasColumnName("CollectionTypeID");
            entity.Property(e => e.Description).HasMaxLength(2500);
            entity.Property(e => e.MetaCategory).HasMaxLength(250);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

            entity.HasOne(d => d.Collection).WithMany(p => p.CollectorsItems)
                .HasForeignKey(d => d.CollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Collection_Item");

            entity.HasOne(d => d.CollectionType).WithMany(p => p.CaaCollectorsItems)
                .HasForeignKey(d => d.CollectionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectionType_Item");

        });

        modelBuilder.Entity<Events>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__caa.Even__7944C87045D47B25");

            entity.ToTable("caa.EventsCalendar");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.DateOfCreation).HasColumnType("date");
            entity.Property(e => e.DateOfEvent).HasColumnType("date");
            entity.Property(e => e.EventAdress).HasMaxLength(255);
            entity.Property(e => e.ForumTopicId).HasColumnName("ForumTopicID");
            entity.Property(e => e.OrganizerId).HasColumnName("OrganizerID");

            entity.HasOne(d => d.AssociatedCollectionNavigation).WithMany(p => p.CaaEventsCalendars)
                .HasForeignKey(d => d.AssociatedCollection)
                .HasConstraintName("FK_CollectionType_Event");

            entity.HasOne(d => d.ForumTopic).WithMany(p => p.CaaEventsCalendars)
                .HasForeignKey(d => d.ForumTopicId)
                .HasConstraintName("FK_ForumTopic_Event");

        });

        modelBuilder.Entity<ForumPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__caa.Foru__AA12603859C30D3A");

            entity.ToTable("caa.ForumPosts");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Attachment).HasColumnType("image");
            entity.Property(e => e.CreatorId).HasColumnName("CreatorID");
            entity.Property(e => e.DateOfCreation).HasColumnType("date");
            entity.Property(e => e.PostBody).HasMaxLength(2000);
            entity.Property(e => e.TopicId).HasColumnName("TopicID");

            

            entity.HasOne(d => d.Topic).WithMany(p => p.CaaForumPosts)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Topic_Post");
        });

        modelBuilder.Entity<ForumTopic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__caa.Foru__022E0F7D3FB3E061");

            entity.ToTable("caa.ForumTopics");

            entity.Property(e => e.TopicId).HasColumnName("TopicID");
            entity.Property(e => e.CreatorId).HasColumnName("CreatorID");
            entity.Property(e => e.DateOfCreation).HasColumnType("date");
            entity.Property(e => e.TopicName).HasColumnName("TopicName");

            
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__caa.User__1788CCACB20580FE");

            entity.ToTable("caa.Users");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("Password_hash");
            entity.Property(e => e.UserImage).HasColumnType("image");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
