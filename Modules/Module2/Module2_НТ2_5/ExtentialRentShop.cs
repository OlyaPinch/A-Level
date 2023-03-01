using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module2_НТ2_5
{
    public static class ExetentionRentOrder
    {
        public static List<RentCar> SearchByBrand(this RentOffice rentOffice, string brandCar)
        {
            return rentOffice.Cars.Where(c => c.car.BrandCar == brandCar).ToList();
        }

        public static List<RentCar> SearchByTypeOfFuel(this RentOffice rentOffice, TypeOfFuel typeOfFuel)
        {
            return rentOffice.Cars.Where(c => c.car.TypeOfFuel == typeOfFuel).ToList();
        }

        public static List<RentCar> SortingCarPerYear(this RentOffice rentOffice)
        {
            List<RentCar> carsSorting;

            carsSorting = rentOffice.Cars;
            return carsSorting.OrderBy(i => i.car.YearOfProduction).ToList();
        }

        public static int TotalCostOfCars(this RentOffice rentOffice)
        {
            return rentOffice.Cars.Sum(i => i.car.Price);
        }
    }
}