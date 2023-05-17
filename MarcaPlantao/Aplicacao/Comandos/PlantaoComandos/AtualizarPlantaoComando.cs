using FluentValidation;
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
    public class AtualizarPlantaoComando : Comando
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public double ValorTotal { get; set; }
        public double HoraExtra { get; set; }
        public string Desconto { get; set; }
        public int StatusPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string Comprovante { get; set; }
        public DateTime DataCadastro { get; set; }

        public AtualizarPlantaoComando(Guid id, int status, DateTime dataInicial, DateTime dataFinal, double valorTotal, double horaExtra, string desconto, int statusPagamento, DateTime? dataPagamento, string comprovante, DateTime dataCadastro)
        {
            Id = id;
            Status = status;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            ValorTotal = valorTotal;
            HoraExtra = horaExtra;
            Desconto = desconto;
            StatusPagamento = statusPagamento;
            DataPagamento = dataPagamento;
            Comprovante = comprovante;
            DataCadastro = dataCadastro;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AtualizarPlantaoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
    public class AtualizarPlantaoValidacao : AbstractValidator<AtualizarPlantaoComando>
    {
        public AtualizarPlantaoValidacao()
        {
        }
    }
}
