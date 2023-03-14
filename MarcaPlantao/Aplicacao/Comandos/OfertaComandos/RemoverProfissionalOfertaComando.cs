using FluentValidation;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.OfertaComandos
{
    public class RemoverProfissionalOfertaComando : Comando
    {
        public Guid ProfissionalId { get; set; }
        public Guid OfertaId { get; set; }

        public RemoverProfissionalOfertaComando(Guid profissionalId, Guid ofertaId)
        {
            ProfissionalId = profissionalId;
            OfertaId = ofertaId;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new RemoverProfissionalOfertaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class RemoverProfissionalOfertaValidacao : AbstractValidator<RemoverProfissionalOfertaComando>
    {
        public RemoverProfissionalOfertaValidacao()
        {

            RuleFor(c => c.ProfissionalId)
                .NotEmpty()
                .WithMessage("Id do profissional não foi informado.");

            RuleFor(c => c.OfertaId)
                .NotEmpty()
                .WithMessage("Id do oferta não foi informado.");
        }
    }
}
