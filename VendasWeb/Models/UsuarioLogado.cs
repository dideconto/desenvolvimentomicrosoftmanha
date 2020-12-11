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

        [Display(Name = "CEP:")]
        public string Cep { get; set; }

        [Display(Name = "Rua:")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade:")]
        public string Localidade { get; set; }

        [Display(Name = "Estado:")]
        public string Uf { get; set; }
    }
}
