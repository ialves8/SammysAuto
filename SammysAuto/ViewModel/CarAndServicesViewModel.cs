using SammysAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.ViewModel
{
    public class CarAndServicesViewModel
    {
        public int carId { get; set; }
        public string NIV { get; set; }
        public string Fabricacao { get; set; }
        public string Modelo { get; set; }
        public string Estilo { get; set; }
        public int Ano { get; set; }

        public string UserId { get; set; }

        public Service NewServiceObj { get; set; }

        public IEnumerable<Service> PastServicesObj { get; set; }

        public List<ServiceType> ServiceTypesObj { get; set; }
    }
}
