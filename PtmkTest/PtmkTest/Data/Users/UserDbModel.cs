using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PtmkTest.Data.Users;

public enum Sex
{
    Male = 0,
    Female = 1
}

public class UserDbModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public Sex Sex { get; set; }
}

internal class Map : IEntityTypeConfiguration<UserDbModel>
{
    public void Configure(EntityTypeBuilder<UserDbModel> builder)
    {
        builder.ToTable("user");
    }
}