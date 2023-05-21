using FluentValidation;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.PlantaoComandos
{
    public class EncerrarPlantaoComando : Comando
    {
        public Guid Id { get; set; }
        public Guid ClinicaId { get; set; }
        public Guid ProfissionalId { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
        public string Comprovante { get; set; }
        public DateTime DataFinal { get; set; }
        public double ValorTotal { get; set; }
        public double HoraExtra { get; set; }
        public string Desconto { get; set; }
        public DateTime DataAvaliacao { get; set; }

        public EncerrarPlantaoComando(Guid id, Guid clinicaId, Guid profissionalId, string descricao, int nota, string comprovante, DateTime dataFinal, double valorTotal, double horaExtra, string desconto, DateTime dataAvaliacao)
        {
            Id = id;
            ClinicaId = clinicaId;
            ProfissionalId = profissionalId;
            Descricao = descricao;
            Nota = nota;
            Comprovante = comprovante;
            DataFinal = dataFinal;
            ValorTotal = valorTotal;
            HoraExtra = horaExtra;
            Desconto = desconto;
            DataAvaliacao = dataAvaliacao;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new EncerrarPlantaoComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class EncerrarPlantaoComandoValidacao : AbstractValidator<EncerrarPlantaoComando>
    {
        public EncerrarPlantaoComandoValidacao()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");

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
