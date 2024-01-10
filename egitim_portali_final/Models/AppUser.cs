using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace egitim_portali_final.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public string PhotoUrl { get; set; }

    }
}
