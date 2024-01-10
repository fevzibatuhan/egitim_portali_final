using egitim_portali_final.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace egitim_portali_final.ViewModels
{
    public class UserModel 
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public AppRole Role { get; set; }  
    }
}
