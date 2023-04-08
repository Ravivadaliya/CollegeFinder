using System.ComponentModel.DataAnnotations;
namespace CollegeFinder.Areas.College.Models
{
    public class CollegeModel
    {
        public int? Collegeid { get; set; }

        [Required]
        [Display(Name = "College Name")]
        [StringLength(35, MinimumLength = 4)]
        public string College_Name { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [StringLength(10, MinimumLength = 2)]
        public string Genders_Accepted { get; set; }

        [Required]
        [Display(Name = "Campus Size")]
        [StringLength(10, MinimumLength = 4)]
        public string Campus_Size { get; set; }

        [Required]
        [Display(Name = "Total Student")]
        [StringLength(5, MinimumLength = 1)]
        public string Total_Student_Enrollments { get; set; }

        [Required]
        [Display(Name = "Total Faculty")]
        [StringLength(4, MinimumLength = 1)]
        public string Total_Faculty { get; set; }

        [Required]
        [Display(Name = "Establish Year")]
        [StringLength(4, MinimumLength = 4)]
        public string Established_Year { get; set; }


        [Required]
        [Display(Name = "Rating")]
        [StringLength(4, MinimumLength = 1)]
        public string Rating { get; set; }

        [Required]
        [Display(Name = "University required")]
        [StringLength(20, MinimumLength = 4)]
        public string University { get; set; }

        [Required]
        [Display(Name = "Coures")]
        [StringLength(100, MinimumLength = 4)]
        public string Courses { get; set; }

        [Required]
        [Display(Name = "Facilities")]
        [StringLength(70, MinimumLength = 4)]
        public string Facilities { get; set; }

        [Required]
        [Display(Name = "City required")]
        [StringLength(9, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [Display(Name = "State required")]
        [StringLength(20, MinimumLength = 3)]
        public string State { get; set; }

        [Required]
        [Display(Name = "Country required")]
        [StringLength(10, MinimumLength = 2)]
        public string Country { get; set; }

        [Required]
        [Display(Name = "College Type ")]
        [StringLength(10, MinimumLength = 3)]
        public string College_Type { get; set; }

        [Required]
        [Display(Name = "Average Fees")]
        [StringLength(10, MinimumLength = 5)]
        public string Average_Fees { get; set; }

        [Required]
        [Display(Name = "Placement")]
        public int Placement { get; set; }

        [Required]
        [Display(Name = "College Area")]
        public int? College_area { get; set; }

        [Required]
        [Display(Name = "Totalseat")]
        public int Totalseat { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        [StringLength(10, MinimumLength = 5)]
        public string latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        [StringLength(10, MinimumLength = 5)]
        public string longitude { get; set; }

    }
}
