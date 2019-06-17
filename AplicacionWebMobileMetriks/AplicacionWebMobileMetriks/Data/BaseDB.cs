using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Data
{
    public class BaseDB:IdentityDbContext
    {
        public BaseDB(DbContextOptions<BaseDB> opciones)
            :base(opciones)
        {
                
        }
    }
}
