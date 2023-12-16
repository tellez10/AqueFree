using AquaFreeWeb.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaFreeWeb.Models
{
    public class Refresco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Marca { get; set; }

        [Required]
        public string? Sabor { get; set; }

        [Required]
        public int Unidad { get; set; }

        [Required]
        public TamEnum Tamanio { get; set; }


    }
}
