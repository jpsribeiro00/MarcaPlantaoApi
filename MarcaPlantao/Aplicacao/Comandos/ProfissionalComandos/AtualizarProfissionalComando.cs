using FluentValidation;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao_Infraestrutura.Mensagens;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos
{
    public class AtualizarProfissionalComando : Comando
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public byte[]? Imagem { get; set; }
        public string CRM { get; set; }
        public string CPF { get; set; }
        public string UserId { get; set; }
        public List<OfertaDados> Ofertas { get; set; }
        public List<EspecializacaoSimplificadoDados> Especializacoes { get; set; }

        public AtualizarProfissionalComando(Guid id, string nome, DateTime dataNascimento, string genero, string telefone, byte[]? imagem, string cRM, string cPF, string userId, List<OfertaDados> ofertas, List<EspecializacaoSimplificadoDados> especializacoes)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Genero = genero;
            Telefone = telefone;
            Imagem = imagem;
            CRM = cRM;
            CPF = cPF;
            UserId = userId;
            Ofertas = ofertas;
            Especializacoes = especializacoes;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AtualizarProfissionalValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AtualizarProfissionalValidacao : AbstractValidator<AtualizarProfissionalComando>
    {
        public AtualizarProfissionalValidacao()
        {

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome não foi informado.");

            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .WithMessage("Data de Nascimento não foi informado.");

            RuleFor(c => c.Genero)
                .NotEmpty()
                .WithMessage("Gênero não foi informado.");

            RuleFor(c => c.Telefone)
                .NotEmpty()
                .WithMessage("Telefone não foi informado.");

            RuleFor(c => c.CRM)
                .NotEmpty()
                .WithMessage("CRM não foi informado.");

            RuleFor(c => c.CPF)
                .NotEmpty()
                .WithMessage("CPF não foi informado.");
        }
    }
}
