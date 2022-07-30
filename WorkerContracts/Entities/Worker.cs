using System;
using System.Collections.Generic;

using WorkerContracts.Entities;
using WorkerContracts.Entities.Enums;

namespace WorkerContracts.Entities
{
    public class Worker
    {
        public string Name { get; private set; }
        public Department WorkDepartment { get; private set; }
        public WorkerLevel Level { get; private set; }
        public double BaseSalary { get; private set; }
        public List<HourContract> HourContracts { get; private set; }

        public Worker(string name, Department workDepartment, WorkerLevel level, double baseSalary)
        {
            Name = name;
            WorkDepartment = workDepartment;
            Level = level;
            BaseSalary = baseSalary;
            HourContracts = new List<HourContract>();
        }

        public Worker(string name, Department workDepartment, string level, double baseSalary)
        {
            Name = name;
            WorkDepartment = workDepartment;
            Level = Enum.Parse<WorkerLevel>(level);
            BaseSalary = baseSalary;
            HourContracts = new List<HourContract>();
        }

        public void AddContract(HourContract contract)
        {
            HourContracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            HourContracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            List<HourContract> contractsInRange = HourContracts.FindAll((contract) =>
                contract.Date.Year == year 
                && contract.Date.Month == month
            );

            double incomeForGivenRange = BaseSalary;

            foreach (HourContract contract in contractsInRange)
            {
                incomeForGivenRange += contract.TotalValue();
            }

            return incomeForGivenRange;
        }
    }
}
