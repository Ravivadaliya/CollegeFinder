namespace CollegeFinder.Models
{
    public class AdmissionModel
    {
        public int Studentid { get; set; }
        public int Collegeid { get; set; }
        public string Studentname { get; set; }
        public string Studentmobile { get; set; }
        public string StudentEmail { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateOnly? Creationdate { get; set; }
    }
} 
