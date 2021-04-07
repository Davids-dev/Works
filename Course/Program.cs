using System;
using Course.Entities.Enums;
using Course.Entities;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //chamar o enum e converter
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName); //instanciei meu departamento com o parametro de entrada com seu department

            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine($"Enter #{i}  contract data: "); // {i} == interpolação, para funcionar, devo colocar o simbolo de cifrão no ínicio.
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hour): ");
                int hour = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hour); //primeiro instancio a minha classe contract
                worker.AddContract(contract); //adiciono os contratos na lista de contratos do trabalhador
            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int mouth = int.Parse(monthAndYear.Substring(0, 2)); //a variavel int mouth vai receber a string monthAndYear e vai cortar em pedaços
                                                                 //o primeiro pedaço para o mês
            int year = int.Parse(monthAndYear.Substring(3));//o segundo pedaço em diante para o ano
            Console.WriteLine("Name: " + worker.Name); //exibidando o nome do trabalhador objeto.atributo
            Console.WriteLine("Department: " + worker.Department.Name); //exibindo o departamento do trabalhador, com o objeto(worker).atributo/Classe(Department).Name(nome do atributo da classe Department)
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, mouth).ToString("F2", CultureInfo.InvariantCulture)); // trazendo a função do worker.income dando como parametro o ano e mes.



        }
    }
}
