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

        IResult Add(Astroturf astroturf);
    }
}
