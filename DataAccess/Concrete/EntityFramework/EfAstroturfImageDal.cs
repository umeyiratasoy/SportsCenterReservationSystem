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
    public class EfAstroturfImageDal : EfEntityRepositoryBase<AstroturfImage, SportsCenterReservationSystemContext>, IAstroturfImageDal
    {
    }
}
