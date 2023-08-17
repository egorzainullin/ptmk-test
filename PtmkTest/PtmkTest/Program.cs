// See https://aka.ms/new-console-template for more information

using PtmkTest.Data.Users;

namespace PtmkTest;

public static class Program
{
    public static void Main(string[] args)
    {
        var factory = new Factory();
        using (var context = factory.CreateDbContext(Array.Empty<string>()))
        {
            context.Users.Add(new UserDbModel()
            {
                DateOfBirth = DateTime.UtcNow,
                Name = "Test",
                Sex = Sex.Male
            });
            context.SaveChanges();
            Console.WriteLine(context.Users);
        }
    }
}