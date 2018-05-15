using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using RulesEngine.Core;
using RulesEngine.Models;
using RulesEngine.Rules;
using Formatting = Newtonsoft.Json.Formatting;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
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
                    Dob = DateTime.Today.AddYears(-35),
                    EmployeeRating = "Meets Expectation",
                    Salary = 150000,
                    NumYearsInCurrentRole = 2
                },
                new Employee
                {
                    Dob = DateTime.Today.AddYears(-40),
                    EmployeeRating = "Outstanding",
                    Salary = 150000,
                    NumYearsInCurrentRole = 2
                },
                new Employee
                {
                    EmployeeNumber = "1003",
                    Dob = DateTime.Today.AddYears(-45),
                    EmployeeRating = "Exceeds Expectation",
                    Salary = 150000, // Expect this to be caught by range validator
                    NumYearsInCurrentRole = 3
                },
                new Employee
                {
                    EmployeeNumber = "1004",
                    Dob = DateTime.Today.AddYears(-33),
                    EmployeeRating = "Overachiever", // Expect this to be caught by custom validator
                    Salary = 100000,
                    NumYearsInCurrentRole = 4
                }
            };

            foreach (var employee in employees)
            {
                var ruleEngine = new RuleEngine<Employee>(employee);
                var result = ruleEngine
                    .ApplyRules(new EmployeeNumberRequiredFieldRule(), 
                        new EmployeeSalaryRangeRule(),
                        new EmployeeConsistentPerformerRule(),
                        new EmployeeBonusEligibilityRule())
                    .Execute();
                Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
