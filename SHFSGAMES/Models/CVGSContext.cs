using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SHFSGAMES.Models
{
    public partial class CVGSContext : DbContext
    {
        public CVGSContext()
        {
        }

        public CVGSContext(DbContextOptions<CVGSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CategoryMembers> CategoryMembers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EventRegistrations> EventRegistrations { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<FriendsFamilyLists> FriendsFamilyLists { get; set; }
        public virtual DbSet<GameCategories> GameCategories { get; set; }
        public virtual DbSet<GamePlatforms> GamePlatforms { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<MailingAddresses> MailingAddresses { get; set; }
        public virtual DbSet<MemberFriendsFamilyLists> MemberFriendsFamilyLists { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<PlatformMembers> PlatformMembers { get; set; }
        public virtual DbSet<Platforms> Platforms { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<ShippingAddresses> ShippingAddresses { get; set; }
        public virtual DbSet<WishlistGames> WishlistGames { get; set; }
        public virtual DbSet<Wishlists> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TRR2H6I\\SQLEXPRESS17;Database=CVGS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__accounts__B19E45E9C4225A0A");

                entity.ToTable("accounts");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_ToMembers");
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.CartItemId)
                    .HasName("PK__cart_ite__7B651521D632FBAA");

                entity.ToTable("cart_items");

                entity.Property(e => e.CartItemId).HasColumnName("CartItem_ID");

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.Property(e => e.PlatformId).HasColumnName("Platform_Id");

                entity.HasOne(d => d.Carts)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_ToCart");

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_ToGame");

                entity.HasOne(d => d.Platforms)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cart_items_ToPlatforms");
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__carts__D6AB475952009B64");

                entity.ToTable("carts");

                entity.HasIndex(e => e.MemberId)
                    .HasName("FKcarts247210");

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_ToMembers");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__categori__6DB38D6E5390C985");

                entity.ToTable("categories");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryMembers>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.MemberId })
                    .HasName("PK__category__0999E59ADEF2D9B9");

                entity.ToTable("category_members");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.CategoryMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_category_members_ToMembers");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__employee__781134A199861956");

                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventRegistrations>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.EventId })
                    .HasName("PK__event_re__ECB2B429683A0B2A");

                entity.ToTable("event_registrations");

                //entity.HasIndex(e => e.EventId)
                //    .HasName("FKevent_regi871825");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.Property(e => e.Registered)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKevent_regi691103");

                entity.HasOne(d => d.Events)
                    .WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKevent_regi871825");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__events__FD6BEF840C7DE321");

                entity.ToTable("events");

                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");


                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EventLocation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employees)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_events_ToEmployees");
            });

            modelBuilder.Entity<FriendsFamilyLists>(entity =>
            {
                entity.HasKey(e => e.FriendsFamilyListId)
                    .HasName("PK__friends___4AD32942B994AF8A");

                entity.ToTable("friends_family_lists");

                entity.Property(e => e.FriendsFamilyListId).HasColumnName("FriendsFamilyList_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.FriendsFamilyLists)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_friends_family_lists_Members");
            });

            modelBuilder.Entity<GameCategories>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.GameId })
                    .HasName("PK__game_cat__9D203C90BF603DD1");

                entity.ToTable("game_categories");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.GameCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_categories_ToCategories");

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.GameCategories)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_categories_ToGames");
            });

            modelBuilder.Entity<GamePlatforms>(entity =>
            {
                entity.HasKey(e => new { e.PlatformId, e.GameId })
                    .HasName("PK__game_pla__A66141ED70B681A6");

                entity.ToTable("game_platforms");

                entity.HasIndex(e => e.GameId)
                    .HasName("FKgame_platf363858");

                entity.Property(e => e.PlatformId).HasColumnName("Platform_Id");

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.HasOne(d => d.Platforms)
                    .WithMany(p => p.GamePlatforms)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_platforms_ToPlatforms");

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.GamePlatforms)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_platforms_ToGames");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PK__games__093B1FEEED12E391");

                entity.ToTable("games");

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.Property(e => e.GameDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MailingAddresses>(entity =>
            {
                entity.HasKey(e => e.MailingAddressId)
                    .HasName("PK__mailing___FC563BCC1BD5EDB1");

                entity.ToTable("mailing_addresses");

                entity.Property(e => e.MailingAddressId).HasColumnName("MailingAddress_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                //entity.HasIndex(e => e.MemberId)
                //    .HasName("FKMembers_ShippingAddress");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.MailingAddresses)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mailing_addresses_members");
            });

            modelBuilder.Entity<MemberFriendsFamilyLists>(entity =>
            {
                entity.HasKey(e => new { e.FriendsFamilyListId, e.MemberId })
                    .HasName("PK__member_f__760BBDD3D680B1FC");

                entity.ToTable("member_friends_family_lists");

                //entity.HasIndex(e => e.FriendsFamilyListId)
                //    .HasName("FKmember_fri434393");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.FriendsFamilyListId).HasColumnName("FriendsFamilyList_Id");

                entity.HasOne(d => d.FriendsFamilyLists)
                    .WithMany(p => p.MemberFriendsFamilyLists)
                    .HasForeignKey(d => d.FriendsFamilyListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_member_friends_family_lists_ToFriendsFamilyList");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.MemberFriendsFamilyLists)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_member_friends_family_lists_ToMembers");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__members__42A68F47B8FEA881");

                entity.ToTable("members");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveEmail)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.ToTable("order_items");

                entity.Property(e => e.OrderItemsId).HasColumnName("orderItems_Id");

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.PlatformId).HasColumnName("Platform_Id");

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_items_ToGames");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_items_ToOrders");

                entity.HasOne(d => d.Platforms)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_items_ToPlatforms");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__orders__F1E4607BA0FCE2CA");

                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.ShippedDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_ToMembers");

                entity.HasOne(d => d.Payments)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_ToPayments");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__payments__DA6C7FC14CA84F25");

                entity.ToTable("payments");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payments_ToMembers");
            });

            modelBuilder.Entity<PlatformMembers>(entity =>
            {
                entity.HasKey(e => new { e.PlatformId, e.MemberId })
                    .HasName("PK__platform__32D898E7023EDC3F");

                entity.ToTable("platform_members");

                entity.Property(e => e.PlatformId).HasColumnName("Platform_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Platforms)
                    .WithMany(p => p.PlatformMembers)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_platform_members_ToPlatforms");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.PlatformMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_platform_members_ToMembers");
            });

            modelBuilder.Entity<Platforms>(entity =>
            {
                entity.HasKey(e => e.PlatformId)
                    .HasName("PK__platform__56F2F0137C8DA8BA");

                entity.ToTable("platforms");

                entity.Property(e => e.PlatformId).HasColumnName("Platform_Id");

                entity.Property(e => e.PlatformName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__ratings__BE48C84580AAE3B0");

                entity.ToTable("ratings");

                entity.Property(e => e.RatingId).HasColumnName("Rating_Id");

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ratings_ToGames");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ratings_ToMembers");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__reviews__F85DA78BE5C5C8EB");

                entity.ToTable("reviews");

                entity.HasIndex(e => e.GameId)
                    .HasName("FKreviews802098");

                entity.Property(e => e.ReviewId).HasColumnName("Review_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Approved)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.Property(e => e.ReviewDetails)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewTitle)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviews_ToGames");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviews_ToMembers");
            });

            modelBuilder.Entity<ShippingAddresses>(entity =>
            {
                entity.HasKey(e => e.ShippingAddressId)
                    .HasName("PK__shipping__6655220F75D3862A");

                entity.ToTable("shipping_addresses");

                entity.Property(e => e.ShippingAddressId).HasColumnName("ShippingAddress_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.ShippingAddresses)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shipping_addresses_members");
            });

            modelBuilder.Entity<WishlistGames>(entity =>
            {
                entity.HasKey(e => new { e.WishlistId, e.GameId })
                    .HasName("PK__wishlist__36C1F61DB6FDA22A");

                entity.ToTable("wishlist_games");

                entity.Property(e => e.WishlistId).HasColumnName("Wishlist_Id");

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.HasOne(d => d.Wishlists)
                    .WithMany(p => p.WishlistGames)
                    .HasForeignKey(d => d.WishlistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishlist_games_ToWishlist");

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.WishlistGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishlist_games_ToGame");
            });

            modelBuilder.Entity<Wishlists>(entity =>
            {
                entity.HasKey(e => e.WishlistId)
                    .HasName("PK__wishlist__C65247E302C06270");

                entity.ToTable("wishlists");

                entity.Property(e => e.WishlistId).HasColumnName("Wishlist_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Members)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishlists_ToMember");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
