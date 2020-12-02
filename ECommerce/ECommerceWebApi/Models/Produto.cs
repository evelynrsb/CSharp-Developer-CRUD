using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.Models
{
    [Table("Produtos")]
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
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O código é inválido.")]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "A descrição do produto deve ter no máximo 1000 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        public bool Status { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O código do departamento é inválido.")]
        public int CodDepartamento { get; set; }

        /*public Departamento Departamento { get; set; }*/
       
    }
}
