namespace Module2_HT2;

public class CakeWithGlaze : Cake
{
    public CakeWithGlaze(string nameOfGlaze)
    {
        Name = "Cake with " + nameOfGlaze + " glaze";
        ComponentsList.Add(new Component(nameOfGlaze, 20));
    }

    public override void Bake()
    {
        Console.WriteLine($"Baking {Name}");
    }
}