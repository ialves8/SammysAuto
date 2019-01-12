using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NIV { get; set; }
        [Required]
        public string Fabricacao { get; set; }
        [Required]
        public string Modelo { get; set; }
        public string Estilo { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public double Quilometragem { get; set; }
        public string Cor { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
