using AplicacionWebMobileMetriks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Data
{
    public class BaseDB:DbContext
    {
        public BaseDB(DbContextOptions<BaseDB> opciones)
            :base(opciones)
        {   
        }
        public DbSet<Emisor> emisor { get; set; }
    }
}
