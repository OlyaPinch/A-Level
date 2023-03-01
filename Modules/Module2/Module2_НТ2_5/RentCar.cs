namespace Module2_НТ2_5;

public class RentCar
{
    public ICar car { get; set; }
    public int RentPricePerHour { get; set; }

    public RentCar(ICar car, int rentPricePerHour)
    {
        this.car = car;
        RentPricePerHour = rentPricePerHour;
    }

    public void PrintRentCars()
    {
        car.PrintCar();
        Console.WriteLine("Price per 1 hour="+RentPricePerHour);
    }
}