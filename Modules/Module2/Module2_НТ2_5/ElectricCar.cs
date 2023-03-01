namespace Module2_НТ2_5;

public class ElectricCar : Sedan
{
    public static ElectricCar CreateInstance()
    {
        return new();
    }

    public int BateryCapasity { get; set; }
    public int PowerReserve { get; set; }

    public override void PrintCar()
    {
        base.PrintCar();
        Console.WriteLine($"\tBateryCapasity={BateryCapasity}\tPowerReserve={PowerReserve}");
    }
}