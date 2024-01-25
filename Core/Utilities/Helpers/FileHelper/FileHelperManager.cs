﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {

        public string Upload(List<IFormFile> file, string root) // IFormFile: HttpRequest ile gönderilen bir dosyayı temsil eder.
        {
            StringBuilder builder = new StringBuilder();


            if (file.Count > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                foreach (var item in file)
                {
                    var extension = Path.GetExtension(item.FileName);
                    string guid = Guid.NewGuid().ToString(); //Eşsiz isim
                    var path = guid + extension;

                    builder.Append(path + "");
                    FileStream fileStream = File.Create(root + path); //belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olur.
                    item.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            return builder.ToString();
        }
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        public string Update(List<IFormFile> file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }


    }
}


