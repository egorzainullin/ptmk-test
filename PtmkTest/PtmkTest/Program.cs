// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PtmkTest.Core;
using PtmkTest.Data.Users;

namespace PtmkTest;

public static class Program
{
    public static void Main(string[] args)
    {
        var factory = new Factory();
        using (var context = factory.CreateDbContext(Array.Empty<string>()))
        {
            var core = new CoreAction(context);
            core.AddTable();
            var user = new User()
            {
                DateOfBirth = DateTime.UtcNow,
                Name = "Test 1",
                Sex = Sex.Male
            };
            core.CreateUser(user);
            var users = core.GetAllUsers();
            foreach (var u in users)
            {
                Console.WriteLine(u);
                
            }
        }
    }
}