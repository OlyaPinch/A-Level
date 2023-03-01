namespace Module2_НТ2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FuelCar car1 = new FuelCar();
            car1.BrandCar = "Audi";
            car1.Price = 30000;
            car1.TypeOfFuel = TypeOfFuel.petrol;
            car1.YearOfProduction = 2025;
            car1.NumberOfDoors = 5;
            car1.VolumeOfEngine = 2;
            car1.FuelConsumption = 8;

            FuelCar car2 = new FuelCar();
            car2.BrandCar = "BMW";
            car2.Price = 40000;
            car2.TypeOfFuel = TypeOfFuel.diesel;
            car2.YearOfProduction = 2020;
            car2.NumberOfDoors = 4;
            car2.VolumeOfEngine = 5;
            car2.FuelConsumption = 12;


            ElectricCar car3 = new ElectricCar();
            car3.BrandCar = "Tesla";
            car3.Price = 50000;
            car3.TypeOfFuel = TypeOfFuel.electro;
            car3.YearOfProduction = 2022;
            car3.NumberOfDoors = 3;
            car3.BateryCapasity = 200;
            car3.PowerReserve = 250;

            Truck car4 = new Truck();
            car4.BrandCar = "DAF";
            car4.Price = 30000;
            car4.TypeOfFuel = TypeOfFuel.petrol;
            car4.YearOfProduction = 1990;
            car4.LoadCapacity = 20;


            


            RentOffice rent = new RentOffice();
            rent.Cars.Add(new RentCar(car1, 100));
            rent.Cars.Add(new RentCar(car2, 150));
            rent.Cars.Add(new RentCar(car3, 160));
            rent.Cars.Add(new RentCar(car4, 200));

            Console.WriteLine(rent.TotalCostOfCars());
            var underscoreSymbols = new string('_', 50);
            Console.WriteLine(underscoreSymbols);
            foreach (var rentCar in rent.Cars)
            {
                rentCar.PrintRentCars();
            }
            Console.WriteLine(underscoreSymbols);
            List<RentCar> carsSorting = new List<RentCar>();
            carsSorting = rent.SortingCarPerYear();


            foreach (var rentCar in carsSorting)
            {
                rentCar.PrintRentCars();
            }
            Console.WriteLine(underscoreSymbols);

            carsSorting = rent.SearchByBrand("Audi");
            foreach (var rentCar in carsSorting)
            {
                rentCar.PrintRentCars();
            }
            Console.WriteLine(underscoreSymbols);
        }
    }
}