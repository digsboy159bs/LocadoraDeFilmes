using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        // Define que o tipo de dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        // Define que o tipo de dado
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
