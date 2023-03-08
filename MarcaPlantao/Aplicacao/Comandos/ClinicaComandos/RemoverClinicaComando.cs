using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.ClinicaComandos;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.ClinicaComandos
{
    public class RemoverClinicaComando : Comando
    {
        public Guid Id { get; set; }

        public RemoverClinicaComando(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new RemoverClinicaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class RemoverClinicaValidacao : AbstractValidator<RemoverClinicaComando>
    {
        public RemoverClinicaValidacao()
        {

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");
        }
    }
}
