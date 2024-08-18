using System;
using System.Collections.Generic;

// Base Employee class
public class Employee
{
    // Common properties
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string ReportingManager { get; set; }

    // Constructor
    public Employee(int empId, string name, string reportingManager)
    {
        EmpId = empId;
        Name = name;
        ReportingManager = reportingManager;
    }
}

// Subclass for Contract Employees
public class ContractEmployee : Employee
{
    // Additional properties specific to Contract Employees
    public DateTime ContractDate { get; set; }
    public int DurationMonths { get; set; }
    public decimal Charges { get; set; }

    // Constructor
    public ContractEmployee(int empId, string name, string reportingManager, DateTime contractDate, int durationMonths, decimal charges)
        : base(empId, name, reportingManager)
    {
        ContractDate = contractDate;
        DurationMonths = durationMonths;
        Charges = charges;
    }
}

// Subclass for Payroll Employees
public class PayrollEmployee : Employee
{
    // Additional properties specific to Payroll Employees
    public DateTime JoiningDate { get; set; }
    public int ExperienceYears { get; set; }
    public decimal BasicSalary { get; set; }

    // Constructor
    public PayrollEmployee(int empId, string name, string reportingManager, DateTime joiningDate, int experienceYears, decimal basicSalary)
        : base(empId, name, reportingManager)
    {
        JoiningDate = joiningDate;
        ExperienceYears = experienceYears;
        BasicSalary = basicSalary;
    }

    // Method to calculate net salary
    public decimal CalculateNetSalary()
    {
        decimal da, hra;

        if (ExperienceYears >= 10)
        {
            da = 0.10m * BasicSalary;
            hra = 0.085m * BasicSalary;
        }
        else if (ExperienceYears >= 7)
        {
            da = 0.07m * BasicSalary;
            hra = 0.065m * BasicSalary;
        }
        else if (ExperienceYears >= 5)
        {
            da = 0.041m * BasicSalary;
            hra = 0.052m * BasicSalary;
        }
        else
        {
            da = 0.019m * BasicSalary;
            hra = 0.020m * BasicSalary;
        }

        decimal netSalary = BasicSalary + da + hra - 6200 - 4100; 
        return netSalary;
    }
}

class Program
{
    static void Main()
    {
      
        ContractEmployee contractEmp = new ContractEmployee(1, "John Doe", "Manager A", new DateTime(2024, 7, 1), 12, 5000);
        PayrollEmployee payrollEmp = new PayrollEmployee(2, "Jane Smith", "Manager B", new DateTime(2023, 1, 15), 8, 60000);

        Console.WriteLine("Contract Employee Details:");
        Console.WriteLine($"Employee ID: {contractEmp.EmpId}");
        Console.WriteLine($"Name: {contractEmp.Name}");
        Console.WriteLine($"Reporting Manager: {contractEmp.ReportingManager}");
        Console.WriteLine($"Contract Date: {contractEmp.ContractDate}");
        Console.WriteLine($"Duration (months): {contractEmp.DurationMonths}");
        Console.WriteLine($"Charges: {contractEmp.Charges}");

        Console.WriteLine("\nPayroll Employee Details:");
        Console.WriteLine($"Employee ID: {payrollEmp.EmpId}");
        Console.WriteLine($"Name: {payrollEmp.Name}");
        Console.WriteLine($"Reporting Manager: {payrollEmp.ReportingManager}");
        Console.WriteLine($"Joining Date: {payrollEmp.JoiningDate}");
        Console.WriteLine($"Experience (years): {payrollEmp.ExperienceYears}");
        Console.WriteLine($"Basic Salary: {payrollEmp.BasicSalary}");
        Console.WriteLine($"Net Salary: {payrollEmp.CalculateNetSalary()}");

        // Handling multiple employees
        List<Employee> employees = new List<Employee>();
        employees.Add(contractEmp);
        employees.Add(payrollEmp);

        Console.WriteLine($"\nTotal number of employees: {employees.Count}");

        foreach (Employee emp in employees)
        {
            if (emp is ContractEmployee)
            {
                Console.WriteLine("\nContract Employee Details:");
                ContractEmployee contractEmployee = (ContractEmployee)emp;
                Console.WriteLine($"Employee ID: {contractEmployee.EmpId}");
                Console.WriteLine($"Name: {contractEmployee.Name}");
                Console.WriteLine($"Reporting Manager: {contractEmployee.ReportingManager}");
                Console.WriteLine($"Contract Date: {contractEmployee.ContractDate}");
                Console.WriteLine($"Duration (months): {contractEmployee.DurationMonths}");
                Console.WriteLine($"Charges: {contractEmployee.Charges}");
            }
            else if (emp is PayrollEmployee)
            {
                Console.WriteLine("\nPayroll Employee Details:");
                PayrollEmployee payrollEmployee = (PayrollEmployee)emp;
                Console.WriteLine($"Employee ID: {payrollEmployee.EmpId}");
                Console.WriteLine($"Name: {payrollEmployee.Name}");
                Console.WriteLine($"Reporting Manager: {payrollEmployee.ReportingManager}");
                Console.WriteLine($"Joining Date: {payrollEmployee.JoiningDate}");
                Console.WriteLine($"Experience (years): {payrollEmployee.ExperienceYears}");
                Console.WriteLine($"Basic Salary: {payrollEmployee.BasicSalary}");
                Console.WriteLine($"Net Salary: {payrollEmployee.CalculateNetSalary()}");
            }
        }

        Console.ReadLine();
    }
}





