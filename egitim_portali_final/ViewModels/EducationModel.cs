using egitim_portali_final.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace egitim_portali_final.ViewModels
{
    public class EducationModel
    {
        public int Id { get; set; }

        public string TeachersUserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Link { get; set; }

        [NotMapped]
        public IFormFile Video { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public Category Category { get; set; }



    }
}