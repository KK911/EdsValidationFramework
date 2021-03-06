﻿using System;

namespace ValidationDesign.Entities
{
    public class Employee : BulkImportEntity
    {
        public string EmployeeNumber { get; set; }

        public int Salary { get; set; }

        public DateTime? Dob { get; set; }

        /// <summary>
        /// Could be one of "Underperformer", "Meets Expectation", "Exceeds Expectation", "Outstanding"
        /// </summary>
        public string EmployeeRating { get; set; }
    }
}
