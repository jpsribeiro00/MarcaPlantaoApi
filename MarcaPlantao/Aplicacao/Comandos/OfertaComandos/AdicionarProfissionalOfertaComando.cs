using FluentValidation;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.OfertaComandos
{
    public class AdicionarProfissionalOfertaComando : Comando
    {
        public Guid ProfissionalId { get; set; }
        public Guid OfertaId { get; set; }

        public AdicionarProfissionalOfertaComando(Guid profissionalId, Guid ofertaId)
        {
            ProfissionalId = profissionalId;
            OfertaId = ofertaId;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AdicionarProfissionalOfertaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AdicionarProfissionalOfertaValidacao : AbstractValidator<AdicionarProfissionalOfertaComando>
    {
        public AdicionarProfissionalOfertaValidacao()
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
