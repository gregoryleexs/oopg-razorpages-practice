using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace VirginGalactic2.Pages.Bookings
{
    public class SuccessModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name {  get; set; }

        [BindProperty(SupportsGet = true)]
        public string Destination { get; set; }
    }
}
