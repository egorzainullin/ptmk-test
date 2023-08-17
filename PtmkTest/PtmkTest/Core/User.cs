namespace PtmkTest.Core;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Sex Sex { get; set; }

    public override string ToString()
    {
        var sex = Sex == Sex.Male ? "Male" : "Female";
        return $"{Name}, {DateOfBirth}, {sex}";
    }
}

public enum Sex
{
    Male = 0,
    Female = 1
}