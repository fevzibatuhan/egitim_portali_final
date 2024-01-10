namespace egitim_portali_final.Models
{
    public class Education
    {
        public int Id { get; set; }

        public string TeachersUserName { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }



    }
}
