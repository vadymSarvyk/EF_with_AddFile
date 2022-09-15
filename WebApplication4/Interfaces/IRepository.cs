using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Interfaces
{
   public interface IRepository
    {
        IEnumerable<Phone> GetPhones();
         Task AddFileToDB(IFormFile uploadedFile);
    }
}
