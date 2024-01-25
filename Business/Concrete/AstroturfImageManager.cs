using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(astroturfImage.AstroturfId));
            if (result != null)
            {
                return result;
            }
            astroturfImage.ImagePath = _fileHelper.Upload(formFile, PathConstant.ImagesPath);
            astroturfImage.Date = DateTime.Now;

            _astroturfImageDal.Add(astroturfImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(AstroturfImage astroturfImage)
        {
            var carToBeDeleted = _astroturfImageDal.Get(c => c.Id == astroturfImage.Id);
            if (carToBeDeleted == null)
            {
                return new ErrorResult(Messages.CarImageDeleteError);
            }
            _fileHelper.Delete(carToBeDeleted.ImagePath);
            _astroturfImageDal.Delete(astroturfImage);
            return new SuccessResult(Messages.CarImageDeleteSuccess);
        }

        public IDataResult<List<AstroturfImage>> GetAll()
        {

            return new SuccessDataResult<List<AstroturfImage>>(_astroturfImageDal.GetList().ToList());
        }

        public IDataResult<List<AstroturfImage>> GetByCarId(int astroturfId)
        {
            var result = BusinessRules.Run(CheckIfCarImageAdded(astroturfId));
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
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageAdded(int astroturfImageId)
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
        private IResult CheckIfCarImageLimitExceeded(int astroturfId)
        {
            var result = _astroturfImageDal.GetList(c => c.AstroturfId == astroturfId);
            if (result.Count > 5)
            {
                return new ErrorResult("Limit ");
            }
            return new SuccessResult();
        }

        public IDataResult<List<AstroturfImage>> GetCarImagesByCarId(int astroturfId)
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