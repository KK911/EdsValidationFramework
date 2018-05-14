using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ValidationDesign.Validation.Validators;

namespace ValidationDesign
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ImportEmployees();
        }

        private static void ImportEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee // Valid entry
                {
                    EmployeeNumber = "1001",
                    ExternalId = "1001",
                    Dob = DateTime.Today.AddYears(-35),
                    EmployeeRating = "Meets Expectation",
                    Salary = 150000
                },
                new Employee
                {
                    ExternalId = "1002", // EmployeeNumber, a required field is not provided here. 
                    Dob = DateTime.Today.AddYears(-40),
                    EmployeeRating = "Outstanding",
                    Salary = 150000
                },
                new Employee
                {
                    EmployeeNumber = "1003",
                    ExternalId = "1003",
                    Dob = DateTime.Today.AddYears(-45),
                    EmployeeRating = "Exceeds Expectation",
                    Salary = 1500000 // Expect this to be caught by range validator
                },
                new Employee
                {
                    EmployeeNumber = "1004",
                    ExternalId = "1004",
                    Dob = DateTime.Today.AddYears(-65),
                    EmployeeRating = "Overachiever", // Expect this to be caught by custom validator
                    Salary = 10000000
                }
            };

            var validator = new EmployeeValidator();
            foreach (var employee in employees)
            {
                var validationSummary = validator.Validate(employee);
                Console.WriteLine();
                Console.WriteLine($"Validation Errors: {JsonConvert.SerializeObject(validationSummary, Formatting.Indented)}");
            }
        }
    }
}
