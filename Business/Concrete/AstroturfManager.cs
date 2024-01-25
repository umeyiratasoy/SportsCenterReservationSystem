using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AstroturfManager : IAstroturfService
    {
        private IAstroturfDal _astroturfDal;
        public AstroturfManager(IAstroturfDal astroturfDal)
        {
            _astroturfDal = astroturfDal;
        }

        [SecuredOperation("Musteri")]
        public IResult Add(Astroturf astroturf)
        {
            _astroturfDal.Add(astroturf);
            return new SuccessResult("Eklendi");
        }

        public IDataResult<List<AstroturfListDto>> GetAstroturfList()
        {
            return new SuccessDataResult<List<AstroturfListDto>>(_astroturfDal.GetAstroturfList().ToList());
        }

        public IDataResult<List<Astroturf>> GetList()
        {
            return new SuccessDataResult<List<Astroturf>>(_astroturfDal.GetList().ToList());
        }


    }
}
