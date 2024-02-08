using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using VirginGalactic2.Data;
using VirginGalactic2.Models;

namespace VirginGalactic2.Pages.Bookings
{
    public class BookModel : PageModel
    {
        private readonly VirginGalactic2.Data.VirginGalactic2Context _context;

        public BookModel(VirginGalactic2Context context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Booking Booking { get; set; }
        public List<Booking> Bookings { get; set; }
        
        
        public string IsHidden { get; set; } = "hidden";

        [BindProperty]
        [Required(ErrorMessage = "Please enter name!")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter the age!")]
        [Range(18, 1000, ErrorMessage = "Traveller MUST be between the ages of 18 and 1000!")]
        public int Age { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must choose a gender!")]
        public string Gender { get; set; }

        [BindProperty]
        public string Origin { get; set; }
        public string[] OriginList = { "Earth - Virgin Galactic Universal Spaceport"};

        [BindProperty]
        public string Destination { get; set; }
        public string[] DestinationList = {"Mars - SpaceX Universal Spaceport", "Saturn - ESA Universal Spaceport", "Proxima Centauri - James Webb NASA Universal Spaceport" };

        [BindProperty]
        public DateTime DepartureDateTime { get; set; } = DateTime.Today;

        [BindProperty]
        [Required(ErrorMessage = "Please choose ONE seat!")]
        public string Seat {  get; set; }
        public string[] Row1List = { "", "1A", "1B", "1C", "1D", "" };
        public string[] Row2List = { "", "2A", "2B", "2C", "2D", "" };
        public string[] Row3List = { "", "3A", "3B", "3C", "3D", "" };
        public string[] Row4List = { "", "4A", "4B", "4C", "4D", "" };
        public string[] Row5List = { "5S1", "5A", "5B", "5C", "5D", "5S2" };

        public string Errors { get; set; }
        public string BookingDateTest { get; set; }

        public void OnGet()
        {
        }

        public void OnPostShowSeat()
        {
            IsHidden = "";
            
        }

        public async Task<IActionResult> OnPostReserveAsync()
        {
            var booking = from o in _context.Booking where o.Name.Contains(Name) && o.Age == Age && o.DepartureDate == DepartureDateTime select o;
            int chk = (from o in _context.Booking where o.Name.Contains(Name) && o.Age == Age && o.DepartureDate == DepartureDateTime select o.ID).Count();
            Bookings = await booking.ToListAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else if(DepartureDateTime < DateTime.Now.AddDays(1))
            {
                Errors = "Please choose a Departure Date that is at least 1 day in advance!";
                return Page();
            }
            else if(chk > 0)
            {
                Errors = "You can't book more than once for the same date!";
                return Page();
            }
            else
            {
                Booking.DepartureDate = DepartureDateTime;
                _context.Booking.Add(Booking);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Success", new {Name = Booking.Name, Destination = Booking.Destination});
            }

            
        }

        
    }
}
