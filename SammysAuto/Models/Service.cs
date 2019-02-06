using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.Models
{
    public class Service
    {
        public int Id { get; set; }

        public double Quilometragem { get; set; }

        public double Preco { get; set; }

        public string Detalhes { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataServico { get; set; }

        public int CarId { get; set; }

        public int ServiceTypeId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }

    }
}
