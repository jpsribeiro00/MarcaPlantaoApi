using FluentValidation;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.PlantaoComandos
{
    public class AtualizarStatusPlantaoComando : Comando
    {
        public Guid Id { get; set; }
        public int Status { get; set; }

        public AtualizarStatusPlantaoComando(Guid id, int status)
        {
            Id = id;
            Status = status;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AtualizarStatusPlantaoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AtualizarStatusPlantaoValidacao : AbstractValidator<AtualizarStatusPlantaoComando>
    {
        public AtualizarStatusPlantaoValidacao()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");

            RuleFor(c => c.Status)
                .NotEmpty()
                .WithMessage("Status não foi informado.");
        }
    }
}
