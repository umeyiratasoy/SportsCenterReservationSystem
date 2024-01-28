using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AstroturfImageManager : IAstroturfImageService
    {
        IAstroturfImageDal _astroturfImageDal;
        IFileHelper _fileHelper;

        public AstroturfImageManager(IAstroturfImageDal astroturfImageDal, IFileHelper fileHelper)
        {
            _astroturfImageDal = astroturfImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(List<IFormFile> formFile, AstroturfImage astroturfImage)
        {

            IResult result = BusinessRules.Run(CheckIfAstroturfImageLimitExceeded(astroturfImage.AstroturfId));
            if (result != null)
            {
                return result;
            }
            astroturfImage.ImagePath = _fileHelper.Upload(formFile, PathConstant.ImagesPath);
            astroturfImage.Date = DateTime.Now;

            _astroturfImageDal.Add(astroturfImage);
            return new SuccessResult(Messages.AstroturfImageAdded);

        }

        public IResult Delete(AstroturfImage astroturfImage)
        {
            var astroturfToBeDeleted = _astroturfImageDal.Get(c => c.Id == astroturfImage.Id);
            if (astroturfToBeDeleted == null)
            {
                return new ErrorResult(Messages.AstroturfImageDeleteError);
            }
            _fileHelper.Delete(astroturfToBeDeleted.ImagePath);
            _astroturfImageDal.Delete(astroturfImage);
            return new SuccessResult(Messages.AstroturfImageDeleteSuccess);
        }

        public IDataResult<List<AstroturfImage>> GetAll()
        {

            return new SuccessDataResult<List<AstroturfImage>>(_astroturfImageDal.GetList().ToList());
        }

        public IDataResult<List<AstroturfImage>> GetByAstroturfId(int astroturfId)
        {
            var result = BusinessRules.Run(CheckIfAstroturfImageAdded(astroturfId));
            if (result != null)
            {
                return new ErrorDataResult<List<AstroturfImage>>(GetDefaultImage(astroturfId).Data);
            }
            return new SuccessDataResult<List<AstroturfImage>>(_astroturfImageDal.GetList(c => c.AstroturfId == astroturfId).ToList());
        }

        public IDataResult<AstroturfImage> GetById(int astroturfImageId)
        {
            return new SuccessDataResult<AstroturfImage>(_astroturfImageDal.Get(c => c.AstroturfId == astroturfImageId));
        }

        public IResult Update(List<IFormFile> file, AstroturfImage astroturfImage)
        {
            var result = _astroturfImageDal.Get(c => c.Id == astroturfImage.Id);
            astroturfImage.ImagePath = _fileHelper.Update(file, PathConstant.ImagesPath + result.ImagePath, PathConstant.ImagesPath);
            astroturfImage.Date = DateTime.Now;
            _astroturfImageDal.Update(astroturfImage);
            return new SuccessResult(Messages.AstroturfImageUpdated);
        }

        private IResult CheckIfAstroturfImageAdded(int astroturfImageId)
        {

            var result = _astroturfImageDal.GetList(c => c.AstroturfId == astroturfImageId);
            if (result.Count == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<AstroturfImage>> GetDefaultImage(int astroturfImageId)
        {
            List<AstroturfImage> astroturf = new List<AstroturfImage> { new AstroturfImage { AstroturfId = astroturfImageId, ImagePath = "Default.png" } };
            return new SuccessDataResult<List<AstroturfImage>>(astroturf);
        }
        private IResult CheckIfAstroturfImageLimitExceeded(int astroturfId)
        {
            var result = _astroturfImageDal.GetList(c => c.AstroturfId == astroturfId);
            if (result.Count > 10)
            {
                return new ErrorResult("Limit ");
            }
            return new SuccessResult();
        }

        public IDataResult<List<AstroturfImage>> GetAstroturfImagesByAstroturfId(int astroturfId)
        {
            var data = _astroturfImageDal.GetList(cI => cI.AstroturfId == astroturfId).ToList();
            if (data.Count == 0)
            {
                data.Add(new AstroturfImage
                {
                    AstroturfId = astroturfId,
                    ImagePath = "Default.png"
                });
            }
            return new SuccessDataResult<List<AstroturfImage>>(data);
        }
    }

}