namespace Module2_НТ2_5;

public class RentOffice
{
    public RentOffice()
    {
        Cars = new List<RentCar>();
    }

    public List<RentCar> Cars { get; set; }
    private List<RentCar> _availableCar;
    private List<RentCar> _orderedCars;
    public List<Order> _orders { get; set; }

    public void MakeOrder(RentCar car, int time)
    {
        Order order = new Order(car, time);
        order.Id = _orders.Count + 1;

        _orders.Add(order);
    }
}