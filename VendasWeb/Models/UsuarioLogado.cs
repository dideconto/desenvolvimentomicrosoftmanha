using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWeb.Models
{
    public class UsuarioLogado : BaseModel
    {
        [Display(Name = "E-mail:")]
        [EmailAddress]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem!")]
        public string ConfirmacaoSenha { get; set; }
    }
}
