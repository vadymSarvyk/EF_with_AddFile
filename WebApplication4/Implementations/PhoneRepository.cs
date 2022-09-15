using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.DB;
using WebApplication4.Interfaces;
using WebApplication4.Models;

namespace WebApplication4.Implementations
{
    public class PhoneRepository : IRepository
    {
        MobileContext db;
        IWebHostEnvironment appEnvironment;
        public PhoneRepository(MobileContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            this.appEnvironment = appEnvironment;
        }
        public IEnumerable<Phone> GetPhones()
        {
            return db.Phones.ToList();
        }
        public async Task AddFileToDB(IFormFile uploadedFile) {
            string path = "/Files/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
            db.Files.Add(file);
            db.SaveChanges();
        }
    }
}
