using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class User
  {
    public Guid UserId { get; set; }
    public Role Role { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Code { get; set; }
    public bool EmailConfirm { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime LastLogin { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime Dob { get; set; }
    public string? Avatar { get; set; }
    public int LevelId { get; set; }
    public int? Point { get; set; }
    public virtual Level? Level { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasData(
        new User
        {
          UserId = new Guid("f75de9b6-51cd-4578-bfac-8d5eec4068b5"),
          Role = Role.Admin,
          UserName = "admin",
          Email = "admin@example.com",
          EmailConfirm = true,
          //Admin@123
          PasswordHash = "0E7517141FB53F21EE439B355B5A1D0A",
          DateTimeCreated = new DateTime(2022, 1, 1),
          LastLogin = new DateTime(2023, 4, 18),
          FirstName = "John",
          LastName = "Doe",
          Dob = new DateTime(1980, 1, 1),
          Avatar = "https://example.com/avatar.jpg"
        },
        new User
        {
          UserId = new Guid("91a2cca2-7bf1-451b-a47e-9f33ad54bd3c"),
          Role = Role.Member,
          UserName = "user1",
          Email = "user1@example.com",
          EmailConfirm = true,
          //Admin@123
          PasswordHash = "0E7517141FB53F21EE439B355B5A1D0A",
          DateTimeCreated = new DateTime(2022, 1, 2),
          LastLogin = new DateTime(2023, 4, 17),
          FirstName = "Jane",
          LastName = "Doe",
          Dob = new DateTime(1985, 2, 14),
          Avatar = "https://example.com/avatar2.jpg"
        }
      );
    }
  }

  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      // table name
      builder.ToTable("Users");

      // primary key
      builder.HasKey(x => x.UserId);

      //property
      builder.Property(x => x.UserId)
             .IsRequired();
      builder.Property(x => x.Role)
             .HasDefaultValue(Role.Member)
             .IsRequired();
      builder.Property(x => x.UserName)
             .HasMaxLength(50)
             .IsRequired();
      builder.Property(x => x.FirstName)
             .HasMaxLength(50);
      builder.Property(x => x.LastName)
             .IsRequired()
             .HasMaxLength(50);
      builder.Property(x => x.Dob)
             .IsRequired();
      builder.Property(x => x.Email)
             .IsRequired()
             .HasMaxLength(255);
      builder.Property(x => x.PasswordHash)
             .IsRequired()
             .HasMaxLength(255);
    }
  }
}

