namespace CollegeFinder.Models
{
    public class Contact_SendModel
    {
        public int? Contact_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Message { get; set; }
        public DateTime? Creationdate { get; set; }

    }
}
