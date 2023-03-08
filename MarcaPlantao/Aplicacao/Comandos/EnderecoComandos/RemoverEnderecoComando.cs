using FluentValidation;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.EnderecoComandos
{
    public class RemoverEnderecoComando : Comando
    {
        public Guid Id { get; set; }

        public RemoverEnderecoComando(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new RemoverEnderecoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class RemoverEnderecoValidacao : AbstractValidator<RemoverEnderecoComando>
    {
        public RemoverEnderecoValidacao()
        {

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");
        }
    }
}
