using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAstroturfImageService
    {
        IDataResult<List<AstroturfImage>> GetAll();
        IDataResult<AstroturfImage> GetById(int astroturfImageId);
        IDataResult<List<AstroturfImage>> GetByAstroturfId(int astroturfId);
        IResult Add(List<IFormFile> formFile, AstroturfImage astroturfImage);
        IResult Delete(AstroturfImage astroturfImage);

        IDataResult<List<AstroturfImage>> GetAstroturfImagesByAstroturfId(int astroturfId);
        IResult Update(List<IFormFile> file, AstroturfImage astroturfImage);
    }
}
