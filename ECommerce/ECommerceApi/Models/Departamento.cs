using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Models
{
    [Table("Departamentos")]
    public class Departamento
    {
        public Departamento(string id, int codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O código é inválido.")]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O nome do departamento deve ter no máximo 250 caracteres.")]
        public string Nome { get; set; }
        
    }
}
