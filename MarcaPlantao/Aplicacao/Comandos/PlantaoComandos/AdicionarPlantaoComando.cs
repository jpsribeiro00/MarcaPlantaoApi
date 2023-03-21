using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.ClinicaComandos;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.PlantaoComandos
{
    public class AdicionarPlantaoComando : ComandoAdicionar
    {
        public Guid OfertaId { get; set; }
        public Guid ProfissionalId { get; set; }

        public AdicionarPlantaoComando(Guid ofertaId, Guid profissionalId)
        {
            OfertaId = ofertaId;
            ProfissionalId = profissionalId;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AdicionarPlantaoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
    public class AdicionarPlantaoValidacao : AbstractValidator<AdicionarPlantaoComando>
    {
        public AdicionarPlantaoValidacao()
        {
            RuleFor(c => c.OfertaId)
                .NotEmpty()
                .WithMessage("Id Oferta não foi informado.");

            RuleFor(c => c.ProfissionalId)
                .NotEmpty()
                .WithMessage("Id Profissional não foi informado.");
        }
    }

}
