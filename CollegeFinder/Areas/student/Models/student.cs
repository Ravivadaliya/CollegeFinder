namespace CollegeFinder.Areas.student.Models
{
    public class student
    {
        public int? studentid { get; set; }
        public string collegeid { get; set; }
        public string studentname { get; set; }
        public string studentmobile { get; set; }
        public string studentmailid { get; set; }
      
        public string city { get; set; }
        public string state { get; set; }
        public DateOnly creationdate { get; set; }
    }
}
