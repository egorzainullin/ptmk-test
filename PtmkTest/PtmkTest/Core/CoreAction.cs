using Microsoft.EntityFrameworkCore;
using PtmkTest.Data.Users;

namespace PtmkTest.Core;

public class CoreAction
{
    private readonly DatabaseContext _context;

    public CoreAction(DatabaseContext context)
    {
        _context = context;
    }


    public void AddTableUser()
    {
        _context.Database.Migrate();
    }

    public void CreateUser(User user)
    {
        var userDb = new UserDbModel()
        {
            DateOfBirth = user.DateOfBirth,
            Name = user.Name,
            Sex = user.Sex
        };
        _context.Users.Add(userDb);
        _context.SaveChanges();
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.Select(x => x.ToUser()
        ).ToList();
    }

    public List<User> GetAllUniqueUsers()
    {
        var users =
            _context.Users
                .GroupBy(x => new {x.Name, x.DateOfBirth})
                .OrderBy(x => x.Key.Name)
                .Select(g => g.Select(x=> x.ToUser()).First())
                .ToList();
        return users;
    }

    public void InitMillionRows()
    {
        var users = _context.Users;
        var initialDate = new DateTime(1900, 02, 22, 0, 0, 0, DateTimeKind.Utc);
        for (int i = 0; i < 100; ++i)
        {
            var name = $"F{i}";
            var date = initialDate.AddYears(i);
            var sex = Sex.Male;
            var user = new User()
            {
                Name = name,
                DateOfBirth = date,
                Sex = sex
            };
            CreateUser(user);
        }
        for (int i = 100; i < 1000000; i++)
        {
            var name = $"X{i}";
            var date = initialDate.AddYears(i % 20).AddMonths(i % 11).AddDays(i % 70);
            var sex = i % 2 == 0 ? Sex.Male : Sex.Female;
            var user = new User()
            {
                Name = name,
                DateOfBirth = date,
                Sex = sex
            };
            CreateUser(user);
        }
        _context.SaveChanges();
    }
}