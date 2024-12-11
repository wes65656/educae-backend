using educae.biblioteca.app.Models;
using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.biblioteca.app.Application.Commands;

public class EditarCartilhaCommand : Command
{
    public Guid CartilhaId { get; set; }
    public string Titulo { get; set; }
    public string Resumo { get; set; }
    public string Descricao { get; set; }
    public string Url {get; set;}
    public string Autor { get; set; }
    public List<AnexoModel> Anexos {get; set;}

    public EditarCartilhaCommand(Guid cartilhaId, string titulo, string resumo, string descricao, string url, string autor, List<AnexoModel> anexos)
    {
        CartilhaId = cartilhaId;
        Titulo = titulo;
        Resumo = resumo;
        Descricao = descricao;
        Url = url;
        Autor = autor;
        Anexos = anexos;
    }
    
    public override bool EstaValido()
    {
        ValidationResult = new EditarCartilhaValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class EditarCartilhaValidation : AbstractValidator<EditarCartilhaCommand>
    {
        public EditarCartilhaValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("A propriedade título é obrigatória")
                .NotNull().WithMessage("A propriedade título é obrigatória");
            
            RuleFor(x => x.Resumo)
                .NotEmpty().WithMessage("A propriedade resumo é obrigatória")
                .NotNull().WithMessage("A propriedade resumo é obrigatória");
            
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A propriedade descrição é obrigatória")
                .NotNull().WithMessage("A propriedade descrição é obrigatória");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("A propriedade autor é obrigatória!")
                .NotNull().WithMessage("A propriedade autor é obrigatória!");
        }
    }
}