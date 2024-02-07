using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VirginGalactic2.Data;
using VirginGalactic2.Models;

namespace VirginGalactic2.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly VirginGalactic2.Data.VirginGalactic2Context _context;

        public IndexModel(VirginGalactic2.Data.VirginGalactic2Context context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking.ToListAsync();
        }
    }
}
