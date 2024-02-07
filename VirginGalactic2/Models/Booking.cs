using System.ComponentModel.DataAnnotations;

namespace VirginGalactic2.Models
{
    public class Booking
    {
        public int ID { get; set; } //REQUIRED column for DB
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        public float Cost { get; set; }
    }
}
