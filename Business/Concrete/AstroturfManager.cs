using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
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

        [SecuredOperation("Customer")]
        [CacheRemoveAspect("AstroturfService.Get")]
        public IResult Add(Astroturf astroturf)
        {
            IResult result = BusinessRules.Run(/*targets*/);
            if (result != null)
            {
                return result;
            }
            _astroturfDal.Add(astroturf);
            return new SuccessResult(Messages.AstroturfAdded);
        }

        [SecuredOperation("Customer")]
        [CacheRemoveAspect("AstroturfService.Get")]
        public IResult Delete(Astroturf astroturf)
        {
            _astroturfDal.Delete(astroturf);
            return new SuccessResult(Messages.AstroturfDeleted);
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<AstroturfListDto>> GetAstroturfList()
        {
            return new SuccessDataResult<List<AstroturfListDto>>(_astroturfDal.GetAstroturfList().ToList());
        }

        public IDataResult<List<AstroturfListDto>> GetAstroturfsByCityDistrict(int fieldId, int cityId, int districtsId)
        {
            return new SuccessDataResult<List<AstroturfListDto>>(
                _astroturfDal.GetAstroturfList().Where(c => c.TypeId == fieldId && c.CityId == cityId && c.DistrictId == districtsId).ToList());
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Astroturf> GetById(int id)
        {
            return new SuccessDataResult<Astroturf>(_astroturfDal.Get(a => a.Id == id));
        }

        //[PerformanceAspect(5)]
        public IDataResult<List<Astroturf>> GetList()
        {
            return new SuccessDataResult<List<Astroturf>>(_astroturfDal.GetList().ToList());
        }

        [SecuredOperation("Customer")]
        [CacheRemoveAspect("AstroturfService.Get")]
        public IResult Update(Astroturf astroturf)
        {
            _astroturfDal.Update(astroturf);
            return new SuccessResult(Messages.AstroturfUpdated);
        }
    }
}
