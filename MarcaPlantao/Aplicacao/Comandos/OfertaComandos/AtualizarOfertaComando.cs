using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.OfertaComandos
{
    public class AtualizarOfertaComando : Comando
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Turno { get; set; }
        public double Valor { get; set; }
        public double ValorHoraExtra { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Pagamento { get; set; }

        public AtualizarOfertaComando(Guid id, string titulo, string descricao, DateTime dataInicial, DateTime dataFinal, string turno, double valor, double valorHoraExtra, DateTime dataCadastro, int pagamento)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Turno = turno;
            Valor = valor;
            ValorHoraExtra = valorHoraExtra;
            DataCadastro = dataCadastro;
            Pagamento = pagamento;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AtualizarOfertaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AtualizarOfertaValidacao : AbstractValidator<AtualizarOfertaComando>
    {
        public AtualizarOfertaValidacao()
        {

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("Descrição não foi informado.");

            RuleFor(c => c.Valor)
                .NotEmpty()
                .WithMessage("Valor não foi informado.");

            RuleFor(c => c.DataInicial)
                .NotEmpty()
                .WithMessage("Data Inicial do Plantão não foi informado.");

            RuleFor(c => c.DataFinal)
                .NotEmpty()
                .WithMessage("Data Final do Plantão não foi informado.");

            RuleFor(c => c.Turno)
                .NotEmpty()
                .WithMessage("Turno do Plantão não foi informado.");

            RuleFor(c => c.ValorHoraExtra)
                .NotEmpty()
                .WithMessage("Valor de Hora Extra do Plantão não foi informado.");

            RuleFor(c => c.Pagamento)
                .NotEmpty()
                .WithMessage("Pagamento não foi informado.");
        }
    }
}
