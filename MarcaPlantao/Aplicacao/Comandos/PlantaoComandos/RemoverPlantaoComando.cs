using FluentValidation;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.PlantaoComandos
{
    public class RemoverPlantaoComando : Comando
    {
        public Guid Id { get; set; }
        public RemoverPlantaoComando(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new RemoverPlantaoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class RemoverPlantaoValidacao : AbstractValidator<RemoverPlantaoComando>
    {
        public RemoverPlantaoValidacao()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");
        }
    }
}
