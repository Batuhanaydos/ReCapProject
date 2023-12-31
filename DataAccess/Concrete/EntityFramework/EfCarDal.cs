﻿using Azure;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.CarId equals b.BrandId
                             join c1 in context.Colors
                             on c.ColorId equals c1.ColorId
                             select new CarDetailDto
                             {
                                CarId = c.CarId,
                                CarName = c.CarName,
                                BrandName = b.BrandName,
                                ColorName = c1.ColorName,
                                DailyPrice = c.DailyPrice
                             };
                          return result.ToList(); 
            }
        }
    }
}
