using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.ClinicaComandos;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.AvaliacaoComandos
{
    public class AdicionarAvaliacaoProfissionalClinicaComando : Comando
    {
        public Guid PlantaoId { get; set; }
        public Guid ProfissionalId { get; set; }
        public Guid ClinicaId { get; set; }
        public int Nota { get; set; }
        public string Descricao { get; set; }

        public AdicionarAvaliacaoProfissionalClinicaComando(Guid plantaoId, Guid profissionalId, Guid clinicaId, int nota, string descricao)
        {
            PlantaoId = plantaoId;
            ProfissionalId = profissionalId;
            ClinicaId = clinicaId;
            Nota = nota;
            Descricao = descricao;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AdicionarAvaliacaoProfissionalClinicaComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AdicionarAvaliacaoProfissionalClinicaComandoValidacao : AbstractValidator<AdicionarAvaliacaoProfissionalClinicaComando>
    {
        public AdicionarAvaliacaoProfissionalClinicaComandoValidacao()
        {

            RuleFor(c => c.ClinicaId)
                .NotEmpty()
                .WithMessage("Clinica não foi informado.");

            RuleFor(c => c.ProfissionalId)
                .NotEmpty()
                .WithMessage("Profissional não foi informado.");

            RuleFor(c => c.PlantaoId)
                .NotEmpty()
                .WithMessage("Plantão não foi informado.");
        }
    }
}
