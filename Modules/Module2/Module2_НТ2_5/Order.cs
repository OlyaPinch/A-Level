namespace Module2_НТ2_5;

public class Order
{
    public int Id { get; set; }

    public Order(RentCar car, int time)
    {
        Car = car;
        Time = time;
    }

    public RentCar Car { get; set; }
    public int Time { get; set; }
}