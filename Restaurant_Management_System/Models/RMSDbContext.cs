using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Management_System.Models;

public partial class RMSDbContext : DbContext
{
    public RMSDbContext()
    {
    }

    public RMSDbContext(DbContextOptions<RMSDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<CardPayment> CardPayments { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categorys { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemOption> ItemOptions { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-D89OGE0\\SQLEXPRESS;Database=RMS-;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2A1BB4851D5A");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressHint).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Province)
                .HasMaxLength(255)
                .HasDefaultValue("Jordanian");
            entity.Property(e => e.Region).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Addresses__UserI__123EB7A3");
        });

        modelBuilder.Entity<CardPayment>(entity =>
        {
            entity.HasKey(e => e.CardPaymentId).HasName("PK__CardPaym__5A1D9E48CE8A0EA4");

            entity.ToTable("CardPayment");

            entity.Property(e => e.CardPaymentId).HasColumnName("CardPaymentID");
            entity.Property(e => e.CardHolderName).HasMaxLength(100);
            entity.Property(e => e.CardNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.CardType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CVV");
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.CardPayments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CardPayme__UserI__1332DBDC");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD797B818BDC9");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__ClientID__14270015");

            entity.HasOne(d => d.Item).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__ItemID__151B244E");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BFBD3F1FC");

            entity.HasIndex(e => e.NameAr, "UQ__Category__3329004B51D68F06").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__Category__332920C27B192AD8").IsUnique();

            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("Name_ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Name_en");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.ChatId).HasName("PK__Chat__A9FBE626023D3A6F");

            entity.ToTable("Chat");

            entity.Property(e => e.ChatId).HasColumnName("ChatID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.SenderType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_type");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Driver).WithMany(p => p.ChatDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chat__DriverID__17036CC0");

            entity.HasOne(d => d.User).WithMany(p => p.ChatUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Chat__UserID__160F4887");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__CE74FAF51D0DAC25");

            entity.ToTable("Favorite");

            entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Item).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Favorite__ItemID__18EBB532");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Favorite__UserID__17F790F9");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__727E83EB1BDBE302");

            entity.HasIndex(e => e.NameEn, "UQ__Items__EE1C774F14DE5DF2").IsUnique();

            entity.HasIndex(e => e.NameAr, "UQ__Items__EE1CD24CB8F63BAD").IsUnique();

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionAr).HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn)
                .IsUnicode(false)
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ItemImage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NameEN");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Items__CategoryI__1AD3FDA4");
        });

        modelBuilder.Entity<ItemOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__ItemOpti__92C7A1DF75125EC0");

            entity.HasIndex(e => e.NameEn, "UQ__ItemOpti__EE1C774FB784F235").IsUnique();

            entity.HasIndex(e => e.NameAr, "UQ__ItemOpti__EE1CD24CE8C8845C").IsUnique();

            entity.Property(e => e.OptionId).HasColumnName("OptionID");
            entity.Property(e => e.IsRequired).HasDefaultValue(false);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NameEN");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemOptions)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemOptio__ItemI__19DFD96B");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E327EC887D6");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("isRead");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__UserI__1BC821DD");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OffersId).HasName("PK__Offers__6ACDC64934B6E1D3");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionAr)
                .HasMaxLength(500)
                .HasColumnName("Description_AR");
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(500)
                .HasColumnName("Description_EN");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LimitAmount).HasColumnName("Limit_Amount");
            entity.Property(e => e.LimitPersons).HasColumnName("Limit_Persons");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.TitleAr)
                .HasMaxLength(255)
                .HasColumnName("Title_AR");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("Title_EN");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.Offers)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offers__ItemID__1CBC4616");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFE4A98356");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.OrderCreationDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Rate).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.OrderClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__ClientID__208CD6FA");

            entity.HasOne(d => d.Driver).WithMany(p => p.OrderDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__DriverID__2180FB33");

            entity.HasOne(d => d.Item).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__ItemID__1F98B2C1");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemsId).HasName("PK__OrderIte__D5BB2535558EC221");

            entity.Property(e => e.OrderItemsId).HasColumnName("OrderItemsID");
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PriceAtTimeOfOrder)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Price_at_time_of_order");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderItem__ItemI__1EA48E88");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderItem__Order__1DB06A4F");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.HasKey(e => e.Otpid).HasName("PK__OTPs__5C2EC5625747CD52");

            entity.ToTable("OTPs");

            entity.Property(e => e.Otpid).HasColumnName("OTPID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpirationTime).HasColumnType("datetime");
            entity.Property(e => e.IsUsed).HasDefaultValue(false);
            entity.Property(e => e.Otpcode).HasColumnName("OTPCode");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Otps)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OTPs__UserID__22751F6C");
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasKey(e => e.RateId).HasName("PK__Rates__58A7CCBC418AE1B9");

            entity.Property(e => e.RateId).HasColumnName("RateID");
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemRate).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Item).WithMany(p => p.Rates)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rates__ItemID__245D67DE");

            entity.HasOne(d => d.User).WithMany(p => p.Rates)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rates__UserID__236943A5");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF0494D74");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E437DBEB1B").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__Users__85FB4E3813A1AE2A").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053411C0383D").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedBy).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsVerified)
                .HasDefaultValue(true)
                .HasColumnName("isVerified");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProfileImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Profile_Image");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.UpdationDate).HasColumnType("datetime");
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__UserRoleI__25518C17");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A55E9A8E605");

            entity.ToTable("UserRole");

            entity.HasIndex(e => e.RoleName, "UQ__UserRole__8A2B6160075817BE").IsUnique();

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
