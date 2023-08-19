// See https://aka.ms/new-console-template for more information

using System.Text;
using PtmkTest.Core;

namespace PtmkTest;

public static class Program
{
    public static void Main(string[] args)
    {
        using (var context = Factory.CreateDbContext())
        {
            var core = new CoreAction(context);
            if (args.Length == 0)
            {
            }
            else if (args[0] == "1")
            {
                core.AddTableUser();
            }
            else if (args[0] == "2")
            {
                if (args.Length != 4)
                {
                    throw new ArgumentException("Incorrect number of arguments");
                }

                var name = args[1];
                if (!DateTime.TryParse(args[2], out var date))
                {
                    throw new ArgumentException("Date is not correct");
                }

                date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second,
                    DateTimeKind.Utc);
                var sex = args[3] == "Male" ? Sex.Male : Sex.Female;
                var user = new User()
                {
                    DateOfBirth = date,
                    Name = name,
                    Sex = sex
                };
                core.CreateUser(user);
            }
            else if (args[0] == "3")
            {
                var uniqueUsers = core.GetAllUniqueUsers();
                var builder = new StringBuilder();
                foreach (var uniqueUser in uniqueUsers)
                {
                    var years = AgeCalculator.GetAgeInYears(uniqueUser.DateOfBirth);
                    var lineOfUser = $"{uniqueUser} y.o.: {years}";
                    builder.AppendLine(lineOfUser);
                }

                var usersToPrint = builder.ToString();
                Console.WriteLine(usersToPrint);
            }
            else if (args[0] == "4")
            {
                core.InitMillionRows();
            }
            else if (args[0] == "5")
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var users = core.GetFMaleUsers();
                var builder = new StringBuilder();
                foreach (var user in users)
                {
                    var userLine = $"{user}";
                    builder.AppendLine(userLine);
                }

                var usersToPrint = builder.ToString();
                Console.WriteLine(usersToPrint);
                watch.Stop();
                var timeString = $"time: {watch.ElapsedMilliseconds} milliseconds";
                Console.WriteLine(timeString);
            }
        }
    }
}