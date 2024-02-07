using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirginGalactic2.Models;

namespace VirginGalactic2.Data
{
    public class VirginGalactic2Context : DbContext
    {
        public VirginGalactic2Context (DbContextOptions<VirginGalactic2Context> options)
            : base(options)
        {
        }

        public DbSet<VirginGalactic2.Models.Booking> Booking { get; set; } = default!;
    }
}
