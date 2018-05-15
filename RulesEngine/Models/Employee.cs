using System;

namespace RulesEngine.Models
{
    public class Employee
    {
        public string EmployeeNumber { get; set; }

        public int Salary { get; set; }

        public DateTime? Dob { get; set; }
        public int NumYearsInCurrentRole { get; set; }

        /// <summary>
        /// Could be one of "Underperformer", "Meets Expectation", "Exceeds Expectation", "Outstanding"
        /// </summary>
        public string EmployeeRating { get; set; }
    }
}
