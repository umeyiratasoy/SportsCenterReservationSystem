using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAstroturfDal : EfEntityRepositoryBase<Astroturf, SportsCenterReservationSystemContext>, IAstroturfDal
    {

        public List<AstroturfListDto> GetAstroturfList()
        {
            using (SportsCenterReservationSystemContext context = new SportsCenterReservationSystemContext())
            {
                var result = from ast in context.Astroturfs
                             join fi in context.FieldTypes
                             on ast.TypeId equals fi.Id
                             join ci in context.Cities
                             on ast.CityId equals ci.Id
                             join ds in context.Districts
                             on ast.DistrictId equals ds.Id
                             select new AstroturfListDto
                             {
                                 TypeId = ast.TypeId,
                                 TypeName = fi.TypeName,
                                 CityId = ci.Id,
                                 CityName = ci.CityName,
                                 DistrictId = ds.Id,
                                 DistrictName = ds.DistrictName,
                                 Name = ast.Name,
                                 Address = ast.Address,
                                 About = ast.About,
                                 BusinessContactNumber = ast.BusinessContactNumber,
                                 MobileContactNumber = ast.MobileContactNumber,
                                 Price = ast.Price,
                             };
                return result.ToList();
            }


        }
    }
}
