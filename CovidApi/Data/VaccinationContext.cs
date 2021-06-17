using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CovidApi.Models;

namespace CovidApi.Data
{
    public class VaccinationContext : DbContext
    {
        public VaccinationContext (DbContextOptions<VaccinationContext> options)
            : base(options)
        {
        }

        public DbSet<CovidApi.Models.Vaccination> Vaccination { get; set; }
    }
}
