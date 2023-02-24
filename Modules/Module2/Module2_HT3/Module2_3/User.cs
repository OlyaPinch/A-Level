namespace Module2_3;

public class User
{
    public User(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
        UserId = Guid.NewGuid();
    }

    public string Name { get; set; }
    public string LastName { get; set; }
    public Guid UserId { get; set; }
}