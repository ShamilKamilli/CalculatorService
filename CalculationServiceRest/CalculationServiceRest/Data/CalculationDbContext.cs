using CalculationServiceRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationServiceRest.Data
{
    public class CalculationDbContext:DbContext
    {
        public CalculationDbContext(DbContextOptions<CalculationDbContext> options)
            : base(options) { }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<MethodType> MethodTypes { get; set; }
    }
}
