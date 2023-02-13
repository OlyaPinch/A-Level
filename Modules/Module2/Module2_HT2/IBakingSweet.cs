namespace Module2_HT2;

public interface IBakingSweet
{
    List<Component> ComponentsList { get; set; }
    double Weight { get; }
    string Name { get; set; }
    void Description();
    void Bake();
}