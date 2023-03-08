using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.OfertaComandos
{
    public class RemoverOfertaComando : Comando
    {
        public Guid Id { get; set; }

        public RemoverOfertaComando(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new RemoverOfertaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class RemoverOfertaValidacao : AbstractValidator<RemoverOfertaComando>
    {
        public RemoverOfertaValidacao()
        {

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");
        }
    }
}
