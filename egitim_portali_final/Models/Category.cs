namespace egitim_portali_final.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Education> Educations { get; set; }
    }
}