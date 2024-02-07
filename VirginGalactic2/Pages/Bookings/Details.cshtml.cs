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
    public class DetailsModel : PageModel
    {
        private readonly VirginGalactic2.Data.VirginGalactic2Context _context;

        public DetailsModel(VirginGalactic2.Data.VirginGalactic2Context context)
        {
            _context = context;
        }

        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
