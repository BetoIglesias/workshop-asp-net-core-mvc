using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
        public double Salario_Base { get; set; }

        public Department Department{ get; set; }
        public int DepartmentId { get; set; }


        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        
        public Seller()
        {

        }

        public Seller(int id, string nome, string email, DateTime aniversario, double salario_Base, Department department)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            Salario_Base = salario_Base;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return Sales.Where(sr => sr.Data >= initialDate && sr.Data <= finalDate).Sum(sr => sr.Valor);
        }
    }   
}
