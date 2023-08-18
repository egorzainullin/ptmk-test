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
                .Select(x => x.ToUser())
                .ToList()
                .DistinctBy(x => new { x.Name, x.DateOfBirth })
                .OrderBy(x => x.Name)
                .ToList();
        return users;
    }
}