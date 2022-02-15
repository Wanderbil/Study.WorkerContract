using System;
using System.Collections.Generic;
using WorkContract.Entities.Enums;
using WorkContract.Entities;
using System.Globalization;

namespace WorkContract
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter work data ");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Work Level (Junior/MidLevel/Senior): ");
            WorkerLevel workerlevel = new WorkerLevel();
            Enum.TryParse(Console.ReadLine(), out workerlevel);

            Console.WriteLine("Base Salary: ");
            double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            // instantiating

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, workerlevel, basesalary, dept);


            Console.WriteLine("How many contracts for this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                Console.WriteLine();

                worker.AddContract(contract);
            }
                                  
            Console.WriteLine("Enter month and year to calculate income: ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2)); // Cutting month
            int year = int.Parse(monthAndYear.Substring(3)); // Cutting year

            Console.Write("Name:" + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for "+ monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));









        }
    }
}
