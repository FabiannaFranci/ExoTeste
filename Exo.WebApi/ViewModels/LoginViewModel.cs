using System.ComponentModel.DataAnnotations;
using System.Security;

namespace Exo.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; }
    }
}
