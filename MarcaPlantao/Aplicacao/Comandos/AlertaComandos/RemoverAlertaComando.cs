using FluentValidation;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.AlertaComandos
{
    public class RemoverAlertaComando : Comando
    {
        public Guid Id { get; set; }

        public RemoverAlertaComando(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new RemoverAlertaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class RemoverAlertaValidacao : AbstractValidator<RemoverAlertaComando>
    {
        public RemoverAlertaValidacao()
        {

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");
        }
    }
}
