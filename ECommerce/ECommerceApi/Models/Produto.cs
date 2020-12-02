using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Models
{
    public class Produto
    {
        public Produto()
        {
        }

        public Produto(int id, int codigo, string descricao, decimal preco, bool status, int codDepartamento)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            Status = status;
            CodDepartamento = codDepartamento;
        }

        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int CodDepartamento { get; set; }

        
    }
}
