namespace Module2_НТ2_5;

public class FuelCar : Sedan
{
    public int VolumeOfEngine { get; set; }
    public int FuelConsumption { get; set; }

    public override void PrintCar()
    {
        base.PrintCar();
        Console.WriteLine($"\tVolumeOfEngine={VolumeOfEngine}\t FuelConsumption {FuelConsumption} per 100 km");
    }
}