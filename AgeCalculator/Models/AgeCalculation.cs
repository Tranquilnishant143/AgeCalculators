using System.ComponentModel.DataAnnotations;

namespace AgeCalculator.Models
{
    public class AgeCalculation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select Age At Date")]
        [DataType(DataType.Date)]
        public DateTime? AgeAtDate { get; set; }

        // Exact Age
        public int Years { get; set; }

        public int Months { get; set; }

        public int Days { get; set; }

        // Totals
        public int TotalYears { get; set; }

        public int TotalMonths { get; set; }

        public int TotalWeeks { get; set; }

        public int TotalDays { get; set; }

        public long TotalHours { get; set; }

        public long TotalMinutes { get; set; }

        public long TotalSeconds { get; set; }

        // Next Birthday
        public DateTime? NextBirthday { get; set; }
        public int DaysLeft { get; set; }

        // Record Created Date
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}