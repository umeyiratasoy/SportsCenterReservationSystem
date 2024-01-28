using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAstroturfService
    {

        IDataResult<List<Astroturf>> GetList();
        IDataResult<List<AstroturfListDto>> GetAstroturfList();

        IDataResult<Astroturf> GetById(int id);
        IDataResult<List<AstroturfListDto>> GetAstroturfsByCityDistrict(int fieldId, int cityId, int districtsId);
        IResult Add(Astroturf astroturf);
        IResult Update(Astroturf astroturf);
        IResult Delete(Astroturf astroturf);
    }
}
