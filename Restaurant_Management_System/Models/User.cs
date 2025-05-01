using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? ProfileImage { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsVerified { get; set; }

    public int UserRoleId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<CardPayment> CardPayments { get; set; } = new List<CardPayment>();

    public virtual ICollection<Chat> ChatDrivers { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatUsers { get; set; } = new List<Chat>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Order> OrderClients { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderDrivers { get; set; } = new List<Order>();

    public virtual ICollection<Otp> Otps { get; set; } = new List<Otp>();

    public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();

    public virtual UserRole UserRole { get; set; } = null!;
}
