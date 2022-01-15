﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitterCloneAPI.Data;

namespace TwitterCloneAPI.Migrations
{
    [DbContext(typeof(TwitterDatabaseContext))]
    partial class TwitterDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TwitterCloneAPI.Models.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FollowerId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TweetId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.ReplyLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ReplyId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReplyId");

                    b.HasIndex("UserId");

                    b.ToTable("ReplyLikes");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hashtag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.TweetLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TweetId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("TweetLikes");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Follow", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.User", null)
                        .WithMany("Follows")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Reply", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.Tweet", null)
                        .WithMany("Replies")
                        .HasForeignKey("TweetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TwitterCloneAPI.Models.User", null)
                        .WithMany("Replies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.ReplyLike", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.Reply", null)
                        .WithMany("ReplyLikes")
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TwitterCloneAPI.Models.User", null)
                        .WithMany("ReplyLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.User", null)
                        .WithMany("Tweets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.TweetLike", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.Tweet", null)
                        .WithMany("TweetLikes")
                        .HasForeignKey("TweetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TwitterCloneAPI.Models.User", null)
                        .WithMany("TweetLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Reply", b =>
                {
                    b.Navigation("ReplyLikes");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.Navigation("Replies");

                    b.Navigation("TweetLikes");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.User", b =>
                {
                    b.Navigation("Follows");

                    b.Navigation("Replies");

                    b.Navigation("ReplyLikes");

                    b.Navigation("TweetLikes");

                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}
