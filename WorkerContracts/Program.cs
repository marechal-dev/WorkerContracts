using System;
using System.Globalization;

using WorkerContracts.Entities;
using WorkerContracts.Entities.Enums;

namespace WorkerContracts
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string departmentName = Console.ReadLine();
            Department department = new Department(departmentName);
            
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string workerName = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            string workerLevel = Console.ReadLine();
            Console.Write("Base salary: ");
            double workerBaseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Worker worker = new Worker(workerName, department, workerLevel, workerBaseSalary);
            
            Console.Write("How many contract to this worker?: ");
            int numberOfContracts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfContracts; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Value per hour: ");
                double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int contractDuration = int.Parse(Console.ReadLine());

                HourContract newContract = new HourContract(contractDate, contractValue, contractDuration);
                worker.AddContract(newContract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string searchDateRange = Console.ReadLine();
            string[] monthAndYear = searchDateRange.Split('/');
            int searchMonth = int.Parse(monthAndYear[0]);
            int searchYear = int.Parse(monthAndYear[1]);
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Name: {worker.WorkDepartment.Name}");
            Console.WriteLine($"Income for {searchDateRange}: R$ {worker.Income(searchYear, searchMonth).ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}