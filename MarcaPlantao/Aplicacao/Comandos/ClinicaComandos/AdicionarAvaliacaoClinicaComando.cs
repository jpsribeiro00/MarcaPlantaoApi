using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.ClinicaComandos
{
    public class AdicionarAvaliacaoClinicaComando : Comando
    {
        public Guid ClinicaId { get; set; }
        public Guid PlantaoId { get; set; }
        public Guid ProfissionalId { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
        public DateTime DataAvaliacao { get; set; }

        public AdicionarAvaliacaoClinicaComando(Guid clinicaId, Guid plantaoId, Guid profissionalId, string descricao, int nota, DateTime dataAvaliacao)
        {
            ClinicaId = clinicaId;
            PlantaoId = plantaoId;
            ProfissionalId = profissionalId;
            Descricao = descricao;
            Nota = nota;
            DataAvaliacao = dataAvaliacao;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AdicionarAvaliacaoClinicaComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AdicionarAvaliacaoClinicaComandoValidacao : AbstractValidator<AdicionarAvaliacaoClinicaComando>
    {
        public AdicionarAvaliacaoClinicaComandoValidacao()
        {

            RuleFor(c => c.ClinicaId)
                .NotEmpty()
                .WithMessage("Clinica não foi informado.");

            RuleFor(c => c.ProfissionalId)
                .NotEmpty()
                .WithMessage("Profissional não foi informado.");

            RuleFor(c => c.Nota)
                .NotNull()
                .WithMessage("Nota não foi informado.");
        }
    }
}
