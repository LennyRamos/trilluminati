using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoQusApi.Models.Contexts
{
    public class FoQusContext : DbContext
    {
        public FoQusContext(DbContextOptions<FoQusContext> options)
            : base(options)
        {
        }

        public DbSet<FoQusItem> FoQusItems { get; set; }
    }
}
