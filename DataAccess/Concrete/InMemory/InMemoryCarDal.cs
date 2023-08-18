using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemoryCarDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=400000, ModelYear=2014, Description="Hyundai Accent Blue 1.6"},
                new Car{CarId=2, BrandId=1, ColorId=2, DailyPrice=450000, ModelYear=2016, Description="Hyundai Accent Blue 1.6"},
                new Car{CarId=3, BrandId=2, ColorId=3, DailyPrice=600000, ModelYear=2006, Description="Audi A3 Hatchback 1.6"},
                new Car{CarId=4, BrandId=3, ColorId=1, DailyPrice=800000, ModelYear=2020, Description="Fiat Egea 1.4"},
                new Car{CarId=5, BrandId=4, ColorId=3, DailyPrice=900000, ModelYear=2011, Description="Mercedes-Benz C 180"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}