namespace Module2_HT2;

public class CakeWithJam : Cake
{
    public CakeWithJam(string nameOfJam)
    {
        Name = nameOfJam + "Cake";

        ComponentsList.Add(new Component(nameOfJam, 30));
    }

    public override void Bake()
    {
        Console.WriteLine($"Baking {Name}");
    }
}