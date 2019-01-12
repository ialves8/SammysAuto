using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SammysAuto.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Cidade { get; set; }

        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Display(Name = "Número Telefone")]
        public string NumeroTelefone { get; set; }
    }
}
