using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
         public string Upload(List<IFormFile> file, string root);
         public void Delete(string filePath);
         public string Update(List<IFormFile> file, string filePath, string root);
    }
}


