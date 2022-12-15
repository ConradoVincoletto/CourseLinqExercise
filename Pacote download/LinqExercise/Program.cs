using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using LinqExercise.Entities;

namespace LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the data of Path:");
            string path = Console.ReadLine();

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] vs = sr.ReadLine().Split(',');
                    string name = vs[0];
                    string email = vs[1];
                    double salary = double.Parse(vs[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }

                Console.Write("Enter the salary: ");
                double thanSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Email of people whose salary is more than 2000.00: ");

                var orderEmail = list.Where(p => p.Salary >= thanSalary)
                    .OrderBy(p => p.Email)
                    .Select(p => p.Email);
                foreach (string email in orderEmail)
                {
                    Console.WriteLine(email);
                }


                var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                Console.WriteLine("Sum of employees  whose  whith starts letter 'M':" + sum);


            }

        }
    }
}
