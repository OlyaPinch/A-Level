namespace Module2_HT2;

public class Cake : BakingSweet
{
    public Cake()
    {
        Name = "Standard Cake";
        
        ComponentsList.Add(new Component("Sugar", 200));
        ComponentsList.Add(new Component("Flour", 200));
        ComponentsList.Add(new Component("Milk", 100));
    }

    public override void Bake()
    {
        Console.WriteLine($"Baking {Name}");
    }
}