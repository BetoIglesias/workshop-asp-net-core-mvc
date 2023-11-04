using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id  { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public SalesStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {

        }

        public SalesRecord(int id, DateTime data, double valor, SalesStatus status, Seller seller)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Seller = seller;
        }
    }
}
