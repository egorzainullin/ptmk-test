namespace PtmkTest.Core;

public class AgeCalculator
{
    public static int GetAgeInYears(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age))
        {
            --age;
        }

        return age;
    }
}