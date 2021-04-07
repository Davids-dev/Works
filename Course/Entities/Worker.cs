using System;
using Course.Entities.Enums; //enum WorkerLevel
using System.Collections.Generic;


namespace Course.Entities
{
    class Worker
    {
        //atributos da classe
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //associação entre duas classes diferentes
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //já instancio para garantir que ela não é nula.
        //construtores
        public Worker()
        {
        }
        
        public Worker(string name, WorkerLevel level, double baseSalary, Department department) //meu construtor não deve ter uma associação para muitos
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract (HourContract contract)
        {
            Contracts.Add(contract); //vai adicionar na lista de contratos, os contratos (class program) 
        }

        public void RemoveContract (HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income (int year, int month)
        {
            double sum = BaseSalary; //salario do meu funcionario independente de ele ter contratos ou não, ele vai receber seu salário

            foreach (HourContract contract in Contracts) //para cada contrato na Fila de Contratos
            {
                if (contract.Date.Year == year && contract.Date.Month == month) //se o ano do contrato e o mes do contrato for igual ao parametro do Income
                {
                    sum += contract.TotalValue(); //soma seu salario base + o valor do contrato.TotalValue() função do HourContract
                }
            }
            return sum;
        }
    }
}
