using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacersCommunity.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? Milage { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Club { get; set; }
        public ICollection<Race> Race { get; set; }
    }
}
