using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Tamanho do {0} deve estar entre {2} e {1}")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public DateTime Aniversario { get; set; }

        [Display(Name = "Salário")]
        [Range(100.0, 50000.0, ErrorMessage = "O {0} deve estar entre {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public double Salario_Base { get; set; }

        public Department Department{ get; set; }

        [Display(Name = "Departamento")]
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
