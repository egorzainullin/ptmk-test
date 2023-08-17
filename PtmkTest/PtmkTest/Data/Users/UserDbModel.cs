using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PtmkTest.Core;

namespace PtmkTest.Data.Users;

public class UserDbModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public Sex Sex { get; set; }

    public User ToUser()
    {
        return new User()
        {
            Id = Id,
            DateOfBirth = DateOfBirth,
            Name = Name,
            Sex = Sex
        };
    }
}

internal class Map : IEntityTypeConfiguration<UserDbModel>
{
    public void Configure(EntityTypeBuilder<UserDbModel> builder)
    {
        builder.ToTable("user");
    }
}